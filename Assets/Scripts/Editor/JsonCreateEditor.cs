using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class JsonCreateEditor : EditorWindow
{
    string selectPath = string.Empty;
    string displayPath = TableManager.PATH_TABLE;

    // �����Ϸ��� ���� �̸�
    string fileName  = string.Empty;

    void OnGUI()
    {
        Color oldColor = GUI.backgroundColor;

        GUILayout.Space(10);

        GUILayout.Label("Selected Folder");
        using (new EditorGUI.DisabledScope(true))
        {
            GUILayout.TextArea(displayPath, (int)this.position.width, GUILayout.ExpandWidth(true));
        }

        GUILayout.Space(5);
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Change"))
            ChangeFolder();
        if (GUILayout.Button("Reset"))
            ResetFolder();
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
        fileName = EditorGUILayout.TextField("FileName", fileName);

        GUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.green;

        if (GUILayout.Button("Create")) 
            Create();

        GUI.backgroundColor = oldColor;
        EditorGUILayout.EndHorizontal();
    }
    void Create()
    {
        string _createJsonPath = string.Format("{0}/{1}.json", selectPath, fileName);
        try
        {
            FileStream fileStream = new FileStream(_createJsonPath, FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(string.Empty);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
            return;
        }

        Debug.Log("Create Json Success : "+ _createJsonPath);
        AssetDatabase.Refresh();
    }


    void ChangeFolder()
    {
        string _selectPath = EditorUtility.SaveFolderPanel("Select Folder", selectPath, "");

        //������ �����ߴ�.
        if (!string.IsNullOrEmpty(_selectPath))
        {
            //���� ������Ʈ ���� ��ζ��,
            if (_selectPath.Contains(Application.dataPath))
            {
                // Assets ���� ��θ� ǥ��.
                string[] _strings = _selectPath.Split("Assets/");
                displayPath = _strings[1] + "/";
            }
            else
                displayPath = _selectPath + "/";

            selectPath = _selectPath;
        }
    }
    void ResetFolder()
    {
        displayPath = TableManager.PATH_TABLE;
        selectPath = Application.dataPath +"/" +TableManager.PATH_TABLE;
    }
}