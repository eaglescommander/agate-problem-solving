using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null; 
    public static ScoreManager Instance 
    { 
        get 
        { 
            if (_instance == null) 
            { 
                _instance = FindObjectOfType<ScoreManager> (); 
            } 
            return _instance; 
        } 
    }

    [SerializeField] private Text scoreText;
    int score;

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
