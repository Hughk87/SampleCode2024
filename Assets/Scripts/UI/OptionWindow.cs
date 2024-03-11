using UnityEngine;

public class OptionWindow : PopupUI
{
    public ToggleButtons toggleButtonSound;
    public ToggleButtons toggleButtonLocalize;

    public override void Initialize()
    {           
        toggleButtonSound.Initialize(ChangeOptionSound, (int)DataManager.Instance.sound);
        toggleButtonLocalize.Initialize(ChangeOptionLocalize, (int)DataManager.Instance.language);

        base.Initialize();
    }

    public void ChangeOptionSound(int _index)
    {
        DataManager.Instance.ChangeOptionSound(_index);
    }
    public void ChangeOptionLocalize(int _index)
    {
        DataManager.Instance.ChangeOptionLanguage(_index);
    }
    public void OnClickClose()
    {
        Destroy();
    }
}
