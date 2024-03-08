using UnityEngine;

public class OptionWindow : MonoBehaviour
{
    public ToggleButtons toggleButtonSound;
    public ToggleButtons toggleButtonLocalize;

    public void Initialize()
    {           
        toggleButtonSound.Initialize(ChangeOptionSound, (int)DataManager.Instance.sound);
        toggleButtonLocalize.Initialize(ChangeOptionLocalize, (int)DataManager.Instance.localize);
    }

    public void ChangeOptionSound(int _index)
    {
        DataManager.Instance.ChangeOptionSound(_index);
    }
    public void ChangeOptionLocalize(int _index)
    {
        DataManager.Instance.ChangeOptionLocalize(_index);
    }
    public void OnClickClose()
    {
        Destroy(this.gameObject);
    }
}
