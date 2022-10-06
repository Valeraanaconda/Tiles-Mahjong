using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<Tile> tiles;
    public TileMover tileMover;

    public GameController _gameController;
    private SpriteRenderer _spriteRenderer;
    private int _maxContainerSize = 7;
    private Tile pickedTile;
    private LevelManager _levelManager;
    
    public void OnEnable()
    {
        _gameController = (GameController) FindObjectOfType(typeof(GameController));
        _levelManager = (LevelManager) FindObjectOfType(typeof(LevelManager));
    }

    public void AddTileInContainer(Tile tile)
    {
        _gameController.soundManager.PlaySound(AudioType.Click);
        _levelManager.MakeTilesAnClickable();
        pickedTile = tile;
        tiles.Add(tile);
        if (tiles.Count <= _maxContainerSize)
        {
            tileMover.MoveTileInContainer(tile, tiles.Count);
            _levelManager.currentLevelTiles.Remove(tile);
            if (tiles.Count == _maxContainerSize && CheckForMatches() == false)
            {
                _gameController.LoseGame();
            }
        }
    }

    private void RemoveTileInContainer(Tile tile)
    {
        tiles.Remove(tile);
        _levelManager.currentLevelTiles.Remove(tile);
        Destroy(tile.gameObject);
    }

    public bool CheckForMatches()
    {
        int tileCount = (from t in tiles
            where t.tileType == pickedTile.tileType
            select t).Count();

        if (tileCount == 3)
        {
            for (var index = tiles.Count - 1; index >= 0; index--)
            {
                if (tiles[index].tileType == pickedTile.tileType)
                {
                    RemoveTileInContainer(tiles[index]);
                }
            }

            tileMover.ResizeTilesInContainer(tiles);
            
            if (_levelManager.currentLevelTiles.Count == 0)
            {
                _gameController.WinGame();
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearContainer()
    {
        for (var index = tiles.Count - 1; index >= 0; index--)
        {
            RemoveTileInContainer(tiles[index]);
        }
    }
}