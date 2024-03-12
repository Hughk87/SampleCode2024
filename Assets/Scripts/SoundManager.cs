using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public AudioSource audioSourceEffect = null;
    public AudioSource audioSourceBGM = null;

    public override void Initialize(params object[] _object)
    {
        Debug.Log("SoundManager.Initialize()");

        GameObject _createObject = new GameObject("audioSourceBGM");
        _createObject.transform.SetParent(this.transform);
        _createObject.transform.localPosition = Vector3.zero;

        audioSourceBGM = _createObject.AddComponent<AudioSource>();
        audioSourceBGM.loop = true;

        _createObject = new GameObject("audioSourceEffect");
        _createObject.transform.SetParent(this.transform);
        _createObject.transform.localPosition = Vector3.zero;

        audioSourceEffect = _createObject.AddComponent<AudioSource>();
    }

    public void SetMute(bool _isMute)
    {
        audioSourceBGM.mute = _isMute;
        audioSourceEffect.mute = _isMute;
    }


    //BGM
    public void PlayBGM(SOUND_BGM _bgm)
    {
        AudioClip _audioClip = ResourcesManager.LoadAudioClip(_bgm.GetAudioClipName());
        audioSourceBGM.Stop();
        audioSourceBGM.clip = _audioClip;
        audioSourceBGM.Play();
    }

    //2d 효과음 재생
    public void PlayEffectSound(SOUND_EFFECT _effect)
    {
        AudioClip _audioClip = ResourcesManager.LoadAudioClip(_effect.GetAudioClipName());
        audioSourceBGM.PlayOneShot(_audioClip);
    }

    //// to do :: 3d 효과음 재생
    //public void PlayEffectSound3D()
    //{

    //}
}
