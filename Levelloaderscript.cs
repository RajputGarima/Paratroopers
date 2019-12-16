using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Levelloaderscript : MonoBehaviour {

    public Button level1;
    public Button level2;
    public Button level3;

	// Use this for initialization
	void Start () {
        level1.onClick.AddListener(loadLevel1);
        level2.onClick.AddListener(loadLevel2);
        level3.onClick.AddListener(loadLevel3);
        if(PlayerPrefs.GetInt("level2Activate") == 0)
        {
            level2.GetComponent<Button>().interactable = false;
            level3.GetComponent<Button>().interactable = false;
        }
            
	}
    void loadLevel3()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    void loadLevel1()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    void loadLevel2()
    {
        
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
