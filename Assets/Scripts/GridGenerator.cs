using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    private int rows;
    private int columns;
    private int areaOfInterest;
    
    [SerializeField] private GameObject[,] grid;
    [SerializeField] private CanvasScaler canvasScalar;
    [SerializeField] private GameObject gridParent;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private TileManager tileManager;

    private void Start()
    {
        getRowAndColumns();
        applySafeArea();
        generateGrid();
    }

    private void getRowAndColumns()
    {
        rows = PlayerPrefs.GetInt("rowCount");
        columns = PlayerPrefs.GetInt("columnCount");
        areaOfInterest = PlayerPrefs.GetInt("aoiCount");
        grid = new GameObject[rows, columns];
        tileManager.totalRows = rows;
        tileManager.totalColumns = columns;
        tileManager.areaOfInterest = areaOfInterest;
    }

    private void applySafeArea()
    {
        canvasScalar.referenceResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        RectTransform panelRt = panel.GetComponent<RectTransform>();
        RectTransform gridRt = gridParent.GetComponent<RectTransform>();
        panelRt.sizeDelta = new Vector2(Screen.currentResolution.width, Screen.safeArea.height);
        panelRt.anchoredPosition = new Vector3(0f, (Screen.safeArea.y - (Screen.currentResolution.height - Screen.safeArea.height)), 0f);
        gridRt.sizeDelta = new Vector2(panelRt.sizeDelta.x, panelRt.sizeDelta.y);
    }

    private void generateGrid()
    {
        int tileNum = 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grid[i, j] = Instantiate(tilePrefab, gridParent.transform);
                grid[i, j].GetComponent<Tile>().tileNumber = tileNum;
                grid[i, j].GetComponent<Tile>().row = i;
                grid[i, j].GetComponent<Tile>().col = j;
                RectTransform rt = gridParent.GetComponent<RectTransform>();
                gridParent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(rt.sizeDelta.x / columns, rt.sizeDelta.y / rows);
                tileNum++;
            }
        }
        tileManager.grid = grid;
    }
}
