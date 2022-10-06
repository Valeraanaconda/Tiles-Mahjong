using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public MainMenu mainMenu;
    public VictoryScreen victoryScreen;
    public DefeatScreen defeatScreen;

    public void ShowMainMenu()
    {
        mainMenu.ActiveMainMenu();
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.ActiveVictoryScreen();
    }

    public void ShowDefeatScreen()
    {
        defeatScreen.ActiveDefeatScreen();
    }
}