using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private MusicScriptableObject _audioStore;
    [SerializeField] private AudioSource _audioSource;
    
    public void PlaySound(AudioType audioType)
    {
        _audioSource.clip = _audioStore.GetAudioClipByType(audioType);
        _audioSource.Play();
    }
}
