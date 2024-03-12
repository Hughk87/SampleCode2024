using System;
using TMPro;
using UnityEngine;

public class MessageWindow : PopupUI
{
    public enum MODE
    {
        NONE = -1,
        OKAY,
        OKAY_CANCEL
    }

    public TextMeshProUGUI textMessage;
    public GameObject objCancelButton;
    Action delegateOkay;
    Action delegateCancel;

    public override void Initialize(params object[] _args)
    {
        if (_args.Length != 2)
            return;

        if (!(_args[0] is MODE))
            return;

        if (!(_args[1] is string))
            return;

        objCancelButton.SetActive((MODE)_args[0] == MODE.OKAY_CANCEL);
        textMessage.text = (string)_args[1];

        base.Initialize();
    }
    public override void SetCallBack(params Action[] _callBacks)
    {
        if (_callBacks.Length < 0)
            return;

        delegateOkay = _callBacks[0];

        if (_callBacks.Length >= 2)
            delegateCancel = _callBacks[1];
    }

    public void OnClickOkay()
    {
        if (delegateOkay != null) delegateOkay();

        Destroy();
    }
    public void OnClickCancel()
    {
        if (delegateCancel != null) delegateCancel();

        Destroy();
    }
}
