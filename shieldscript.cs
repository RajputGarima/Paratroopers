using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscript : MonoBehaviour {
    public GameObject obj;
    bool candestroy;
    float delayInSeconds = 5f;

	// Use this for initialization
	void Start () {
        CircleCollider2D circle = obj.AddComponent<CircleCollider2D>() as CircleCollider2D;
        circle.radius = 1.80f;
        candestroy = false;
        StartCoroutine(destroyDelay());

    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {

            obj.transform.Rotate(new Vector3(0f, 0f, 10f));

            if (candestroy)
            {
                Destroy(obj);
            }
        }
		
	}

    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        candestroy = true;
    }

}
