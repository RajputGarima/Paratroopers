using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

    public static bool gamepaused;
    public GameObject panel;
    public GameObject pausemenu;
    public Button pausebutton;
    public Button resumebutton;
    public Button homebutton;
    public Button restartbutton;
    public Button soundbutton;
    public Sprite soundoff;
    public Sprite soundon;
    public Text hiscore, score, troopkilled, bombexploded, hjdestroyed;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("sound") == 1)
            soundbutton.GetComponent<Image>().sprite = soundon;
        else
            soundbutton.GetComponent<Image>().sprite = soundoff;
        soundbutton.onClick.AddListener(soundtoggle);
        if (pausebutton)
        {
            pausebutton.onClick.AddListener(onPause);
        }
        if(resumebutton)
            resumebutton.onClick.AddListener(onResume);
        restartbutton.onClick.AddListener(onRestart);
        homebutton.onClick.AddListener(homescreen);
        gamepaused = false;

        if (hiscore)
        {
            hiscore.text = Score.scorecount.ToString();
            if (Score.checkLevel == 1 && Score.scorecount < PlayerPrefs.GetInt("Level1HighScore"))
                hiscore.text = PlayerPrefs.GetInt("Level1HighScore").ToString();
            else if (Score.checkLevel == 2 && Score.scorecount < PlayerPrefs.GetInt("Level2HighScore"))
                hiscore.text = PlayerPrefs.GetInt("Level2HighScore").ToString();
            else if(Score.scorecount < PlayerPrefs.GetInt("Level3HighScore"))
                hiscore.text = PlayerPrefs.GetInt("Level3HighScore").ToString();

            

            score.text = Score.scorecount.ToString();
            bombexploded.text = Score.bombexploded.ToString();
            hjdestroyed.text = Score.hjdestroyed.ToString();
            troopkilled.text = Score.troopkilled.ToString();
        }
    }

    void soundtoggle()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundbutton.GetComponent<Image>().sprite = soundoff;
            PlayerPrefs.SetInt("sound", 0);
            PlayerPrefs.Save();
        }
        else
        {
            soundbutton.GetComponent<Image>().sprite = soundon;
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.Save();
        }

    }

    // Update is called once per frame
    void Update () {
        if (pausebutton)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamepaused)
                {
                    onResume();

                }
                else
                    onPause();
            }
        }
        
        
	}

    void onPause()
    {
        if(!gamepaused)
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        gamepaused = true;
        panel.SetActive(true);

    }

    void onResume()
    {
        panel.SetActive(false);
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gamepaused = false;
    }

    void onRestart()
    {

        gamepaused = false;
        Time.timeScale = 1f;
        if (Score.checkLevel == 1)
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        else if (Score.checkLevel == 2)
            SceneManager.LoadScene(5, LoadSceneMode.Single);
        else
            SceneManager.LoadScene(6, LoadSceneMode.Single);
       /* Score.scorecount = 0;
        Score.troopRightCount = 0;
        Score.troopLeftCount = 0;
        Score.flagStop = false;
        Score.total_troop_count = 3;*/
    }

    void homescreen()
    {
        gamepaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
}
