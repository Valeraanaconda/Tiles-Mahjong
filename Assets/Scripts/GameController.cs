using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LevelManager LevelManager;
    public UIManager uiManager;
    public SoundManager soundManager;

    public void StartGame()
    {
        LevelManager.CreateLevel();
    }

    public void LoseGame()
    {
        uiManager.ShowDefeatScreen();
        soundManager.PlaySound(AudioType.Defeat);
    }

    public void WinGame()
    {
        uiManager.ShowVictoryScreen();
        LevelManager.CompleteCurrentLevel();
        soundManager.PlaySound(AudioType.Victory);

    }

    public void EndGame()
    {
        LevelManager.ResetLevelComplete();
        uiManager.victoryScreen.HideVictoryScreen();
        soundManager.PlaySound(AudioType.Victory);
        uiManager.ShowMainMenu();
    }
}