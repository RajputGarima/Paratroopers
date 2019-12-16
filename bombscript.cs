using UnityEngine;
using UnityEngine.SceneManagement;

public class bombscript : MonoBehaviour {
    public GameObject obj;
    float speed = 4f;
    public AudioSource bombexplode;
    public GameObject bang;

	// Use this for initialization
	void Start () {
        if(Score.checkLevel > 1)
        {
            speed = 6f;
        }
        bombexplode = GameObject.Find("bombexplode").GetComponent<AudioSource>();
        BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
        box.size.Set(16.68f, 16.86f);
	}
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            float step = speed * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, -10));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -2.157f, 0), step);
            if (Score.flagStop)
                Destroy(this);
        }
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pause.gamepaused)
        {
            if (collision.gameObject.tag == "shield")
            {
                if(PlayerPrefs.GetInt("sound") == 1)
                    bombexplode.Play();
                Score.scorecount += 30 * Score.scoremultiplier;
                Destroy(obj);
                GameObject dest = Instantiate(GameObject.Find("bombexploded"), obj.transform.position, obj.transform.rotation);
                destroytroopscript script = dest.AddComponent<destroytroopscript>() as destroytroopscript;
                script.obj = dest;
                Score.bombexploded++;
            }
            else
        if (collision.gameObject.tag == "gun")
            {
                bang.SetActive(true);
                Score.flagStop = true;
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                Destroy(obj);

            }
        }
    }
}
