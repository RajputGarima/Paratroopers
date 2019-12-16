using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class parachutescript : MonoBehaviour {
    public GameObject parachute;
    public GameObject troop;
    public AudioSource troopexplode;

    private void Start()
    {
        troopexplode = GameObject.Find("troopexplode").GetComponent<AudioSource>();
        BoxCollider2D box = parachute.AddComponent<BoxCollider2D>() as BoxCollider2D;
        box.size.Set(0.15f, 0.16f);
    }
    void Update()
    {
        if (!pause.gamepaused)
        {
            if (Score.flagStop)
                Destroy(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pause.gamepaused)
        {
            if (collision.gameObject.tag == "bullet")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    troopexplode.Play();
                Score.scorecount += 5 * Score.scoremultiplier;
                Destroy(parachute);
                Destroy(troop);
                Destroy(collision.gameObject);
                GameObject desttroop = GameObject.Find("desttroop1");
                GameObject dest = Instantiate(desttroop, troop.transform.position, troop.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
                Score.troopkilled++;
            }
        }
    }
}
