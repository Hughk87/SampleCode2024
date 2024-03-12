using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class TableManager// : MonoSingleton<TableManager>
{
    public const string PATH_TABLE = "Resources/Table/";
    public const string TABLENAME_DEFAULT_LOCALIZE = "Localize";
    
    public static T Get<T>(string _tableName) where T : TableBase
    {
        try
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append(Path.Combine(Application.dataPath, PATH_TABLE))
                .Append(_tableName).Append(".json");

            string _jsonData = File.ReadAllText(_stringBuilder.ToString());
            return JsonUtility.FromJson<T>(_jsonData);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        return null;
    }

    public static bool Set<T>(string _tableName, T _data) where T : TableBase
    {
        try
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append(Path.Combine(Application.dataPath, PATH_TABLE))
                .Append(_tableName).Append(".json");

            string _jsonData = JsonUtility.ToJson(_data, true);
            File.WriteAllText(_stringBuilder.ToString(), _jsonData);

            AssetDatabase.Refresh();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
        return true;
    }

    public static string GetTableName(OPTION_LANGUAGE _type)
    {
        string _retval = string.Empty;

        switch (_type)
        {
            case OPTION_LANGUAGE.KOREAN:
                _retval = TABLENAME_DEFAULT_LOCALIZE + "_kor";
                break;
            case OPTION_LANGUAGE.ENGLISH:
                _retval = TABLENAME_DEFAULT_LOCALIZE + "_eng";
                break;
        }

        return _retval;
    }

    //public static void TestDataInput()
    //{
    //    LocalizeTable _data = new LocalizeTable();
    //    _data.localizeTableList = new List<LocalizeTableData>();
    //    _data.localizeTableList.Add(new LocalizeTableData(0, "Start"));
    //    _data.localizeTableList.Add(new LocalizeTableData(1, "Option"));
    //    _data.localizeTableList.Add(new LocalizeTableData(2, "Finish"));
    //    _data.localizeTableList.Add(new LocalizeTableData(3, "OK"));
    //    _data.localizeTableList.Add(new LocalizeTableData(4, "Cancel"));
    //    _data.localizeTableList.Add(new LocalizeTableData(5, "Option Window"));
    //    _data.localizeTableList.Add(new LocalizeTableData(6, "Sound"));
    //    _data.localizeTableList.Add(new LocalizeTableData(7, "On"));
    //    _data.localizeTableList.Add(new LocalizeTableData(8, "Off"));
    //    _data.localizeTableList.Add(new LocalizeTableData(9, "Localize"));
    //    _data.localizeTableList.Add(new LocalizeTableData(10, "Korean"));
    //    _data.localizeTableList.Add(new LocalizeTableData(11, "English"));
    //    _data.localizeTableList.Add(new LocalizeTableData(12, "Close"));
    //    _data.localizeTableList.Add(new LocalizeTableData(13, "Do you wanna Exit Game ?"));

    //    Set(GetTableName(OPTION_LANGUAGE.ENGLISH), _data);

    //    _data.localizeTableList.Clear();
    //    _data.localizeTableList.Add(new LocalizeTableData(0, "시작"));
    //    _data.localizeTableList.Add(new LocalizeTableData(1, "설정"));
    //    _data.localizeTableList.Add(new LocalizeTableData(2, "종료"));
    //    _data.localizeTableList.Add(new LocalizeTableData(3, "확인"));
    //    _data.localizeTableList.Add(new LocalizeTableData(4, "취소"));
    //    _data.localizeTableList.Add(new LocalizeTableData(5, "설정 화면"));
    //    _data.localizeTableList.Add(new LocalizeTableData(6, "사운드"));
    //    _data.localizeTableList.Add(new LocalizeTableData(7, "켜기"));
    //    _data.localizeTableList.Add(new LocalizeTableData(8, "끄기"));
    //    _data.localizeTableList.Add(new LocalizeTableData(9, "언어 설정"));
    //    _data.localizeTableList.Add(new LocalizeTableData(10, "한국어"));
    //    _data.localizeTableList.Add(new LocalizeTableData(11, "영어"));
    //    _data.localizeTableList.Add(new LocalizeTableData(12, "닫기"));
    //    _data.localizeTableList.Add(new LocalizeTableData(13, "게임을 종료 하시겠습니까 ?"));
    //    Set(GetTableName(OPTION_LANGUAGE.KOREAN), _data);
    //}
}







//void TestLoad(string _tableName)
//{
//    StringBuilder _stringBuilder = new StringBuilder();
//    _stringBuilder.Append(Path.Combine(Application.dataPath, PATH_TABLE))
//        .Append(_tableName).Append(".json");

//    string _jsonData = File.ReadAllText(_stringBuilder.ToString());
//    LocalizeTable _data = JsonUtility.FromJson<LocalizeTable>(_jsonData);
//}
//void TestDataInput()
//{
//    LocalizeTable _data = new LocalizeTable();
//    _data.localizeTableList = new List<LocalizeTableData>();
//    _data.localizeTableList.Add(new LocalizeTableData(0, "안녕하세요."));
//    _data.localizeTableList.Add(new LocalizeTableData(1, "김실버입니다."));

//    string _path = Application.dataPath + "/" + PATH_TABLE + "Localize.json";
//    string _jsonData = JsonUtility.ToJson(_data, true);
//    File.WriteAllText(_path, _jsonData);

//    AssetDatabase.Refresh();
//}