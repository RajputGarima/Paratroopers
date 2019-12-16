using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletscript : MonoBehaviour {

    public GameObject obj;
    // Speed in units per sec.
    public float speed = 500f;
    public AudioSource bombexplode;
    public AudioSource jetexplode;
    public GameObject bang;

    private void Start()
    {
        jetexplode = GameObject.Find("jetexplode").GetComponent<AudioSource>();
        bombexplode = GameObject.Find("bombexplode").GetComponent<AudioSource>();
        CircleCollider2D circle = obj.AddComponent<CircleCollider2D>() as CircleCollider2D;
        circle.radius = 0.043f;
    }

    void Update()
    {
        if (!pause.gamepaused)
        {
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;
            Rigidbody2D r = obj.GetComponent<Rigidbody2D>() as Rigidbody2D;
            r.velocity = transform.up * step;
        }
    }
    private void OnBecameInvisible()
    {
        if (!pause.gamepaused)
        {
            Score.scorecount -= 1;
            Destroy(obj);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pause.gamepaused)
        {
            if (collision.gameObject.tag == "leftheli")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    jetexplode.Play();
                Score.scorecount += 10 * Score.scoremultiplier;
                Destroy(obj);
                Destroy(collision.gameObject);
                GameObject desthj = GameObject.Find("destroyhelijet");
                GameObject dest = Instantiate(desthj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
                Score.hjdestroyed++;
            }
            if (collision.gameObject.tag == "rightheli")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    jetexplode.Play();
                Score.scorecount += 10 * Score.scoremultiplier;
                Destroy(obj);
                Destroy(collision.gameObject);
                GameObject desthj = GameObject.Find("destroyhelijet");
                GameObject dest = Instantiate(desthj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
                Score.hjdestroyed++;
            }
            if (collision.gameObject.tag == "bomb")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    bombexplode.Play();
                Score.scorecount += 30 * Score.scoremultiplier;
                Destroy(obj);
                Destroy(collision.gameObject);
                GameObject desthj = GameObject.Find("bombexploded");
                GameObject dest = Instantiate(desthj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
                Score.bombexploded++;
            }
            if (collision.gameObject.tag == "rocket")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    bombexplode.Play();
                Score.scorecount += 50 * Score.scoremultiplier;
                Destroy(obj);
                Destroy(collision.gameObject);
                GameObject desthj = GameObject.Find("bombexploded");
                GameObject dest = Instantiate(desthj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
            }
            if (collision.gameObject.tag == "spaceship")
            {
                if (PlayerPrefs.GetInt("sound") == 1)
                    jetexplode.Play();
                Destroy(obj);
                Destroy(collision.gameObject);
                if(bang)
                    bang.SetActive(true);
                Score.flagStop = true;
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
            }

            if (Score.flagStop)
                Destroy(this);
        }
    }


}
