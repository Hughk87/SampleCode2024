using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public static GAME_STATE State { get; private set; }


    void Update()
    {
        // esc (window) / back button (android)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(State == GAME_STATE.MAINUI ||
                State == GAME_STATE.PLAYGAME)
            {
                UIManager.Instance.CreateExitWindow();
            }
        }
    }




    public override void Initialize()
    {
        State = GAME_STATE.NONE;

        CreateManager<UIManager>();
        CreateManager<DataManager>();
        //UIManager.Create(this.transform).Initialize();
        //DataManager.Create(this.transform).Initialize();

        State = GAME_STATE.INITIALIZE;

        ChangeState(GAME_STATE.MAINUI);
    }
    void CreateManager<T>() where T : MonoSingleton<T>
    {
        MonoSingleton<T>.Create(this.transform).Initialize();
    }

    public void ChangeState(GAME_STATE _state)
    {
        if (State == _state)
        {
            Debug.LogError($"ChangeState ::  같은 상태로는 바뀔 수 없습니다. {State} => {_state}");
            return;
        }

        if(_state == GAME_STATE.INITIALIZE)
        {
            Debug.LogError($"ChangeState ::  {_state} 상태로는 바뀔 수 없습니다. // 현재 상태 : {State}");
            return;
        }

        // 이전 상태에 대한 뒷처리
        ChangeState_Prev(_state);

        // 다음 상태에 대한 선처리
        ChangeState_Next(_state);

        State = _state;
    }

    void ChangeState_Prev(GAME_STATE _state)
    {
        switch (_state)
        {
            case GAME_STATE.MAINUI:
                break;
            case GAME_STATE.PLAYGAME:
                break;

            case GAME_STATE.INITIALIZE:
                Debug.LogError($"ChangeState_Prev :: 처리되지 않은 값 // {_state}");
                break;
            case GAME_STATE.NONE:
            default:
                Debug.LogError($"ChangeState_Prev :: 정의되지 않은 값 // {_state}");
                break;
        }
    }
    void ChangeState_Next(GAME_STATE _state)
    {
        switch (_state)
        {
            case GAME_STATE.MAINUI:
                SceneManager.LoadScene(SceneList.SceneMainUI, LoadSceneMode.Single);
                break;

            case GAME_STATE.PLAYGAME:
                SceneManager.LoadScene(SceneList.ScenePlayGame, LoadSceneMode.Single);
                break;

            case GAME_STATE.INITIALIZE:
                Debug.LogError($"ChangeState_Next :: 처리되지 않은 값 // {_state}");
                break;
            case GAME_STATE.NONE:
            default:
                Debug.LogError($"ChangeState_Next :: 정의되지 않은 값 // {_state}");
                break;
        }
    }

    public void ExitProgram()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
