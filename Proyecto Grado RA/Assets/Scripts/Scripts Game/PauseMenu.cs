using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIspaused = false;
    public GameObject pausedPanelMenu;
    public GameObject pauseButtonUI;
    
    
    private string sceneMenu = "Menu";
    
    
    // Update is called once per frame
    void Update()
    {
       /* if (GameIspaused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }*/
    }
    public void Resume()
    {
        pausedPanelMenu.SetActive(false);
        pauseButtonUI.SetActive(true);
        Time.timeScale = 1f;
        GameIspaused = false;
    }
    public void Pause()
    {
        pausedPanelMenu.SetActive(true);
        pauseButtonUI.SetActive(false);
        Time.timeScale = 0f;
        GameIspaused = true;
    }

    public void LoadMenu()
    {
        //Verificar el time en caso de que el juego siga en pause si se inicia de nuevo o simplemente borrarlo si todo funciona normal
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneMenu);
    }

    public void QuitGame()
    {
        Debug.Log("El juego se cerro");
        Application.Quit();
    }
}
