using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_asteroids : MonoBehaviour
{
    
    private int asteroid_count = 40;
    void Start() {
        for (int i = 0; i < asteroid_count; i++) {
            place_asteroids();
        }
    }
    void place_asteroids()
    {
        SpaceObject spaceObject = FindObjectOfType<SpaceObject>();
        Sprite asteroidSprite = Resources.Load<Sprite>("asteroid");

        if (asteroidSprite != null)
        {
            Bounds objectBounds = spaceObject.bounds;
            float minX = objectBounds.min.x;
            float maxX = objectBounds.max.x;
            float minY = objectBounds.min.y;
            float maxY = objectBounds.max.y;

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            GameObject spriteObject2 = new GameObject("Sprite2");
            SpriteRenderer spriteRenderer2 = spriteObject2.AddComponent<SpriteRenderer>();
            spriteRenderer2.sprite = asteroidSprite;
            spriteRenderer2.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            spriteObject2.transform.position = new Vector3(randomX, randomY, 0f);

        }
        else
        {
            Debug.LogError("Failed to load the asteroid sprite from Resources.");
        }
    }
}