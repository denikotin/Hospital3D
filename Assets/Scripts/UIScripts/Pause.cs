using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject crosshair;
    public GameObject editorManager;
    public GameObject editModeUI;
    [SerializeField] KeyCode keyMenu;
    bool isMenuPaused = false;
    public PlayerView playerView;

    private void Start()
    {
        menuPause.SetActive(false);
    }

    void Update()
    {
        ActiveMenu();
    }

    void ActiveMenu()
    {
        if(Input.GetKeyDown(keyMenu))
        {
            isMenuPaused = !isMenuPaused;

        }
        
        if (isMenuPaused)
        {
            menuPause.SetActive(true);
            crosshair.SetActive(false);
            editorManager.SetActive(false);
            editModeUI.GetComponent<GraphicRaycaster>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerView.enabled = false;
            Time.timeScale = 0;

        }
        else
        {   
            menuPause.SetActive(false);
            crosshair.SetActive(true);
            editorManager.SetActive(true);
            editModeUI.GetComponent<GraphicRaycaster>().enabled = true;
            Time.timeScale = 1;
            playerView.enabled = true;
        }
    }

    public void MenuPauseContinue()
    {
        isMenuPaused = false;
    }

    public void MenuPausedExit()
    {
        
        Application.Quit();
        
    }

    public void MenuPausedMainMenu()
    {
        SceneManager.LoadScene(1);
    }

}
