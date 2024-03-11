using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class JsonCreateEditor : EditorWindow
{
    string selectPath = string.Empty;
    string displayPath = TableManager.PATH_TABLE;

    // 생성하려는 파일 이름
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

        //폴더를 선택했다.
        if (!string.IsNullOrEmpty(_selectPath))
        {
            //현재 프로젝트 안의 경로라면,
            if (_selectPath.Contains(Application.dataPath))
            {
                // Assets 이후 경로만 표시.
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