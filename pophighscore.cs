using UnityEngine;
using System.Collections;

public class pophighscore : MonoBehaviour {

    public GameObject messagetext;
    int count;
    int highscore;
    bool deactivate;

	// Use this for initialization
	void Start () {
        count = 0;
        deactivate = false;
        if(Score.checkLevel == 1)
        {
            highscore = PlayerPrefs.GetInt("Level1HighScore");
        }
        else if(Score.checkLevel == 2)
        {
            highscore = PlayerPrefs.GetInt("Level2HighScore");
        }
        else
        {
            highscore = PlayerPrefs.GetInt("Level3HighScore");
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(count ==0 && Score.scorecount > highscore)
        {
            count++;
            messagetext.SetActive(true);
            StartCoroutine(delay());
        }
        if (deactivate)
        {
            deactivate = false;
            messagetext.SetActive(false);
        }

	}

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        deactivate = true;
    }
}
