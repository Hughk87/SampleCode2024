using UnityEngine;

public class MainUI : MonoBehaviour
{
    public void OnClickStart()
    {
        GameManager.Instance.ChangeState(GAME_STATE.PLAYGAME);
    }

    public void OnClickOption()
    {
        UIManager.Instance.CreateOptionWindow();
    }
}
