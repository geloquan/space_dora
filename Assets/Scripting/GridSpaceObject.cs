using UnityEngine;

public class GridSpaceObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Grid grid;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        grid = GetComponent<Grid>();
        if (spriteRenderer == null || grid == null)
        {
            Debug.LogError("SpriteRenderer or Grid not assigned.");
            return;
        }

        Bounds spriteBounds = spriteRenderer.bounds;
        Vector3 cellSize = grid.cellSize;

        int minX = Mathf.FloorToInt((spriteBounds.min.x - grid.transform.position.x) / cellSize.x);
        int minY = Mathf.FloorToInt((spriteBounds.min.y - grid.transform.position.y) / cellSize.y);
        int maxX = Mathf.CeilToInt((spriteBounds.max.x - grid.transform.position.x) / cellSize.x);
        int maxY = Mathf.CeilToInt((spriteBounds.max.y - grid.transform.position.y) / cellSize.y);

        int cellCount = (maxX - minX) * (maxY - minY);
        Debug.Log("Number of intersecting cells: " + cellCount);
    }
}
