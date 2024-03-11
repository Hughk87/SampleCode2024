
using UnityEngine;

public static class Extension_Monobehaviour
{
    public static void ApplyLauguageInChildren(this MonoBehaviour _script)
    {
        LocalizeText[] _getComponents = _script.transform.GetComponentsInChildren<LocalizeText>();
        for (int i = 0; i < _getComponents.Length; i++)
            _getComponents[i].ApplyText();
    }
}
