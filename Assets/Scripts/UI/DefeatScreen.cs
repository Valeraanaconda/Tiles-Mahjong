using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        retryButton.onClick.AddListener(()=>soundManager.PlaySound(AudioType.Click));
    }

    public void HideDefeatScreen()
    {
        gameObject.SetActive(false);
    }

    public void ActiveDefeatScreen()
    {
        gameObject.SetActive(true);
    }
}
