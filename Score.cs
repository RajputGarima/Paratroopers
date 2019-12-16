using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Text score;
    public static int scorecount;
    public static int troopLeftCount;
    public static int troopRightCount;
    public static bool flagStop = false;
    public int level;
    public static int checkLevel;
    public static int total_troop_count;
    public static int bombexploded;
    public static int hjdestroyed;
    public static int troopkilled;
    public Text hiscorecount;
    public static int scoremultiplier;

    // Use this for initialization
    void Start () {
        scorecount = 0;
        troopRightCount = 0;
        troopLeftCount = 0;
        flagStop = false;
        checkLevel = level;
        total_troop_count = 3;
        bombexploded = 0;
        hjdestroyed = 0;
        troopkilled = 0;
        scoremultiplier = 1;

        if (checkLevel == 1 )
        {
            if (!PlayerPrefs.HasKey("Level1HighScore"))
            {
                Debug.Log(false);
                PlayerPrefs.SetInt("Level1HighScore", 0);
                PlayerPrefs.Save();
            }
            else
            {
                hiscorecount.text = PlayerPrefs.GetInt("Level1HighScore").ToString();
            }

            if (!PlayerPrefs.HasKey("level2Activate"))
            {
                PlayerPrefs.SetInt("level2Activate", 0);
                PlayerPrefs.Save();
            }

        }
        else  if(checkLevel == 2 ){
            if (!PlayerPrefs.HasKey("Level2HighScore"))
            {
                PlayerPrefs.SetInt("Level2HighScore", 0);
                PlayerPrefs.Save();
            }
            else
            {
                hiscorecount.text = PlayerPrefs.GetInt("Level2HighScore").ToString();
            }
        }
        else
        {
            if (!PlayerPrefs.HasKey("Level3HighScore"))
            {
                PlayerPrefs.SetInt("Level3HighScore", 0);
                PlayerPrefs.Save();
            }
            else
            {
                hiscorecount.text = PlayerPrefs.GetInt("Level3HighScore").ToString();
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            if (flagStop)
            {
                if (checkLevel == 1 && PlayerPrefs.GetInt("Level1HighScore") < scorecount)
                {
                    PlayerPrefs.SetInt("Level1HighScore", scorecount);
                    PlayerPrefs.Save();
                }
                if (checkLevel == 2 && PlayerPrefs.GetInt("Level2HighScore") < scorecount)
                {
                    PlayerPrefs.SetInt("Level2HighScore", scorecount);
                    PlayerPrefs.Save();
                }
                if (checkLevel == 3 && PlayerPrefs.GetInt("Level3HighScore") < scorecount)
                {
                    PlayerPrefs.SetInt("Level3HighScore", scorecount);
                    PlayerPrefs.Save();
                }

                Destroy(this);
            }
            if (checkLevel == 1 && PlayerPrefs.GetInt("Level1HighScore") < scorecount)
            {
                hiscorecount.text = scorecount.ToString();
            }
            if (checkLevel == 2 && PlayerPrefs.GetInt("Level2HighScore") < scorecount)
            {
                hiscorecount.text = scorecount.ToString();
            }
            if (checkLevel == 3 && PlayerPrefs.GetInt("Level3HighScore") < scorecount)
            {
                hiscorecount.text = scorecount.ToString();
            }
            score.text = scorecount.ToString();
            if (troopLeftCount > total_troop_count || troopRightCount > total_troop_count )
            {
                flagStop = true;
                SceneManager.LoadScene(3, LoadSceneMode.Additive);

                if (checkLevel == 1 && PlayerPrefs.GetInt("Level1HighScore") < scorecount)
                {
                    PlayerPrefs.SetInt("Level1HighScore", scorecount);
                    PlayerPrefs.Save();
                }
                if (checkLevel == 2 && PlayerPrefs.GetInt("Level2HighScore") < scorecount)
                {
                    PlayerPrefs.SetInt("Level2HighScore", scorecount);
                    PlayerPrefs.Save();
                }
                if (checkLevel == 3 && PlayerPrefs.GetInt("Level3HighScore") < scorecount)
                {
                    PlayerPrefs.SetInt("Level3HighScore", scorecount);
                    PlayerPrefs.Save();
                }

                Destroy(this);
            }
        }
        
    }

}
