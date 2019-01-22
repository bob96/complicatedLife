using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

    private int levelToLoad;


    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        SceneManager.LoadScene(levelToLoad);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
    }

}
