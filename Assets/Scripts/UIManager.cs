using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    List<PopupUI> popupUIList = new List<PopupUI>();
    Transform ParentDefault = null;
    Transform ParentAbsolute = null;

    System.Action delegateApplyLanguage;

    public override void Initialize(params System.Object[] _object)
    {
        Debug.Log("UIManager.Initialize()");
        ParentDefault = CreateCanvas("Canvas_Popup", DefineUI.SORTORDER_POPUP_DEFAULT);
        ParentAbsolute = CreateCanvas("Canvas_Absolute", DefineUI.SORTORDER_POPUP_ABSOLUTE);
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

    public T CreatePopupUI<T>(params object[] _args) where T : PopupUI
    {
        return CreatePopup<T>(ParentDefault, _args);
    }

    public T CreatePopupUIAbsolute<T>(params object[] _args) where T : PopupUI
    {
      return  CreatePopup<T>(ParentAbsolute, _args);
    }
    // UI 객체를 생성.
    T CreatePopup<T>(Transform _parent, params object[] _args) where T : PopupUI
    {
        GameObject _obj = ResourcesManager.LoadUIPrefab(typeof(T).Name, _parent);
        T _component = _obj.GetComponent<T>();
        _component.Initialize(_args);
        return _component;
    }

    public void CreateMessageWindow_OK(string _text, Action _callback)
    {
        MessageWindow _popupUI = CreatePopupUIAbsolute<MessageWindow>(MessageWindow.MODE.OKAY, _text);
        _popupUI.SetCallBack(_callback);
    }
    public void CreateMessageWindow_OKCANCEL(string _text, Action _callbackOK, Action _callbackCancel = null)
    {
        MessageWindow _popupUI = CreatePopupUIAbsolute<MessageWindow>(MessageWindow.MODE.OKAY_CANCEL, _text);
        if (_callbackCancel != null)
            _popupUI.SetCallBack(_callbackOK, _callbackCancel);
        else
            _popupUI.SetCallBack(_callbackOK);
    }

    public void ApplyLauguage()
    {
        for(int i=0;i<popupUIList.Count;i++)
            popupUIList[i].ApplyLauguage();

        // 각 씬에서 사용되는 UI 에 대한 callback 호출
        if (delegateApplyLanguage != null)
            delegateApplyLanguage(); 
    }

    public void AddDelegateApplyLauguage(System.Action _delegateApplyLanguage)
    {
        delegateApplyLanguage += _delegateApplyLanguage;
    }
    public void RemoveDelegateApplyLauguage(System.Action _delegateApplyLanguage)
    {
        delegateApplyLanguage -= _delegateApplyLanguage;
    }

    // UI 객체를 관리.
    public void AddPopupUI(PopupUI _popupUI)
    {
        popupUIList.Add(_popupUI);
    }
    public void RemovePopupUI(PopupUI _popupUI)
    {
        popupUIList.Remove(_popupUI);
    }

    public bool IsExistPopup<T>() where T : PopupUI
    {
        bool _retval = false;
        for (int i = 0; i < popupUIList.Count; i++)
        {
            if (popupUIList[i] is T)
            {
                _retval = true;
                break;
            }
        }
        return _retval;
    }

    // to do :: UI 에 대한 Object Pooling 처리.

}
