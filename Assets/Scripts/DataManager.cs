using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    const string KEY_SOUND = "KEY_SOUND";
    const string KEY_LANGUAGE = "KEY_LOCALIZE";

    public OPTION_SOUND sound { get; private set; }
    public OPTION_LANGUAGE language { get; private set; }

    public override void Initialize(params object[] _object)
    {
        Debug.Log("DataManager.Initialize()");
        sound = OPTION_SOUND.NONE;
        language = OPTION_LANGUAGE.NONE;

        Load();
    }

    void Load()
    {
        sound = (OPTION_SOUND)PlayerPrefs.GetInt(KEY_SOUND, (int)OPTION_SOUND.ON);
        language = (OPTION_LANGUAGE)PlayerPrefs.GetInt(KEY_LANGUAGE, (int)OPTION_LANGUAGE.KOREAN);
    }
    void SaveAll()
    {
        SaveSound(false);
        SaveLanguage(false);

        PlayerPrefs.Save();
    }
    void SaveSound(bool _isNeedSave = true)
    {
        PlayerPrefs.SetInt(KEY_SOUND, (int)sound);
        if(_isNeedSave)
            PlayerPrefs.Save();
    }

    void SaveLanguage(bool _isNeedSave = true)
    {
        PlayerPrefs.SetInt(KEY_LANGUAGE, (int)language);
        if (_isNeedSave)
            PlayerPrefs.Save();
    }


    public void ChangeOptionSound(int _index)
    {
        if (sound == (OPTION_SOUND)_index)
            return;

        sound = (OPTION_SOUND)_index;
        SaveSound();

        GameManager.Instance.ApplySound();
    }
    public void ChangeOptionLanguage(int _index)
    {
        if (language == (OPTION_LANGUAGE)_index)
            return;

        language = (OPTION_LANGUAGE)_index;
        SaveLanguage();

        GameManager.Instance.ApplyLauguage();
    }

    private void OnDestroy()
    {
        SaveAll();
    }
}
