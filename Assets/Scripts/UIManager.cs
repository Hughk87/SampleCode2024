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
            Debug.LogError("UIManager.CreateExitWindow() :: UI ������Ʈ�� RectTransform�� �ƴմϴ� !");
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
            Debug.LogError("UIManager.CreateExitWindow() :: UI ������Ʈ�� RectTransform�� �ƴմϴ� !");
            _obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        _obj.transform.localScale = Vector3.one;
    }

    public void OnClickExitOK()
    {
        GameManager.Instance.ExitProgram();
    }

    // UI ��ü�� ����.
    // 1. Canvas �� ������ �������� ���� (�ε�)
    // 2. Canvas �� ������ �ִ� ���·�, Canvas�� ���� �������� ����. **
    // => Canvas �� ������ �ϳ��ϳ� �����ϱ� �����. ��, ��Ȳ�� ���� Canvas ������ �����ϱ� ����.
    // => Canvas ��ü�� ������ ������ �̸� �س���, ��Ȳ�� ���� ����Ѵ�.

    // UI ��ü�� ����.

    // UI ��ü�� �Ҹ�.

    // UI �� ���� Object Pooling ó��.

}
