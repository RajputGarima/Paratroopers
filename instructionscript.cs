using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instructionscript : MonoBehaviour {

    public Button backbutton;

	// Use this for initialization
	void Start () {
        backbutton.onClick.AddListener(GoBack);
		
	}
    void GoBack()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
