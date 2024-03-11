using TMPro;
using UnityEngine;

public class LocalizeText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int key;

    private void Awake()
    {
        if (text == null)
            text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ApplyText();
    }

    public void ApplyText()
    {
        if (text != null)
            text.text = LocalizeManager.Instance.GetText(key);
    }
}
