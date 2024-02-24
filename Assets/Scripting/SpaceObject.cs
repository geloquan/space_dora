using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{  
    public Bounds bounds;
    public SpriteRenderer spriteRenderer;
    float minX;
    float maxX;
    float minY;
    float maxY;
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        bounds = spriteRenderer.sprite.bounds;
        
    }
}
