using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public UnityEngine.UI.Button playButton;
    public GameObject panel0110;
    public GameObject panel1120;
    public GameObject panel2125;
    public GameObject panelMain;
    public GameObject panelPausa;
    public GameObject panelHUD;
    public GameObject panelLose;
    public GameObject pauseButton;
    public GameObject quitButton;
    public GameObject pauseMsj;
    public GameObject textIntro;
    private GameManager gameController;


    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameController = this.GetComponent<GameManager>();

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            quitButton.SetActive(true);
            //Debug.LogError("Enabling quit button");
        }
        else
        {
            //Debug.LogError("Disabling quit button");
            quitButton.SetActive(false);
        }
    }

    public void PauseToggle()
    {
        gameController.paused = !gameController.paused;
    }

    public void ContinueGame()
    {
        StartCoroutine("ContinuePlaying");
    }

    IEnumerator ContinuePlaying()
    {
        //Debug.LogError("time scale 1 IN UI");
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
        panelHUD.SetActive(true);
        pauseButton.SetActive(true);
        pauseMsj.SetActive(true);
        textIntro.SetActive(true);
        yield return new WaitForSeconds(2);
        textIntro.SetActive(false);
        gameController.Paused = false;
        gameController.playingLevel = true;
        pauseMsj.SetActive(false);
    }

    public void PauseMenu()
    {
        gameController.playingLevel = false;
        panelPausa.SetActive(true);
        pauseButton.SetActive(false);
        panelHUD.SetActive(false);
        pauseMsj.SetActive(false);
        gameController.Paused = true;
    }

    public void QuitGame()
    {
        Debug.LogError(" QUIT GAME in Windows ");
        Application.Quit();
    }


    public void StartGame()
    {
        StartCoroutine("StartLevel");
    }

    IEnumerator StartLevel()
    {
        playButton.interactable = false;
        panelPausa.SetActive(false);
        panelMain.SetActive(false);
        panelHUD.SetActive(true);
        textIntro.SetActive(true);
        textIntro.GetComponent<TMPro.TextMeshProUGUI>().text = "GET READY...";
        yield return new WaitForSeconds(2);
        textIntro.SetActive(false);        
    }

    public void LoadGameMenu()
    {
        gameController.Paused = false;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void LoseMenu()
    {
        gameController.playingLevel = false;
        panelPausa.SetActive(false);
        pauseButton.SetActive(false);
        panelHUD.SetActive(false);
        pauseMsj.SetActive(false);
        panelLose.SetActive(true);
        textIntro.SetActive(true);
        textIntro.GetComponent<TMPro.TextMeshProUGUI>().text = "YOU LOSE";
    }
}