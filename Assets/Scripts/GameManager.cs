using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public static GAME_STATE State { get; private set; }
    public static bool IsPlaying { get; private set; }

    void Update()
    {
        // esc (window) / back button (android)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.Instance.IsExistPopup<MessageWindow>())
                return;

            if(State == GAME_STATE.MAINUI ||
                State == GAME_STATE.PLAYGAME)
            {
                UIManager.Instance.CreateMessageWindow_OKCANCEL(LocalizeManager.Instance.GetText(13), ExitProgram);
            }
        }
    }

    private void OnApplicationQuit()
    {
        IsPlaying = false;
    }

    public override void Initialize(params object[] _object)
    {
        State = GAME_STATE.NONE;
        IsPlaying = true;

        CreateManager<UIManager>();
        CreateManager<DataManager>();
        CreateManager<SoundManager>();

        CreateManager<LocalizeManager>(DataManager.Instance.language);

        State = GAME_STATE.INITIALIZE;

        ChangeState(GAME_STATE.MAINUI);
    }

    void CreateManager<T>(params object[] _object) where T : MonoSingleton<T>
    {
        MonoSingleton<T>.Create(this.transform).Initialize(_object);
    }

    public void ChangeState(GAME_STATE _state)
    {
        if (State == _state)
        {
            Debug.LogError($"ChangeState ::  ���� ���·δ� �ٲ� �� �����ϴ�. {State} => {_state}");
            return;
        }

        if(_state == GAME_STATE.INITIALIZE)
        {
            Debug.LogError($"ChangeState ::  {_state} ���·δ� �ٲ� �� �����ϴ�. // ���� ���� : {State}");
            return;
        }

        // ���� ���¿� ���� ��ó��
        ChangeState_Prev(_state);

        // ���� ���¿� ���� ��ó��
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
                Debug.LogError($"ChangeState_Prev :: ó������ ���� �� // {_state}");
                break;
            case GAME_STATE.NONE:
            default:
                Debug.LogError($"ChangeState_Prev :: ���ǵ��� ���� �� // {_state}");
                break;
        }
    }
    void ChangeState_Next(GAME_STATE _state)
    {
        switch (_state)
        {
            case GAME_STATE.MAINUI:
                SceneManager.LoadScene(SceneList.SceneMainUI, LoadSceneMode.Single);
                SoundManager.Instance.PlayBGM(SOUND_BGM.BGM_ONTHEROCKS);
                break;

            case GAME_STATE.PLAYGAME:
                SceneManager.LoadScene(SceneList.ScenePlayGame, LoadSceneMode.Single);
                SoundManager.Instance.PlayBGM(SOUND_BGM.BGM_FINEDINING);
                break;

            case GAME_STATE.INITIALIZE:
                Debug.LogError($"ChangeState_Next :: ó������ ���� �� // {_state}");
                break;
            case GAME_STATE.NONE:
            default:
                Debug.LogError($"ChangeState_Next :: ���ǵ��� ���� �� // {_state}");
                break;
        }
    }

    public void ApplySound()
    {
        OPTION_SOUND _language = DataManager.Instance.sound;
        SoundManager.Instance.SetMute(_language == OPTION_SOUND.OFF);
    }

    public void ApplyLauguage()
    {
        OPTION_LANGUAGE _language = DataManager.Instance.language;

        // �ɼ��� ����
        LocalizeManager.Instance.ChangeLauguage(_language);
        UIManager.Instance.ApplyLauguage();
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
