
using UnityEngine;

public static class Extension_EnumValue
{
    public static string GetAudioClipName(this SOUND_BGM _bgm)
    {
        string _retval = string.Empty;
        switch (_bgm)
        {
            case SOUND_BGM.BGM_FINEDINING:
                _retval = "BGM_FINEDINING";
                break;
            case SOUND_BGM.BGM_ONTHEROCKS:
                _retval = "BGM_ONTHEROCKS";
                break;

            case SOUND_BGM.NONE:
            default:
                Debug.LogError($"GetAudioClipName() :: {_bgm} :: ���ǵ��� ���� BGM Ÿ���Դϴ�!");
                break;
        }
        return _retval;
    }
    public static string GetAudioClipName(this SOUND_EFFECT _effect)
    {
        string _retval = string.Empty;
        switch (_effect)
        {
            case SOUND_EFFECT.EFF_MOUSECLICK:
                _retval = "EFF_MOUSECLICK";
                break;

            case SOUND_EFFECT.NONE:
            default:
                Debug.LogError($"GetAudioClipName() :: {_effect} :: ���ǵ��� ���� ȿ���� Ÿ���Դϴ�!");
                break;
        }
        return _retval;
    }
}
