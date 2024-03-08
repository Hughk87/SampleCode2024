using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    Transform popupParent = null;
    Transform popupAbsolute = null;

    public override void Initialize()
    {
        popupParent = CreateCanvas("Canvas_Popup", DefineUI.SORT_ORDER_POPUP_DEFAULT);
        popupAbsolute = CreateCanvas("Canvas_Absolute", DefineUI.SORT_ORDER_POPUP_ABSOLUTE);
    }

    Transform CreateCanvas(string _name, int _sortingOrder)
    {
        GameObject _createObject = new GameObject(_name, new Type[] { typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster) });
        _createObject.transform.SetParent(this.transform);

        Canvas _canvas = _createObject.GetComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.sortingOrder = _sortingOrder;

        CanvasScaler _canvasScaler = _createObject.GetComponent<CanvasScaler>();
        _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvasScaler.referenceResolution = new Vector2(DefineUI.DEFAULT_RESOLUTION_X, DefineUI.DEFAULT_RESOLUTION_Y);
        _canvasScaler.matchWidthOrHeight = 1f;

        return _createObject.transform;
    }

    public void CreateExitWindow()
    {
        GameObject _obj = GameObject.Instantiate(Resources.Load("MessageWindow") as GameObject);
        MessageWindow _component = _obj.GetComponent<MessageWindow>();
        _component.Initialize(MessageWindow.MODE.OKAY_CANCEL, "Do you wanna Exit Game ?", OnClickExitOK);

        _obj.transform.SetParent(popupParent);
        if (_obj.transform is RectTransform)
        {
            (_obj.transform as RectTransform).offsetMin = Vector2.zero;
            (_obj.transform as RectTransform).offsetMax = Vector2.zero;
        }
        else
        {
            Debug.LogError("UIManager.CreateExitWindow() :: UI 오브젝트가 RectTransform이 아닙니다 !");
            _obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        _obj.transform.localScale = Vector3.one;
    }

    public void CreateOptionWindow()
    {
        GameObject _obj = GameObject.Instantiate(Resources.Load("OptionWindow") as GameObject);
        OptionWindow _component = _obj.GetComponent<OptionWindow>();
        _component.Initialize();

        _obj.transform.SetParent(popupParent);
        if (_obj.transform is RectTransform)
        {
            (_obj.transform as RectTransform).offsetMin = Vector2.zero;
            (_obj.transform as RectTransform).offsetMax = Vector2.zero;
        }
        else
        {
            Debug.LogError("UIManager.CreateExitWindow() :: UI 오브젝트가 RectTransform이 아닙니다 !");
            _obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        _obj.transform.localScale = Vector3.one;
    }

    public void OnClickExitOK()
    {
        GameManager.Instance.ExitProgram();
    }

    // UI 객체를 생성.
    // 1. Canvas 를 포함한 프리팹을 생성 (로드)
    // 2. Canvas 를 가지고 있는 상태로, Canvas가 없는 프리팹을 생성. **
    // => Canvas 의 설정을 하나하나 수정하기 힘들다. 또, 상황에 따라 Canvas 설정을 제어하기 쉽다.
    // => Canvas 자체의 설정을 여러개 미리 해놓고, 상황에 따라 사용한다.

    // UI 객체를 관리.

    // UI 객체를 소멸.

    // UI 에 대한 Object Pooling 처리.

}
