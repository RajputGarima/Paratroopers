using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour {

    public Button troopupgrade;
    public Button shieldbutton;
    int currentScore=0;
    bool setFlag;
    public Transform guntransform;
    int i = 0;
    // Use this for initialization
    void Start () {
        troopupgrade.interactable = false;
        shieldbutton.interactable = false;
        troopupgrade.onClick.AddListener(upgrade);
        shieldbutton.onClick.AddListener(provideProtection);
        setFlag = true;
	}

    private void Update()
    {
        if (!pause.gamepaused)
        {
            if (setFlag && (currentScore + (50 + 20 * i)) <= Score.scorecount)
            {
                i++;
                troopupgrade.interactable = true;
                shieldbutton.interactable = true;
                setFlag = false;
            }
            if (Input.GetKeyDown(KeyCode.S) && shieldbutton.interactable)
            {
                provideProtection();
            }
            if(Input.GetKeyDown(KeyCode.T) && troopupgrade.interactable)
            {
                upgrade();
            }
        }
    }

    void provideProtection()
    {
        if (!pause.gamepaused)
        {
            setFlag = true;
            currentScore = Score.scorecount;
            GameObject shield = Instantiate(GameObject.Find("shield"), guntransform.position, guntransform.rotation);
            shieldscript scr = shield.AddComponent<shieldscript>() as shieldscript;
            scr.obj = shield;
            shieldbutton.interactable = false;
            troopupgrade.interactable = false;
        }

    }

    void upgrade()
    {
        if (!pause.gamepaused)
        {
            setFlag = true;
            currentScore = Score.scorecount;
            Score.total_troop_count++;
            shieldbutton.interactable = false;
            troopupgrade.interactable = false;
        }
        
    }
}
