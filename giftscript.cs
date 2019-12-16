using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class giftscript : MonoBehaviour {

    public GameObject obj;
    float speed = 4f;
    public GameObject textui;
   
	// Use this for initialization
	void Start () {
        BoxCollider2D box = obj.AddComponent<BoxCollider2D>() as BoxCollider2D;
        box.size.Set(1.26f,1.53f);
	}
	
	// Update is called once per frame
	void Update () {

        if (!pause.gamepaused)
        {
            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -4.0f, 0f), step);
            if (Score.flagStop)
                Destroy(this);
            if (transform.position.y == -4.0f )
                Destroy(obj);
        }
  }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pause.gamepaused)
        {
            if (collision.gameObject.tag == "bullet")
            {
                
                Destroy(collision.gameObject);
                Score.scoremultiplier++;
                obj.GetComponent<BoxCollider2D>().enabled= false;
                popscoremultiplier pop= obj.AddComponent<popscoremultiplier>() as popscoremultiplier;
                pop.obj = obj;
                pop.Textui = textui;
                Destroy(this);
            }
        }
        
    }
        
}
