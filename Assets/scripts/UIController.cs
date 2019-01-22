using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject gameOverPannel;
    public GameObject pausePannel;
    //public GameObject optionMenu;
    public static UIController instance;
    public Text scoreText;
    public Text goodText;
    public Text badText;
    public Text nodeText;
    public Text levelText;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = new UIController();
        }
    }

    private void Update()
    {
        scoreText.text = "Score : " + PlayerController.score;
        goodText.text = Core.goodNodeCount.ToString();
        badText.text = Core.badNodeCount.ToString();
        nodeText.text = Core.nodeCount.ToString();
        levelText.text = "Level : " + GameController.level.ToString();
    }

    private void PauseGame(GameObject pannel)
    {
        Time.timeScale = 0;

        pannel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }

    private void UnpauseGame(GameObject pannel)
    {
        Time.timeScale = 1;

        pannel.SetActive(false);
    }

    public void PausePannel()
    {
        PauseGame(pausePannel);
    }

    public void GameOverPannel()
    {
        PauseGame(gameOverPannel);
    }

    public void UnPausePannel()
    {
        UnpauseGame(gameOverPannel);
        UnpauseGame(pausePannel);
    }


}
