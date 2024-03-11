public class PlayGameUI : SceneUI
{
    public void OnClickFinish()
    {
        GameManager.Instance.ChangeState(GAME_STATE.MAINUI);
    }
}