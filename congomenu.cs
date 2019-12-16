
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class congomenu : MonoBehaviour {

    public Button back;
    public Button restart;
    public Button home;
    public Button forward;
    

	// Use this for initialization
	void Start () {
        back.onClick.AddListener(backClick);
        home.onClick.AddListener(homePage);
        forward.onClick.AddListener(forwardLevel);
        restart.onClick.AddListener(restartLevel);

    }

    void backClick()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    void restartLevel()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    void homePage()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void forwardLevel()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
}
