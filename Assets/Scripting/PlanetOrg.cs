using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrg : MonoBehaviour {

    private Bounds boundsSpaceObject;

    public void NewPlanet() {
        GameObject new_planet = new GameObject("Planet");

        boundsSpaceObject = FindObjectOfType<SpaceObject>().bounds;

        SpriteRenderer spriteRenderer = new_planet.AddComponent<SpriteRenderer>();
        List<string> planet_imgs = new List<string> { "planet_1", "planet_2", "planet_3", "planet_4" };

        string random_planet_img = planet_imgs[Random.Range(0, planet_imgs.Count)];
        Sprite selectedSprite = Resources.Load<Sprite>(random_planet_img);
        spriteRenderer.sprite = selectedSprite;


        float space_minX = boundsSpaceObject.min.x;
        float space_maxX = boundsSpaceObject.max.x;
        float space_minY = boundsSpaceObject.min.y;
        float space_maxY = boundsSpaceObject.max.y;

        float randomX = Random.Range(space_minX, space_maxX);
        float randomY = Random.Range(space_minY, space_maxY);
        new_planet.transform.parent = FindObjectOfType<SpaceObject>().transform;

        new_planet.transform.position = new Vector3(randomX, randomY, -1f);
    }

    void Start() {
        
    }

}
