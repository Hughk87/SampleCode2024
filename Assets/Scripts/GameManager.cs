using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public void Initialize()
    {
        Debug.Log("GameManager :: Initialize()");
    }
}
