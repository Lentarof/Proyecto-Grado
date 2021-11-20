using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoring : MonoBehaviour
{
    private TextMeshProUGUI scoreeuText;
    private TextMeshProUGUI scoremanText;
    private TextMeshProUGUI scorematText;
    private TextMeshProUGUI scorewirText;

    private GameObject scoreBoardUI;

    private string scoreTag = "ScoreCanvas";
    private string scoreEuTag = "ScoreEu";
    private string scoreManTag = "ScoreMan";
    private string scoreMatTag = "ScoreMat";
    private string scoreWirTag = "ScoreWir";
    
    
    public static int scoreEu;
    public static int scoreMan;
    public static int scoreMat;
    public static int scoreWir;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Shoot>().enabled = true;
        scoreBoardUI = GameObject.FindGameObjectWithTag(scoreTag);
        scoreeuText = GameObject.FindGameObjectWithTag(scoreEuTag).GetComponent<TextMeshProUGUI>();
        scoremanText = GameObject.FindGameObjectWithTag(scoreManTag).GetComponent<TextMeshProUGUI>();
        scorematText = GameObject.FindGameObjectWithTag(scoreMatTag).GetComponent<TextMeshProUGUI>();
        scorewirText = GameObject.FindGameObjectWithTag(scoreWirTag).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreeuText.text =  scoreEu.ToString();
        scoremanText.text =  scoreMan.ToString();
        scorematText.text =  scoreMat.ToString();
        scorewirText.text =  scoreWir.ToString();

    }
}
