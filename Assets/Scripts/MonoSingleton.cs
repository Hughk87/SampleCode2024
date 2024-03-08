using UnityEngine;

/// <summary>
/// MonoBehaviour 를 상속받는 Singleton 클래스
/// </summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    const string MESSAGE_ERROR_ALREADYCREATE = "이미 생성된 인스턴스 객체가 존재합니다!";
    //싱글톤 클래스는 하나의 객체만 생성해야 한다.

    //monosingleton 은 gameobject 와 함께 사용되기 때문에, 별도의 create 과정이 필요하다.

    static T instance = null;
    public static T Instance
    {
        get
        {
            //instance 에 대한 요청 (또는 접근)이 들어왔을 때, 안정성이 보장 되어야 한다.
            if (instance == null)
            {
                Create();
            }
            return instance;
        }
    }

    //게임 오브젝트 생성 및 component 추가
    public static T Create(Transform _parent = null)
    {
        if (instance == null)
        {
            GameObject _createObject = new GameObject(typeof(T).Name);
            if (_parent != null)
                _createObject.transform.SetParent(_parent);

            instance = _createObject.AddComponent<T>();

            DontDestroyOnLoad(_createObject);
        }
        else
        {
            Debug.LogError(MESSAGE_ERROR_ALREADYCREATE);
        }
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError(MESSAGE_ERROR_ALREADYCREATE);
            Destroy(this.gameObject);
        }
    }

    public virtual void Initialize() { }
}
