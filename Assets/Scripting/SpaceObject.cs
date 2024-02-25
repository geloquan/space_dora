using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour {  

    public Bounds bounds;
    public SpriteRenderer spriteRenderer;
    public int planet_count;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int gridCount;

    private PlanetObject refPlanetObject;
    private PlanetOrg refPlanetOrg;
    public Bounds boundsSpaceObject;


    private void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        refPlanetOrg = FindObjectOfType<PlanetOrg>();
        bounds = spriteRenderer.bounds;
        minX = bounds.min.x;
        minY = bounds.min.y;
        maxX = bounds.max.x;
        maxY = bounds.max.y;

        planet_count = 10;

        gridCount = CountGridsInGameObject(gameObject);
        Debug.Log(planet_count);
        InitPlanets();


    }
    void InitPlanets() {
        for (int i = 0; i < planet_count; i++) {
            refPlanetOrg.NewPlanet();
        }
    }
    int CountGridsInGameObject(GameObject obj) {
        Grid[] grids = obj.GetComponents<Grid>();
        return grids.Length;
    }
}
