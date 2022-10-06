using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Tile : MonoBehaviour
{
    public TileType tileType;
    public ClickableState clickableState;
    public SpriteRenderer backgroundSpriteRenderer;
    public SpriteRenderer tileSpriteRenderer;
    public Container container;
    public bool isActiveTile;
    
    private int _tileLayerMask;
    private float _raycastDistance;

    private void Start()
    {
        _tileLayerMask = LayerMask.GetMask("NotActiveTile");
        isActiveTile = clickableState == ClickableState.clickable;
        tileSpriteRenderer = GetComponent<SpriteRenderer>();
        _raycastDistance = 1f;
    }

    private void OnMouseDown()
    {
        if (isActiveTile)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, _raycastDistance, _tileLayerMask);

            if (hit.collider != null)
            {
                var hitTile = hit.collider.gameObject.GetComponent<Tile>();
                hitTile.MakeClickableTile();
                hitTile.ChangeColor();
                
                this.MakeNotClickableTile();
                container.AddTileInContainer(this);
            }
            else
            {
                ChangeColor();
                MakeNotClickableTile();
                container.AddTileInContainer(this);
            }
        }
    }

    private void MakeClickableTile()
    {
        clickableState = ClickableState.clickable;
        isActiveTile = true;
    }

    private void MakeNotClickableTile()
    {
        clickableState = ClickableState.notClickable;
        isActiveTile = false;
    }

    private void ChangeColor()
    {
        tileSpriteRenderer.color = Color.white;
        backgroundSpriteRenderer.color = Color.white;
    }
}