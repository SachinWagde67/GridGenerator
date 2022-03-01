using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public class Corners
    {
       public int i, j;
       public Corners(int r, int c)
       {
            i = r;
            j = c;
       }
    }
    public int tileNumber;
    public int row;
    public int col;
    public Image tileImage;
    public Button tileBtn;
    public TextMeshProUGUI tileText;

    private TileManager tileManager;

    private void Start()
    {
        tileBtn.onClick.AddListener(onTileClick);
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        tileManager = this.gameObject.GetComponentInParent<TileManager>();
    }

    public void onTileClick()
    {
        Corners TL = new Corners((row - tileManager.areaOfInterest) < 0 ? 0 : (row - tileManager.areaOfInterest), (col - tileManager.areaOfInterest) < 0 ? 0 : (col - tileManager.areaOfInterest));
        Corners TR = new Corners((row - tileManager.areaOfInterest) < 0 ? 0 : (row - tileManager.areaOfInterest), (col + tileManager.areaOfInterest) >= tileManager.totalColumns ? tileManager.totalColumns - 1 : (col + tileManager.areaOfInterest));
        Corners BL = new Corners((row + tileManager.areaOfInterest) >= tileManager.totalRows ? tileManager.totalRows - 1 : (row + tileManager.areaOfInterest), (col - tileManager.areaOfInterest) < 0 ? 0 : (col - tileManager.areaOfInterest));
        Corners BR = new Corners((row + tileManager.areaOfInterest) >= tileManager.totalRows ? tileManager.totalRows - 1 : (row + tileManager.areaOfInterest), (col + tileManager.areaOfInterest) >= tileManager.totalColumns ? tileManager.totalColumns - 1 : (col + tileManager.areaOfInterest));

        for (int i = TL.i; i <= BL.i; i++)
        {
            for (int j = TL.j; j <= BR.j; j++)
            {
                tileManager.openAdjacentTile(i, j);
            }
        }
    }
}
