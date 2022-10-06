using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        continueButton.onClick.AddListener(()=>soundManager.PlaySound(AudioType.Click));
    }
    public void HideVictoryScreen()
    {
        gameObject.SetActive(false);
    }

    public void ActiveVictoryScreen()
    {
        gameObject.SetActive(true);
    }
}
