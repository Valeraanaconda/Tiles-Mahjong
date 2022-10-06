using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject levelPrefab;
    public List<Tile> tiles;
    public int levelNumber;
    public bool isCompleteLevel;
    public Container tileContainer;
}