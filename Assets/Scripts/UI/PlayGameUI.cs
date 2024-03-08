using UnityEngine;

public class PlayGameUI : MonoBehaviour
{
    public void OnClickFinish()
    {
        GameManager.Instance.ChangeState(GAME_STATE.MAINUI);
    }
}
