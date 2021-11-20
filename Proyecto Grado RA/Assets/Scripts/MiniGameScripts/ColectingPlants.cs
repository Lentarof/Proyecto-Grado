using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColectingPlants : MonoBehaviour
{
    private string eucalipto = "EucaliptoForGame";
    private string manzanilla = "ManzanillaForGame";
    private string matico = "MaticoForGame";
    private string wirawira = "WiraWiraForGame";

    // private int collecteucalip;
    // private int collectmanza;
    // private int collectmatic;
    // private int collectwira;
    
    // private TextMeshProUGUI scoreeuText;
    // private TextMeshProUGUI scoremanText;
    // private TextMeshProUGUI scorematText;
    // private TextMeshProUGUI scorewirText;
    //
    // private GameObject scoreBoardUI;
    //
    // private string scoreTag = "ScoreCanvas";
    // private string scoreEuTag = "ScoreEu";
    // private string scoreManTag = "ScoreMan";
    // private string scoreMatTag = "ScoreMat";
    // private string scoreWirTag = "ScoreWir";
    //
    //
    // public static int scoreEu;
    // public static int scoreMan;
    // public static int scoreMat;
    // public static int scoreWir;
    //
    //
    
    // Start is called before the first frame update
    void Start()
    {
        // scoreBoardUI = GameObject.FindGameObjectWithTag(scoreTag);
        // scoreeuText = GameObject.FindGameObjectWithTag(scoreEuTag).GetComponent<TextMeshProUGUI>();
        // scoremanText = GameObject.FindGameObjectWithTag(scoreManTag).GetComponent<TextMeshProUGUI>();
        // scorematText = GameObject.FindGameObjectWithTag(scoreMatTag).GetComponent<TextMeshProUGUI>();
        // scorewirText = GameObject.FindGameObjectWithTag(scoreWirTag).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text= "Score: " + score.ToString();
        
        // scoreeuText.text =  scoreEu.ToString();
        // scoremanText.text =  scoreMan.ToString();
        // scorematText.text =  scoreMat.ToString();
        // scorewirText.text =  scoreWir.ToString();
        
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == eucalipto)
        {
            Destroy(collision.gameObject);
            Scoring.scoreEu += 1;
        }

        if (collision.gameObject.name == manzanilla)
        {
            Destroy(collision.gameObject);
            Scoring.scoreMan += 1;
        }
        
        if (collision.gameObject.name == matico)
        {
            Destroy(collision.gameObject);
            Scoring.scoreMat += 1;
        }
        
        if (collision.gameObject.name == wirawira)
        {
            Destroy(collision.gameObject);
            Scoring.scoreWir += 1;
        }
    }
*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == eucalipto)
        {
            Destroy(other.gameObject);
            Scoring.scoreEu += 1;
        }

        if (other.gameObject.name == manzanilla)
        {
            Destroy(other.gameObject);
            Scoring.scoreMan += 1;
        }
        
        if (other.gameObject.name == matico)
        {
            Destroy(other.gameObject);
            Scoring.scoreMat += 1;
        }
        
        if (other.gameObject.name == wirawira)
        {
            Destroy(other.gameObject);
            Scoring.scoreWir += 1;
        }
    }
}
