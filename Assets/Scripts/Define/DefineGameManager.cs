
public enum GAME_STATE
{
    NONE = -1,
    INITIALIZE,
    MAINUI,
    PLAYGAME
}

public class SceneList
{
    // 게임의 최초 시작은 initialize 씬에서 시작된다.
    //public const string SceneInitialize = "0_Initialize";

    public const string SceneMainUI = "MainUI";
    public const string ScenePlayGame = "PlayGame";
}
