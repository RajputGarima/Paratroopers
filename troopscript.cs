using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class troopscript : MonoBehaviour {
    public GameObject obj;
    private int countparachute=0;
    public GameObject parachuteprefab;
    private GameObject objParachute;
    float speed = 2f;
    public AudioSource troopexplode;

    // Use this for initialization
    void Start () {
        troopexplode = GameObject.Find("troopexplode").GetComponent<AudioSource>();
        if (Score.checkLevel >1)
        {
            speed = 3.5f;
        }
        BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
        box.size.Set(0.13f, 0.24f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -3.995f, 0f), step);
            if (transform.position.y < 2.60 && countparachute == 0)
            {
                countparachute++;
                objParachute = Instantiate(parachuteprefab, transform.position + new Vector3(-0.019f, 0.6181f, 0f), transform.rotation);
                parachutescript scr = objParachute.AddComponent<parachutescript>() as parachutescript;
                scr.parachute = objParachute;
                scr.troop = obj;

            }
            if (objParachute != null)
            {
                objParachute.transform.position = Vector3.MoveTowards(objParachute.transform.position, new Vector3(objParachute.transform.position.x, transform.position.y, 0f), step);
            }
            if (transform.position.y < -2.9533f)
            {
                Destroy(objParachute);
                objParachute = null;
            }
            if (Score.flagStop)
                Destroy(this);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pause.gamepaused)
        {
            if (collision.gameObject.tag == "troop")
            {
                if (obj.transform.position.x < -1.25f && obj.transform.position.y < -2.4f)
                {
                    Score.troopLeftCount += 1;
                    Destroy(objParachute);
                    Destroy(this);
                }
                else if (obj.transform.position.x > -1.25f && obj.transform.position.y < -2.4f)
                {
                    Score.troopRightCount += 1;
                    Destroy(objParachute);
                    Destroy(this);
                }
            }
            if (collision.gameObject.tag == "line")
            {

                if (obj.transform.position.x < -1.25f)
                {
                    Score.troopLeftCount += 1;
                }
                else
                {
                    Score.troopRightCount += 1;
                }
                Destroy(this);
            }
            if (collision.gameObject.tag == "bullet")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    troopexplode.Play();
                Score.scorecount += 5 * Score.scoremultiplier;
                Destroy(obj);
                Destroy(objParachute);
                Destroy(collision.gameObject);
                GameObject desttroop = GameObject.Find("desttroop1");
                GameObject dest = Instantiate(desttroop, obj.transform.position, obj.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
                Score.troopkilled++;
            }
        }
    }

}
