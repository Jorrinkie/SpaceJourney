using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update

    public Text score;
    public Text highScore;
    public int TimeC;
    public float TimeF;
    public DeathWait deathwait;
    public bool runonce = true;
    public int Money;
    public bool start100Stage;
    public bool RunOnceAnimator = true;

    public Animator HighScoreAnimator;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        TimeF += Time.deltaTime;
       
        deathwait = GameObject.Find("Canvas").GetComponent<DeathWait>();
        if (deathwait.deadwait == false)
        {
            TimeC = Mathf.RoundToInt(TimeF);
            score.text = TimeC.ToString();
        }
        if (deathwait.deadwait == true)
        {
            if (runonce)
            {
                runonce = false;
                Money = PlayerPrefs.GetInt("Money", 0) + TimeC;
                PlayerPrefs.SetInt("MoneyToGive", TimeC);
             //   PlayerPrefs.SetInt("Money", Money);
                Debug.Log("Money now is: " + Money);
            }
        }


        if (TimeC > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", TimeC);
            highScore.text = TimeC.ToString();

            //effects als je highscore verbeterd
            if (RunOnceAnimator) 
            {
                RunOnceAnimator = false;
                HighScoreAnimator.SetTrigger("HighScoreBeat");
            }
            
        }

        if (TimeC > 99)
        {
            start100Stage = true;
        }
        
    }


    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("MaxHealth");
    }
}
