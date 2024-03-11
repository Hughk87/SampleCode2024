using UnityEngine;
using UnityEditor;

public class EditorUtilityMenu : MonoBehaviour
{
    [MenuItem("Utility/Json Creator")]
    static void OpenJsonCreator()
    {
        Debug.Log("EditorUtility.OpenJsonCreator()");
        JsonCreateEditor _editorWindow = (JsonCreateEditor)EditorWindow.GetWindow(typeof(JsonCreateEditor), false, "Json Creator");
        _editorWindow.Show();
    }
}
