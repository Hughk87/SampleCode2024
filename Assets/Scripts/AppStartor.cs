using UnityEngine;

/// <summary>
/// ���ø� ���̼� ���� ���۽� 1ȸ�� ���Ǵ� ��ũ��Ʈ
/// </summary>

public class AppStartor : MonoBehaviour
{
    void Awake()
    {
        GameManager.Instance.Initialize();
        Destroy(this.gameObject);
    }
}
