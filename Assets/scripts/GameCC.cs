using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCC : MonoBehaviour
{
    public int tScore;
    public static GameCC instance;
    public Text scoreText;
    public GameObject gameOver;
    

    void Start()
    {
        instance = this;
        
    }

    
    public void UpadeScoreText()

    {
        scoreText.text = tScore.ToString();
    }
    
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    
     public void RestarGame(string lvName)
    {
        SceneManager.LoadScene(lvName);
    }
}
