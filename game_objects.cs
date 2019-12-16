using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class game_objects : MonoBehaviour {

    public GameObject congoimage;
    public GameObject panel;
    public Text score;
    public GameObject heli_r;
    public GameObject heli_l;
    public GameObject jetL;
    public GameObject jetR;
    public GameObject bang;

    bool flagJet = false;
    bool timesetFlag = true;
    public float initialtime = 0f;
    public float delayLevel = 30f;
    int count = 0;
    int countRounds;

    float delayInSeconds = 5f;

    int randomL = 0, randomR =0;
    int checkrandomL = 0,checkrandomR =0;
    int jetrandomL = 0, jetrandomR = 0;
    int jetcheckrandomL = 0, jetcheckrandomR = 0;
    RandomGenerator randomObject = new RandomGenerator();
    float cameraWidth;

    // Use this for initialization
    void Start () {
        if (congoimage)
        {
            congoimage.SetActive(false);
            panel.SetActive(false);
        }
        timesetFlag = false;
        initialtime = Time.time;
        countRounds = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            cameraWidth = height * cam.aspect;
            float pos = (cameraWidth / 2) - 0.2f;
            leftmoveheli.xpos = pos;
            leftmovejet.xpos = pos;
            rightmoveheli.xpos = pos;
            rightmovejet.xpos = pos;
            if (!(Time.time < initialtime + delayLevel) && count == 0)
            {
                count++;
                StartCoroutine(canGenerateHJ());

            }
            if (timesetFlag)
            {
                countRounds++;
                if (Score.checkLevel ==1 && countRounds == 4)
                {
                    PlayerPrefs.SetInt("level2Activate", 1);
                    PlayerPrefs.Save();
                    Score.flagStop = true;
                    congoimage.SetActive(true);
                    panel.SetActive(true);
                    score.text = Score.scorecount.ToString();
                }
                count = 0;
                timesetFlag = false;
                initialtime = Time.time;
                randomL = 0;
                randomR = 0;
                checkrandomL = 0;
                checkrandomR = 0;
                if (flagJet)
                {
                    flagJet = false;
                    delayLevel = 30f;
                }
                else
                {
                    flagJet = true;
                    delayLevel = 10f;
                }
            }
            

            if (!flagJet && Time.time < initialtime + delayLevel)
            {
                if (randomL == checkrandomL)
                {
                    GameObject leftheli = Instantiate(heli_l);
                    randomL = randomObject.generateRandom();
                    checkrandomL = 0;
                    leftmoveheli a = leftheli.AddComponent<leftmoveheli>() as leftmoveheli;
                    a.obj = leftheli;
                    a.troop = GameObject.Find("troopprefab");

                }
                if (randomR == checkrandomR)
                {
                    GameObject rightheli = Instantiate(heli_r);
                    randomR = randomObject.generateRandom();
                    checkrandomR = 0;
                    rightmoveheli a = rightheli.AddComponent<rightmoveheli>() as rightmoveheli;
                    a.obj = rightheli;
                    a.troop = GameObject.Find("troopprefab");

                }
                checkrandomL++;
                checkrandomR++;
            }
            if (flagJet && Time.time < initialtime + delayLevel)
            {
                if (jetrandomL == jetcheckrandomL)
                {
                    GameObject leftjet = Instantiate(jetL);
                    jetrandomL = randomObject.generateRandom();
                    jetcheckrandomL = 0;
                    leftmovejet a = leftjet.AddComponent<leftmovejet>() as leftmovejet;
                    a.obj = leftjet;
                    a.bomb = GameObject.Find("bomb");
                    a.bang = bang;

                }
                if (jetrandomR == jetcheckrandomR)
                {
                    GameObject rightjet = Instantiate(jetR);
                    jetrandomR = randomObject.generateRandom();
                    jetcheckrandomR = 0;
                    rightmovejet a = rightjet.AddComponent<rightmovejet>() as rightmovejet;
                    a.obj = rightjet;
                    a.bomb = GameObject.Find("bomb");
                    a.bang = bang;

                }
                jetcheckrandomL++;
                jetcheckrandomR++;
            }
            if (Score.flagStop)
                Destroy(this);
        }



    }

    IEnumerator canGenerateHJ()
    {
        yield return new WaitForSeconds(delayInSeconds);
        timesetFlag = true;
    }
}

class RandomGenerator
{
    System.Random random = new System.Random();
    public int generateRandom()
    {
        if (random.NextDouble() < 0.1)
            return random.Next(30,71);

        return random.Next(71, 121);
    }
}
