using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;

public class MoneyGiver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int MoneyToGive;
    private int currentScore = 0;
    private bool isAnimating = false;
    private float speed = 0.03f;
    public Animator ScoreAnimator;

    void Start()
    {
        Time.timeScale = 1f;
        MoneyToGive = PlayerPrefs.GetInt("MoneyToGive", 0);
        
        // Initialize your score text
        scoreText.text = "0";
    }

    void Update()
    {
        if (!isAnimating)
        {
            // Start the animation if MoneyToGive is not equal to currentScore
            if (MoneyToGive != currentScore)
            {
                isAnimating = true;
                StartCoroutine(AnimateScore());
            }
        }
    }

    IEnumerator AnimateScore()
    {
        int increment = (MoneyToGive > currentScore) ? 1 : -1;

        while (currentScore != MoneyToGive)
        {
            yield return new WaitForSeconds(speed);
            if (speed > 0.00002)
            {
                speed -= 0.0005f;
            }
            else
            {
                speed = 0.00001f;
            }

            currentScore += increment;
            scoreText.text = currentScore.ToString();
            yield return null;
        }

        // Wait for 1 second
        ScoreAnimator.SetTrigger("ScoreAnimation");
        yield return new WaitForSeconds(2f);
        ScoreAnimator.SetTrigger("ScoreAnimation2");
        yield return new WaitForSeconds(1f);


        // Add or subtract the money to/from the Money counter
        int currentMoney = PlayerPrefs.GetInt("Money", 0);
        currentMoney += MoneyToGive;
        PlayerPrefs.SetInt("Money", currentMoney);

        // Reset the score text
        scoreText.text = "0";

        // Reset variables for future animations
        MoneyToGive = 0;
        currentScore = 0;
        isAnimating = false;
       
    }


    public void TwiceScore()
    {
        Debug.Log("Received");
        MoneyToGive = PlayerPrefs.GetInt("MoneyToGive", 0);
        currentScore = 0;
    }

}
