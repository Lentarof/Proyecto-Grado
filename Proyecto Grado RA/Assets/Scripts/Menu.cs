using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    private string scenegame = "Virus";
    private string scenegallery = "Gallery";
    private string scenemenu = "Menu";
    public void PlayGame() 
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
        SceneManager.LoadScene(scenegame);
    }
    public void GalleryGame()
    {
        SceneManager.LoadScene(scenegallery);
    }    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(scenemenu);
    }
    

}
