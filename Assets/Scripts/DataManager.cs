using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    const string KEY_SOUND = "KEY_SOUND";
    const string KEY_LOCALIZE = "KEY_LOCALIZE";

    public OPTION_SOUND sound { get; private set; }
    public OPTION_LOCALIZE localize { get; private set; }

    public override void Initialize()
    {
        sound = OPTION_SOUND.NONE;
        localize = OPTION_LOCALIZE.NONE;

        Load();
    }

    void Load()
    {
        sound = (OPTION_SOUND)PlayerPrefs.GetInt(KEY_SOUND, (int)OPTION_SOUND.ON);
        localize = (OPTION_LOCALIZE)PlayerPrefs.GetInt(KEY_LOCALIZE, (int)OPTION_LOCALIZE.KOREAN);
    }
    void SaveAll()
    {
        SaveSound(false);
        SaveLocalize(false);

        PlayerPrefs.Save();
    }
    void SaveSound(bool _isNeedSave = true)
    {
        PlayerPrefs.SetInt(KEY_SOUND, (int)sound);
        if(_isNeedSave)
            PlayerPrefs.Save();
    }

    void SaveLocalize(bool _isNeedSave = true)
    {
        PlayerPrefs.SetInt(KEY_LOCALIZE, (int)localize);
        if (_isNeedSave)
            PlayerPrefs.Save();
    }


    public void ChangeOptionSound(int _index)
    {
        // datamanager 에 옵션 변경을 요청.
        sound = (OPTION_SOUND)_index;
        SaveSound();

        // 옵션을 적용
        // soundmanager.instance.changeoption();
    }
    public void ChangeOptionLocalize(int _index)
    {
        // datamanager 에 옵션 변경을 요청.
        localize = (OPTION_LOCALIZE)_index;
        SaveLocalize();

        // 옵션을 적용
        // localizemanager.instance.changeoption();
    }

    private void OnDestroy()
    {
        SaveAll();
    }
}
