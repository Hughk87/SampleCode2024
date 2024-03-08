using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    public enum MODE
    {
        NONE = -1,
        AWAKE,
        START
    }
    public MODE mode;

    void Awake()
    {
        if(mode == MODE.AWAKE)
            DontDestroy();
    }
    void Start()
    {
        if (mode == MODE.START)
            DontDestroy();
    }
    void DontDestroy()
    {
        DontDestroyOnLoad(gameObject);
    }
}
