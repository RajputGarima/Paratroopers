using UnityEngine;

public class leftmoveheli : MonoBehaviour
{
    public GameObject obj;
    public GameObject troop;
    // Speed in units per sec.
    public float speed = 8f;
    int random = 0;
    int checkrandom = 0;
    RandomGeneratorTroop troopgenerate = new RandomGeneratorTroop();
    public static float xpos;

    private void Start()
    {
        if (Score.checkLevel >1)
        {
            speed = 12f;
        }
        BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
        box.size.Set(0.53f, 0.23f);

        random = troopgenerate.generateRandom();     
    }

    void Update()
    {
        if (!pause.gamepaused)
        {
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-14.0f, 5.12f, 0f), step);

            if (random == checkrandom)
            {
                if (troopgenerate.generateBool() && (transform.position.x < -1.25f || transform.position.x > 1.25f) && !(transform.position.x < -xpos || transform.position.x > xpos))
                {
                    GameObject troopinstance = Instantiate(troop, transform.position - new Vector3(0, 0.25f, 0), transform.rotation);
                    troopscript a = troopinstance.AddComponent<troopscript>() as troopscript;
                    a.obj = troopinstance;
                    a.parachuteprefab = GameObject.Find("parachute");
                }
                random = troopgenerate.generateRandom();
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
        {
            Destroy(obj);
        }
    }
}

class RandomGeneratorTroop
{
    System.Random random = new System.Random();
    public int generateRandom()
    {
        return random.Next(5, 111);
    }

    public bool generateBool()
    {
        if (random.NextDouble() < 0.15)
            return true;
        else
            return false;
    }
}