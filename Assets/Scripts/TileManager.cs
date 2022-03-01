using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] public GameObject[,] grid;
    [HideInInspector] public int totalRows;
    [HideInInspector] public int totalColumns;
    [HideInInspector] public int areaOfInterest;

    public void openAdjacentTile(int r, int c)
    {
        grid[r, c].GetComponent<Tile>().tileImage.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        grid[r, c].GetComponent<Tile>().tileText.text = (grid[r,c].GetComponent<Tile>().tileNumber).ToString();
        grid[r, c].GetComponent<Tile>().tileText.gameObject.SetActive(true);
    }
}
