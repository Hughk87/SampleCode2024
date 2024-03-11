using UnityEngine;

public class TestManager_FindGetComponent : MonoBehaviour
{
    const float WIDTH = 200f;
    const float HEIGHT = 100f;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, WIDTH, HEIGHT), "Find"))
        {
            TestComponent[] _components = GameObject.FindObjectsOfType<TestComponent>();
            Debug.Log(_components.Length);
        }
        if (GUI.Button(new Rect(WIDTH, 0, WIDTH, HEIGHT), "GetComponent"))
        {
            TestComponent[] _components = this.transform.GetComponentsInChildren<TestComponent>();
            Debug.Log(_components.Length);
        }
    }
}
