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
}