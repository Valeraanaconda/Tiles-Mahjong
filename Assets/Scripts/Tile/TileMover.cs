using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    
    public Container container;
    public float offset = 0.65f;
    public float animationSpeed = 0.5f;
    
    private Vector3 tileContainerScale = new Vector3(0.57f, 0.62f, 0.72f);
    private LevelManager _levelManager;
    public void OnEnable()
    {
        _levelManager = (LevelManager) FindObjectOfType(typeof(LevelManager));
    }

    public void MoveTileInContainer(Tile tile, int tileCountInContainer)
    {
        Sequence tileMoveSequence = DOTween.Sequence();
        var tileTransform = tile.transform;
        tileTransform.SetParent(container.transform);
        tileMoveSequence.Append(tileTransform.DOLocalMove(new Vector3(-2.55f + offset * tileCountInContainer, 0, 0),
            animationSpeed));
        tileMoveSequence.Join(tileTransform.DOScale(tileContainerScale, animationSpeed));
        tileMoveSequence.OnComplete(() =>
        {
            container.CheckForMatches();
            _levelManager.MakeTilesClickable();
        });

        tile.backgroundSpriteRenderer.sortingOrder = 1;
        tile.tileSpriteRenderer.sortingOrder = 1;
    }

    public void ResizeTilesInContainer(List<Tile> tiles)
    {
        if (tiles.Count > 0)
        {
            int index = 0;
            foreach (var t in tiles)
            {
                index++;
                t.transform.DOLocalMove(new Vector3(-2.55f + offset * index, 0, 0),animationSpeed);
            }
        }
    }
}