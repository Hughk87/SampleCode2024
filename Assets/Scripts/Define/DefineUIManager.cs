using UnityEngine;

public class DefineUI
{
    public const float DEFAULT_RESOLUTION_X = 1920f;
    public const float DEFAULT_RESOLUTION_Y = 1080f;
    public const int SORTORDER_POPUP_DEFAULT = 100;
    public const int SORTORDER_POPUP_ABSOLUTE = 200;
}


public class PopupUI : MonoBehaviour
{
    public virtual void ApplyLauguage()
    {
        this.ApplyLauguageInChildren();
    }

    public virtual void Initialize(params object[] _args)
    {
        UIManager.Instance.AddPopupUI(this);
    }
    public void Destroy()
    {
        UIManager.Instance.RemovePopupUI(this);
        Destroy(this.gameObject);
    }
    public virtual void SetCallBack(params System.Action[] _callBacks) { }
}


public class SceneUI : MonoBehaviour
{
    public void Awake()
    {
        UIManager.Instance.AddDelegateApplyLauguage(ApplyLauguage);
    }

    public void OnDestroy()
    {
        if (!GameManager.IsPlaying)
            return;

        UIManager.Instance.RemoveDelegateApplyLauguage(ApplyLauguage);
    }

    // �� �����ϴ� �κп��� 2������ ��� ���.
    //1. �ش� �Լ��� ȣ�� �Ǵ� Ÿ�ֿ̹� ã�Ƽ� �����Ѵ�.
    //2. ó�� �ʱ�ȭ �Ǵ� Ÿ�ֿ̹� Text�� ���� �����ڸ�
    // ��� ������ �ֵ��� �ϰ�, �����ؾ��� �� ã���ʰ� �ٷ� �����Ѵ�.

    //>> ��,������ ���� ���ڸ�
    // 1���� ����ϰ� �� ����ɼ��� ���� �������,
    // 2���� ����ϰ� �� ������� �ʴ´ٸ� ���� �ȴ�.
    // >>> ������ ������ �󵵰� �󸶳� ���� ��Ȯ�ϰԴ� �𸣰�����,
    // >>> �Ϲ������� �� �����ϴ� Ƚ�� ��ü�� ���� �ʴ�. �� �������� [[1��]]����.
    public virtual void ApplyLauguage()
    {
        this.ApplyLauguageInChildren();
    }
}