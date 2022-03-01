using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private CanvasScaler canvasScalar;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gridTxt;
    [SerializeField] private Slider rowSlider;
    [SerializeField] private TextMeshProUGUI rowNumTxt;
    [SerializeField] private Slider columnSlider;
    [SerializeField] private TextMeshProUGUI columnNumTxt;
    [SerializeField] private Slider areaOfInterestSlider;
    [SerializeField] private TextMeshProUGUI areaOfInterestNumTxt;

    private int rowCount;
    private int columnCount;
    private int areaOfInterestCount;
    private int relativePos;
    
    public Button generateBtn;

    private void Start()
    {
        applySafeArea();
        generateBtn.onClick.AddListener(LoadNextScene);
        rowSlider.onValueChanged.AddListener(rowValueCount);
        columnSlider.onValueChanged.AddListener(columnValueCount);
        areaOfInterestSlider.onValueChanged.AddListener(areaOfInterestValueCount);
    }

    private void areaOfInterestValueCount(float aoi)
    {
        areaOfInterestNumTxt.text = aoi.ToString();
        areaOfInterestCount = (int)aoi;
        PlayerPrefs.SetInt("aoiCount", areaOfInterestCount);
    }

    private void columnValueCount(float col)
    {
        columnNumTxt.text = col.ToString();
        columnCount = (int)col;
        PlayerPrefs.SetInt("columnCount", columnCount);
    }

    private void rowValueCount(float row)
    {
        rowNumTxt.text = row.ToString();
        rowCount = (int)row;
        PlayerPrefs.SetInt("rowCount", rowCount);
    }

    private void applySafeArea()
    {
        canvasScalar.referenceResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        RectTransform panelRt = panel.GetComponent<RectTransform>();
        panelRt.sizeDelta = new Vector2(Screen.currentResolution.width, Screen.safeArea.height);
        panelRt.anchoredPosition = new Vector3(0f, (Screen.safeArea.y - (Screen.currentResolution.height - Screen.safeArea.height)), 0f);
        relativePos = (int)panelRt.sizeDelta.y / 6;

        gridTxt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (-1 * relativePos * 1));
        gridTxt.GetComponent<RectTransform>().sizeDelta = new Vector2(((panelRt.sizeDelta.x / 100) * 80), (panelRt.sizeDelta.x / 100) * 20);
        
        rowNumTxt.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (-1 * relativePos * 2));
        rowNumTxt.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(((panelRt.sizeDelta.x / 100) * 80), rowNumTxt.transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        columnNumTxt.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (-1 * relativePos * 3));
        columnNumTxt.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(((panelRt.sizeDelta.x / 100) * 80), rowNumTxt.transform.parent.GetComponent<RectTransform>().sizeDelta.y);
        
        areaOfInterestNumTxt.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (-1 * relativePos * 4));
        areaOfInterestNumTxt.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(((panelRt.sizeDelta.x / 100) * 80), rowNumTxt.transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        generateBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (-1 * relativePos * 5));
        generateBtn.GetComponent<RectTransform>().sizeDelta = new Vector2(((panelRt.sizeDelta.x / 100) * 60), generateBtn.GetComponent<RectTransform>().sizeDelta.y);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
