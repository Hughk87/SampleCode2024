public class MainUI : SceneUI
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