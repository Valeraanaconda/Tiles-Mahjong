using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioStore")]
public class MusicScriptableObject : ScriptableObject
{
    [SerializeField] private AudioField[] _audioField;

    public AudioClip GetAudioClipByType(AudioType audioType)
    {
        return _audioField.First(s => s.audioType == audioType).audioClip;
    }
}

[System.Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}