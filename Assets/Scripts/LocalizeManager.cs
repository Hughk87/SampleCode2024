using System.Collections.Generic;
using UnityEngine;

public class LocalizeManager : MonoSingleton<LocalizeManager>
{
    List<LocalizeTableData> localizeTableList;

    public override void Initialize(params object[] _object)
    {
        Debug.Log("LocalizeManager.Initialize()");

        if (!(_object[0] is OPTION_LANGUAGE))
            return;

        LoadTableData((OPTION_LANGUAGE)_object[0]);
    }

    void LoadTableData(OPTION_LANGUAGE _lauguage)
    {
        LocalizeTable _tableData = TableManager.Get<LocalizeTable>(TableManager.GetTableName(_lauguage));
        localizeTableList = _tableData.localizeTableList;
    }
    public void ChangeLauguage(OPTION_LANGUAGE _lauguage)
    {
        LoadTableData(_lauguage);
    }
    public string GetText(int _key)
    {
        int _findIndex = GetIndex(_key);
        if (_findIndex == DefineClient.INDEX_NONE)
        {
            Debug.LogError($"ERROR !!]] LocalizeManager.GetText() '{_key}' 키값이 존재하지 않습니다 !");
            return string.Empty;
        }
        else
            return localizeTableList[_findIndex].value;
    }
    int GetIndex(int _key)
    {
        int _findIndex = DefineClient.INDEX_NONE;
        for(int i=0;i<localizeTableList.Count;i++)
        {
            if (localizeTableList[i].key == _key)
            {
                _findIndex = i;
                break;
            }
        }
        return _findIndex;
    }
}
