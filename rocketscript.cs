using UnityEngine;
using UnityEngine.SceneManagement;

public class rocketscript : MonoBehaviour {

    public GameObject obj;
    float xposition,xp;
    float speed = 6f;
    bool flipposition;
    int c1, c2;
    public GameObject bang;
	// Use this for initialization
	void Start () {
        c1 = 0;
        c2 = 0;
        flipposition = false;
        if (bang)
        {
            BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
            box.size.Set(2f, 4f);
        }
        else
        {
            BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
            box.size.Set(0.96f, 0.96f);
        }
        xposition = obj.transform.position.x;
        xp = xposition;
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            if (Score.flagStop)
                Destroy(this);
            float step = speed * Time.deltaTime;
            float yp;
            if (flipposition)
            {
                xp = xposition + 2.0f;
                yp = transform.position.y - 1.0f;
                c1++;
                if (c1 == 10)
                {
                    flipposition = false;
                    c1 = 0;
                }
            }
            else
            {
                xp = xposition - 2.0f;
                yp = transform.position.y - 1.0f;
                c2++;
                if (c2 == 10)
                {
                    flipposition = true;
                    c2 = 0;
                }
            }

            
                

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xp, yp, 0f), step);

            if (transform.position.y <= -3.5f)
            {
                if (bang)
                {
                    bang.SetActive(true);
                    Score.flagStop = true;
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);
                }
                Destroy(obj);
            }

        }
		
	}
}
