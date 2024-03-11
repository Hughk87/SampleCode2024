using System.Collections.Generic;

[System.Serializable]
public abstract class TableBase
{
}


[System.Serializable]
public class LocalizeTable : TableBase
{
    public List<LocalizeTableData> localizeTableList;
}

[System.Serializable]
public class LocalizeTableData
{
    public int key;
    public string value;

    public LocalizeTableData(int _key, string _value)
    {
        key = _key;
        value = _value;
    }
}