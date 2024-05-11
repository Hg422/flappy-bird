using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public bool gameOn = true;
    public AudioSource ding;
    public AudioSource fail;

    private void Start()
    {
        highestScoreText.text = PlayerPrefs.GetInt("PlayerA", 0).ToString();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
        ding.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if(gameOn)
        {
            fail.Play();
            // save highest score in PlayerPref
            saveHighest();
        }
        gameOn = false;
    }

    public void saveHighest()
    {
        // PlayerPrefs.SetInt("PlayerA", 0);
        if (PlayerPrefs.GetInt("PlayerA", 0) < score)
        {
            PlayerPrefs.SetInt("PlayerA", score);
        }
    }

    public void resetHighest()
    {
        PlayerPrefs.SetInt("PlayerA", 0);
        highestScoreText.text = PlayerPrefs.GetInt("PlayerA", 0).ToString();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
