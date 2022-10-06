using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;
    public Level currentLevel;
    public GameObject levelGameObject;
    public List<Tile> currentLevelTiles;
    public GameController gameController;

    public void CreateLevel()
    {
        var levelNum = levels.First(l => !l.isCompleteLevel).levelNumber;

        var level = levels.Find(level => level.levelNumber == levelNum);
        levelGameObject = Instantiate(level.levelPrefab);
        currentLevelTiles = levelGameObject.GetComponent<Level>().tiles;
        currentLevel = level;
    }

    public void CompleteLevel()
    {
        Destroy(levelGameObject);
        
        bool allLevelComplete = levels.All(l => l.isCompleteLevel);
        if (allLevelComplete)
        {
            gameController.EndGame();
            return;
        }

        CreateLevel();
    }

    public void ReloadLevel()
    {
        currentLevel.tileContainer.ClearContainer();
        Destroy(levelGameObject);
        CreateLevel();
    }

    public void MakeTilesAnClickable()
    {
        foreach (var tile in currentLevelTiles)
        {
            tile.isActiveTile = false;
        }
    }
    public void MakeTilesClickable()
    {
        foreach (var tile in currentLevelTiles)
        {
            if (tile.clickableState == ClickableState.clickable)
            {
                tile.isActiveTile = true;
            }
            else
            {
                tile.isActiveTile = false;
            }
        }
    }
  
    public void CompleteCurrentLevel()
    {
        currentLevel.isCompleteLevel = true;
    }

    public void ResetLevelComplete()
    {
        foreach (var level in levels)
        {
            level.isCompleteLevel = false;
        }
    }
}
