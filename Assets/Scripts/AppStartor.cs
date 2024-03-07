using UnityEngine;

/// <summary>
/// 어플리 케이션 최초 시작시 1회만 사용되는 스크립트
/// </summary>

public class AppStartor : MonoBehaviour
{
    void Awake()
    {
        GameManager.Instance.Initialize();
        Destroy(this.gameObject);
    }
}
