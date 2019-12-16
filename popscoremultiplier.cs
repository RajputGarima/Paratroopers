using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class popscoremultiplier : MonoBehaviour {

    public GameObject obj, Textui;
    bool candestroy = false;
    bool active = true;
	// Use this for initialization
	void Start () {
        candestroy = false;
        StartCoroutine(delaydestroy());

    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {
            Textui.GetComponent<Text>().text = "x" + Score.scoremultiplier.ToString();
            if (Score.flagStop)
                Destroy(this);
            Textui.SetActive(active);
            if (active) active = false;
            else active = true;
            if (candestroy)
            {
                Destroy(obj);
                Score.scoremultiplier--;
                Textui.SetActive(false);
            }
        }
	}
    IEnumerator delaydestroy()
    {
        yield return new WaitForSeconds(5f);
        candestroy = true;
    }
}
