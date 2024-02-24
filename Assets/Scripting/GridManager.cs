using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public GameObject cellPrefab;
    private GameObject[,] cells;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        cells = new GameObject[gridSizeX, gridSizeY];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 cellPosition = new Vector3(x, y, 0);
                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                cells[x, y] = cell;
            }
        }
    }

    private void SelectCell(int x, int y)
    {
        if (x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY)
        {
            GameObject selectedCell = cells[x, y];
            // Perform actions on the selected cell
            Debug.Log("Selected cell: " + selectedCell.name);
        }
        else
        {
            Debug.Log("Invalid cell selection");
        }
    }

    // Example usage: Selecting a cell at position (2, 3)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectCell(2, 3);
        }
    }
}
