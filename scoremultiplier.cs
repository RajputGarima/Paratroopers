using UnityEngine;
using UnityEngine.UI;
public class scoremultiplier : MonoBehaviour
{
    public GameObject gift;
    public GameObject rocket;
    public GameObject spaceship;
    public GameObject textui;
    int random, checkrandom;
    int randomrocket, checkrandomrocket;
    Randomscoremultiplier giftgenerate = new Randomscoremultiplier();
    public GameObject bang;

    // Use this for initialization
    void Start()
    {
        random = giftgenerate.generateRandom();
        checkrandom = 0;
        randomrocket = giftgenerate.generateRandom();
        checkrandomrocket = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!pause.gamepaused)
        {
            if (Score.flagStop)
                Destroy(this);



            if (random == checkrandom)
            {
                if (giftgenerate.generateBool())
                {
                    Camera cam = Camera.main;
                    float height = 2f * cam.orthographicSize;
                    float cameraWidth = height * cam.aspect;
                    float pos = (cameraWidth / 2) - 0.2f;
                    float random_x = UnityEngine.Random.Range(-pos, pos);
                    GameObject giftinstance = Instantiate(gift, new Vector3(random_x, 4.40f, 0f), gift.transform.rotation);
                    giftscript a = giftinstance.AddComponent<giftscript>() as giftscript;
                    a.obj = giftinstance;
                    a.textui = textui;
                }
                random = giftgenerate.generateRandom();
                checkrandom = 0;

            }
            if (randomrocket == checkrandomrocket)
            {
                if (giftgenerate.generateBool())
                {
                    if (giftgenerate.generateBoolequal())
                    {
                        Camera cam = Camera.main;
                        float height = 2f * cam.orthographicSize;
                        float cameraWidth = height * cam.aspect;
                        float pos = (cameraWidth / 2) - 0.2f;
                        float random_x = UnityEngine.Random.Range(-pos + 2.0f, pos - 2.0f);
                        GameObject rocketinstance = Instantiate(rocket, new Vector3(random_x, 4.40f, 0f), gift.transform.rotation);
                        rocketscript a = rocketinstance.AddComponent<rocketscript>() as rocketscript;
                        a.bang = bang;
                        a.obj = rocketinstance;
                    }
                    else
                    {
                        Camera cam = Camera.main;
                        float height = 2f * cam.orthographicSize;
                        float cameraWidth = height * cam.aspect;
                        float pos = (cameraWidth / 2) - 0.2f;
                        float random_x = UnityEngine.Random.Range(-pos + 2.0f, pos - 2.0f);
                        GameObject spaceshipinstance = Instantiate(spaceship, new Vector3(random_x, 4.40f, 0f), spaceship.transform.rotation);
                        rocketscript a = spaceshipinstance.AddComponent<rocketscript>() as rocketscript;
                        a.obj = spaceshipinstance;
                    }
                }
                randomrocket = giftgenerate.generateRandom();
                checkrandomrocket = 0;

            }
            checkrandom++;
            checkrandomrocket++;
        }
    }
}

class Randomscoremultiplier
{
    System.Random random = new System.Random();
    public int generateRandom()
    {
        return random.Next(30, 111);
    }

    public bool generateBool()
    {
        if (random.NextDouble() < 0.1)
            return true;
        else
            return false;
    }
    public bool generateBoolequal()
    {
        if (random.NextDouble() < 0.5)
            return true;
        else
            return false;
    }
}
