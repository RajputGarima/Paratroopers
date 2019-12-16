using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button startbutton;
    public Button instructionsbutton;
    public Button exitbutton;

	// Use this for initialization
	void Start () {
        startbutton.onClick.AddListener(StartL);
        instructionsbutton.onClick.AddListener(InsL);
        exitbutton.onClick.AddListener(ExitL);

    }

    void StartL()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    void InsL()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
    void ExitL()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
