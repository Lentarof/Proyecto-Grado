using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void PlayGame() 
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
        SceneManager.LoadScene("Game");
    }
    public void GalleryGame()
    {
        SceneManager.LoadScene("Gallery");
    }    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EraseObject()
    {
        
    }

}
