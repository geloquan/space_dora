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
    public Vector2 spriteSize;
    public Vector3 gridCellSize;
    public Grid grid;
    private PlanetObject refPlanetObject;
    private PlanetOrg refPlanetOrg;
    private PlayerObject refPlayerObject;
    private Transform refPlayerObjectTransform;
    private Grid refPlayerObjectGrid;
    private Vector3Int refPlayerObjectGridPosition;
    public Bounds boundsSpaceObject;

    public List<Vector3> planetPositions;


    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bounds = spriteRenderer.bounds;
        grid = GetComponent<Grid>();

        refPlanetOrg = FindObjectOfType<PlanetOrg>();

        refPlayerObject = FindObjectOfType<PlayerObject>();
        refPlayerObjectTransform = refPlayerObject.transform;
        refPlayerObjectGrid = refPlayerObject.GetComponent<Grid>();
        refPlayerObjectGridPosition = grid.WorldToCell(refPlayerObjectTransform.position);


        minX = bounds.min.x; minY = bounds.min.y; maxX = bounds.max.x; maxY = bounds.max.y;

        planet_count = 10;

        gridCount = CountGridsInGameObject();
        Debug.Log(planet_count);
        Debug.Log("gridCount : " + gridCount);
        InitPlanets();

    }
    void Update() {
        refPlayerObjectTransform = refPlayerObject.transform;
        refPlayerObjectGrid = refPlayerObject.GetComponent<Grid>();
        refPlayerObjectGridPosition = grid.WorldToCell(refPlayerObjectTransform.position);
        Debug.Log($"PlayerObject is in grid cell X: {refPlayerObjectGridPosition.x}, Y: {refPlayerObjectGridPosition.y}");
    }
    public void HoveringAt(Vector3 playerPosition) {

    }
    void InitPlanets() {
        planetPositions = new List<Vector3>();
        for (int i = 0; i < planet_count; i++) {
            planetPositions.Add(refPlanetOrg.NewPlanet());
        }
    }
    int CountGridsInGameObject() {
        spriteSize = spriteRenderer.sprite.bounds.size;
        gridCellSize = grid.cellSize;
        Grid[] grids = GetComponents<Grid>();
        int cellsInX = Mathf.CeilToInt(spriteSize.x / gridCellSize.x);
        int cellsInY = Mathf.CeilToInt(spriteSize.y / gridCellSize.y);

        Debug.Log($"Sprite occupies {cellsInX} cells in X direction and {cellsInY} cells in Y direction.");

        return cellsInX * cellsInY;
    }
}
