using UnityEngine;
using UnityEngine.UI;

public class Editor : MonoBehaviour
{
    private float red, green, blue;
    public bool isEditorEnabled = false;
    public bool isObjectListOpen = false;
    public GameObject hospital,
                      pallete,
                      dropdownList,
                      player,
                      objectList,
                      itemsGrid,
                      itemsHeader,
                      editorCanvas;
    private Dropdown materialsDropdown;
    private Material[] hospitalMaterialList;
    private Image backgroundColor;
    private Material paint;
    private PlayerMove playerMove;
    private PlayerView playerView;
    
    void Start()
    {
        editorCanvas.SetActive(false);
        playerMove = player.GetComponent<PlayerMove>();
        playerView = player.GetComponent<PlayerView>();
        GetAndLoadMaterials();
    }

    void Update()
    {
        EditMode();
    }

    private void EditMode()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isEditorEnabled = !isEditorEnabled;
        }

        if (isEditorEnabled)
        {
            editorCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerView.enabled = false;
            playerMove.enabled = false;
            ChangeColor();
        }
        else
        {
            editorCanvas.SetActive(false);
            playerView.enabled = true;
            playerMove.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void GetAndLoadMaterials()
    {
        hospitalMaterialList = hospital.GetComponent<MeshRenderer>().materials;
        materialsDropdown = dropdownList.GetComponent<Dropdown>();
        materialsDropdown.ClearOptions();
        for (int i = 0; i <= hospitalMaterialList.Length-1; i++ )
        {
            materialsDropdown.options.Add(new Dropdown.OptionData(){text = hospitalMaterialList[i].name});
        }
        DropDownValueChanged();
        materialsDropdown.value = 0;
        materialsDropdown.RefreshShownValue();
        materialsDropdown.onValueChanged.AddListener(delegate {DropDownValueChanged();});
    }
    private void ChangeColor()
    {   
        backgroundColor =  pallete.transform.GetComponent<Image>();
        backgroundColor.color = paint.color;
        red = pallete.transform.Find("Slider Red").GetComponent<Slider>().value;
        green = pallete.transform.Find("Slider Green").GetComponent<Slider>().value;
        blue = pallete.transform.Find("Slider Blue").GetComponent<Slider>().value;
        paint.color = new Color(red, green, blue);
    }

    private void DropDownValueChanged()
    {
       paint = hospitalMaterialList[materialsDropdown.value];
       pallete.transform.Find("Slider Red").GetComponent<Slider>().value = paint.color.r;
       pallete.transform.Find("Slider Green").GetComponent<Slider>().value = paint.color.g;
       pallete.transform.Find("Slider Blue").GetComponent<Slider>().value = paint.color.b;
       
    }

    public void OpenCloseObjectList()
    {
        if (isObjectListOpen)
        {
            itemsGrid.SetActive(false);
            itemsHeader.SetActive(false);
            isObjectListOpen = false;
            objectList.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 1080);
            objectList.transform.Find("OpenCloseButton").Find("Arrow").GetComponent<RectTransform>().Rotate(0, 0, -180);
        }
        else
        {   
            itemsGrid.SetActive(true);
            itemsHeader.SetActive(true);
            isObjectListOpen = true;
            objectList.GetComponent<RectTransform>().sizeDelta = new Vector2(1550, 1080);
            objectList.transform.Find("OpenCloseButton").Find("Arrow").GetComponent<RectTransform>().Rotate(0, 0, 180);
        }
    }

}

