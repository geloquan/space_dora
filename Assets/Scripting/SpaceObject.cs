using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{  
    public Bounds bounds;
    public SpriteRenderer spriteRenderer;
    public int planet_count;

    float minX;
    float maxX;
    float minY;
    float maxY;
    private void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        bounds = spriteRenderer.sprite.bounds;
        


    }
    void InitPlanets() {
        for (int i = 0; i < planet_count; i++) {
            place_asteroids();
        }
    }
}
