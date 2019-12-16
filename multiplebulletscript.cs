using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multiplebulletscript : MonoBehaviour {

    public Button multibulletbutton;
    public Transform guntransform;
    public GameObject bulletobj;
    public Text bullettext;
    int curr_score;
    int i = 0;
    static int multibulletCount;

	// Use this for initialization
	void Start () {
        multibulletCount = 5;
        multibulletbutton.onClick.AddListener(FireBullet);
		
	}

    private void Update()
    {
        if (!pause.gamepaused)
        {

            if (guntransform.rotation.z <= 0.31 && guntransform.rotation.z >= -0.31 && multibulletCount > 0)
                multibulletbutton.interactable = true;
            else
                multibulletbutton.interactable = false;

            if (multibulletCount == 0)
            {
                if ((curr_score + (50 + 20 * i)) <= Score.scorecount)
                {
                    i++;
                    multibulletCount = 5;
                    multibulletbutton.interactable = true;
                    bullettext.text = multibulletCount.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.B) && multibulletbutton.interactable)
                FireBullet();

        }
    }

    void FireBullet()
    {
        if (!pause.gamepaused)
        {
            multibulletCount--;
            if (multibulletCount == 0)
                curr_score = Score.scorecount;
            bullettext.text = multibulletCount.ToString();

            GameObject bullet1 = Instantiate(bulletobj, guntransform.position, guntransform.rotation);
            bulletscript b = bullet1.AddComponent<bulletscript>() as bulletscript;
            b.obj = bullet1;
            // bullet1.transform.rotation.Set(guntransform.rotation.x,guntransform.rotation.y,guntransform.rotation.z + 1.0f , guntransform.rotation.w);


            Quaternion rotation = new Quaternion(guntransform.rotation.x, guntransform.rotation.y, guntransform.rotation.z + 0.3f, guntransform.rotation.w);


            GameObject bullet2 = Instantiate(bulletobj, guntransform.position + new Vector3(0.2f, 0f, 0f), rotation);
            bulletscript b2 = bullet2.AddComponent<bulletscript>() as bulletscript;
            b2.obj = bullet2;
            //bullet2.transform.rotation.Set(guntransform.rotation.x, guntransform.rotation.y, guntransform.rotation.z + 3.0f, guntransform.rotation.w);


            rotation = new Quaternion(guntransform.rotation.x, guntransform.rotation.y, guntransform.rotation.z + 0.6f, guntransform.rotation.w);



            GameObject bullet3 = Instantiate(bulletobj, guntransform.position + new Vector3(0.4f, 0f, 0f), rotation);
            bulletscript b3 = bullet3.AddComponent<bulletscript>() as bulletscript;
            b3.obj = bullet3;

            rotation = new Quaternion(guntransform.rotation.x, guntransform.rotation.y, guntransform.rotation.z - 0.3f, guntransform.rotation.w);


            GameObject bullet4 = Instantiate(bulletobj, guntransform.position + new Vector3(-0.2f, 0f, 0f), rotation);
            bulletscript b4 = bullet4.AddComponent<bulletscript>() as bulletscript;
            b4.obj = bullet4;

            rotation = new Quaternion(guntransform.rotation.x, guntransform.rotation.y, guntransform.rotation.z - 0.6f, guntransform.rotation.w);


            GameObject bullet5 = Instantiate(bulletobj, guntransform.position + new Vector3(-0.4f, 0f, 0f), rotation);
            bulletscript b5 = bullet5.AddComponent<bulletscript>() as bulletscript;
            b5.obj = bullet5;
        }

        
    }

}
