using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
    public Button[] UIButtons;
    System.Action<int> delegateChangeSelect = null;
    int indexActive = -1;

    public void Initialize(System.Action<int> _delegateChangeSelect,int _indexActive)
    {
        delegateChangeSelect = _delegateChangeSelect;
        indexActive = _indexActive;
        OnClickButton(indexActive);
    }

    public void OnClickButton(int _index)
    {
        if(indexActive != -1)
            UIButtons[indexActive].interactable = true;

        UIButtons[_index].interactable = false;

        indexActive = _index;

        if(delegateChangeSelect != null)
            delegateChangeSelect(_index);
    }
}
