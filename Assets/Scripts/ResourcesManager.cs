using UnityEngine;

public class ResourcesManager// : MonoSingleton<ResourcesManager>
{
    public const string PATH_PREFAB_DEFAULT = "Prefab/";
    public const string PATH_PREFAB_UI = "Prefab/UI/";

    public const string PATH_AUDIOCLIP = "Sound/";
    //sound ����

    #region Load Prefab
    /// <summary>
    /// Prefab �� �ε��ϰ�, �����ؼ� ��ȯ�ϴ� �Լ�.(3D ������Ʈ)
    /// </summary>
    public static GameObject LoadPrefab(string _prefabName, Transform _parent = null)
    {
        GameObject _obj = Instantiate(PATH_PREFAB_DEFAULT + _prefabName, _parent);

        if (_obj.transform is RectTransform)
            Debug.LogError("ResourcesManager.LoadPrefab() :: ������ ������Ʈ�� RectTransform �Դϴ� !");

        return _obj;
    }

    /// <summary>
    /// Prefab �� �ε��ϰ�, �����ؼ� ��ȯ�ϴ� �Լ�.(UI ������)
    /// </summary>
    public static GameObject LoadUIPrefab(string _prefabName, Transform _parent = null)
    {
        GameObject _obj = Instantiate(PATH_PREFAB_UI + _prefabName, _parent);

        if (!(_obj.transform is RectTransform))
            Debug.LogError("ResourcesManager.LoadUIPrefab() :: RectTransform �� �ƴմϴ� !");

        return _obj;
    }

    static GameObject Instantiate(string _path,Transform _parent)
    {
        GameObject _obj = GameObject.Instantiate(Resources.Load(_path) as GameObject);
        Transform _transform = _obj.transform;

        if (_parent != null)
            _transform.SetParent(_parent);

        if (_transform is RectTransform)
        {
            (_transform as RectTransform).offsetMin = Vector2.zero;
            (_transform as RectTransform).offsetMax = Vector2.zero;
        }
        else
        {
            _transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        _transform.localScale = Vector3.one;

        return _obj;
    }
    #endregion

    public static AudioClip LoadAudioClip(string _audioName)
    {
        return Resources.Load(PATH_AUDIOCLIP + _audioName) as AudioClip;
    }
}
