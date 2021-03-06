﻿using UnityEngine;

public class leftmovejet : MonoBehaviour
{
    public GameObject obj;
    public GameObject bomb;
    // Speed in units per sec.
    public float speed = 8f;
    int random = 0;
    int checkrandom = 0;
    RandomGeneratorBomb bombgenerate = new RandomGeneratorBomb();
    public static float xpos;
    public GameObject bang;

    private void Start()
    {
        if (Score.checkLevel > 1)
        {
            speed = 12f;
        }
        BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
        box.size.Set(2.1f, 1.6f);

        random = bombgenerate.generateRandom();
    }

    void Update()
    {
        if (!pause.gamepaused)
        {
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-14.0f, 5.26f, 0f), step);

            if (random == checkrandom)
            {
                if (bombgenerate.generateBool() && !(transform.position.x < -xpos || transform.position.x > xpos))
                {
                    GameObject bombinstance = Instantiate(bomb, transform.position - new Vector3(0, 0.25f, 0), transform.rotation);
                    bombscript a = bombinstance.AddComponent<bombscript>() as bombscript;
                    a.obj = bombinstance;
                    a.bang = bang;
                }
                random = bombgenerate.generateRandom();
                checkrandom = 0;

            }
            checkrandom++;
            if (Score.flagStop)
                Destroy(this);
        }
    }
    private void OnBecameInvisible()
    {
        if (!pause.gamepaused)
            Destroy(obj);
    }
}

class RandomGeneratorBomb
{
    System.Random random = new System.Random();
    public int generateRandom()
    {
       return random.Next(20, 151);
    }

    public bool generateBool()
    {
        if (random.NextDouble() < 0.1)
            return true;
        else
            return false;
    }
}