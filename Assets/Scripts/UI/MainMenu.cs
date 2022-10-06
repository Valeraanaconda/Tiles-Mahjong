using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        playButton.onClick.AddListener(()=>soundManager.PlaySound(AudioType.Click));
    }
    
    public void HideMainMenu()
    {
        gameObject.SetActive(false);
    }

    public void ActiveMainMenu()
    {
        gameObject.SetActive(true);
    }
}
