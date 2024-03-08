using TMPro;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    public enum MODE
    {
        NONE = -1,
        OKAY,
        OKAY_CANCEL
    }

    public TextMeshProUGUI textMessage;
    public GameObject objCancelButton;
    System.Action delegateOkay;
    System.Action delegateCancel;
    public void Initialize(MODE _mode, string _message, System.Action _delegateOkay, System.Action _delegateCancel = null)
    {
        objCancelButton.SetActive(_mode == MODE.OKAY_CANCEL);
        textMessage.text = _message;
        delegateOkay = _delegateOkay;
        delegateCancel = _delegateCancel;
    }

    public void OnClickOkay()
    {
        if (delegateOkay != null) delegateOkay();

        Destroy(this.gameObject);
    }
    public void OnClickCancel()
    {
        if (delegateCancel != null) delegateCancel();

        Destroy(this.gameObject);
    }
}
