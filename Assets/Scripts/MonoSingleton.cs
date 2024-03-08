using UnityEngine;

/// <summary>
/// MonoBehaviour �� ��ӹ޴� Singleton Ŭ����
/// </summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    const string MESSAGE_ERROR_ALREADYCREATE = "�̹� ������ �ν��Ͻ� ��ü�� �����մϴ�!";
    //�̱��� Ŭ������ �ϳ��� ��ü�� �����ؾ� �Ѵ�.

    //monosingleton �� gameobject �� �Բ� ���Ǳ� ������, ������ create ������ �ʿ��ϴ�.

    static T instance = null;
    public static T Instance
    {
        get
        {
            //instance �� ���� ��û (�Ǵ� ����)�� ������ ��, �������� ���� �Ǿ�� �Ѵ�.
            if (instance == null)
            {
                Create();
            }
            return instance;
        }
    }

    //���� ������Ʈ ���� �� component �߰�
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
