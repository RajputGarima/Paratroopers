using System.Collections;
using UnityEngine;

public class destroytroopscript : MonoBehaviour {
    public GameObject obj;
    float delayInSeconds = 0.60F;
    bool candestroy = false;
    // Use this for initialization
    void Start () {
        StartCoroutine(destroyDelay());
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            if (candestroy)
            {
                Destroy(obj);
            }
            if (Score.flagStop)
            {
                Destroy(this);
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
