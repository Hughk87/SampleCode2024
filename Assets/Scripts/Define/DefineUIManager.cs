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

    // 언어를 갱신하는 부분에서 2가지의 방법 고민.
    //1. 해당 함수가 호출 되는 타이밍에 찾아서 적용한다.
    //2. 처음 초기화 되는 타이밍에 Text에 대한 참조자를
    // 모두 가지고 있도록 하고, 적용해야할 때 찾지않고 바로 적용한다.

    //>> 장,단점을 비교해 보자면
    // 1번은 빈번하게 언어가 변경될수록 값이 비싸지고,
    // 2번은 빈번하게 언어가 변경되지 않는다면 낭비가 된다.
    // >>> 유저의 선택의 빈도가 얼마나 될지 정확하게는 모르겠지만,
    // >>> 일반적으로 언어를 변경하는 횟수 자체는 많지 않다. 는 가정으로 [[1번]]선택.
    public virtual void ApplyLauguage()
    {
        this.ApplyLauguageInChildren();
    }
}