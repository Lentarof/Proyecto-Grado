using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimerSlider : MonoBehaviour
{
    private Slider timerSlider;
    private TextMeshProUGUI timerText;

    public float gameTime;

    private Image fillImage;
    public Color32 normalFillColor;
    public Color32 warningFillColor;
    public float warningLimit; //como porcentaje
    
    public bool stopTimer;

    private TextMeshProUGUI gameOverText;
    
    void Start()
    {
        stopTimer = false;
        gameObject.GetComponent<Shoot>().enabled = true;

        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(false);

        timerSlider = GameObject.FindGameObjectWithTag("TimerSlider").GetComponent<Slider>();
        timerText =  GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();
        
        fillImage = GameObject.FindGameObjectWithTag("SliderFill").GetComponent<Image>();

        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        fillImage.color = normalFillColor;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        string texTime = "Time left " + gameTime.ToString("f0") + "s";
        if (stopTimer == false)
        {
            timerText.text = texTime;
            timerSlider.value = gameTime;
        }

        if (timerSlider.value < ((warningLimit / 100) * timerSlider.maxValue))
        {
            fillImage.color = warningFillColor;
        }

        if (gameTime <= 0 && stopTimer == false)  // En game over
        {
            stopTimer = true;
            gameObject.GetComponent<Shoot>().enabled = false;
            Destroy(timerSlider.gameObject);
            gameOverText.gameObject.SetActive(true);
           /* GameObject[] enemies = GameObject.FindGameObjectsWithTag("Spider");
            foreach (GameObject enemy in enemies)
                Destroy(enemy); //Destruye todo las arañas de la escena
                */
           GameObject environmentLevel = GameObject.FindGameObjectWithTag("Floor");
           Destroy(environmentLevel);
           GameObject environmentVirus = GameObject.FindGameObjectWithTag("EnvironmentVirus");
           Destroy(environmentVirus);
        }

      
    }
}
