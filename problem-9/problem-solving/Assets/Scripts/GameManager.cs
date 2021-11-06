using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null; 
    public static GameManager Instance 
    { 
        get 
        { 
            if (_instance == null) 
            { 
                _instance = FindObjectOfType<GameManager> (); 
            } 
            return _instance; 
        } 
    }

    [SerializeField] private Text timerText;
    int timer;
    int initial;
    bool timerGoing = false;
    float elapsedTime = 0f;

    Coroutine routine;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject playObjects;

    public void Awake()
    {
        initial = int.Parse(timerText.text);
    }

    public void Start()
    {
        timerGoing = true;

        routine = StartCoroutine(UpdateTimer());
    }

    public void Update()
    {
        if (Input.GetKeyDown (KeyCode.R))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timer = initial - int.Parse(TimeSpan.FromSeconds(elapsedTime).ToString("ss"));
            timerText.text = timer.ToString();

            if (timer <= 0)
            {
                GameOver();
                yield break;
            }

            yield return null;
        }
    }

    public void GameOver()
    {
        StopCoroutine(routine);
        gameOverPanel.gameObject.SetActive(true);
        playObjects.gameObject.SetActive(false);
    }
}
