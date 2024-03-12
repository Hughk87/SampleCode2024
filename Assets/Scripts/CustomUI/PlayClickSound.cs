using UnityEngine;
using UnityEngine.UI;

public class PlayClickSound : MonoBehaviour
{
    public SOUND_EFFECT type = SOUND_EFFECT.EFF_MOUSECLICK;
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(PlaySound);
    }
    void PlaySound()
    {
        SoundManager.Instance.PlayEffectSound(type);
    }
}
