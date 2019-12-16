using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {
    public GameObject gun;
    public GameObject bulletobj;
    public float delayInSeconds = 0.1F;
    bool canShoot = true;
    public AudioSource firebullet;
    public GameObject bang;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!pause.gamepaused)
        {

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Alpha6))
            {
                float step = 80f * Time.deltaTime;
                Vector3 var1 = new Vector3(0, -2.15f, 0);
                Vector3 v = new Vector3(0, 0, 1);

                if (gun.transform.rotation.z > -0.68f)
                {
                    gun.transform.RotateAround(var1, v, -step);
                    //Debug.Log(gun.transform.rotation.eulerAngles.z);
                    if (gun.transform.rotation.z < -0.68f)
                        gun.transform.RotateAround(var1, v, step);
                }

            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Alpha4))
            {
                float step = 80f * Time.deltaTime;
                Vector3 var1 = new Vector3(0, -2.15f, 0);
                Vector3 v = new Vector3(0, 0, 1);
                if (gun.transform.rotation.z < 0.68f)

                {
                    gun.transform.RotateAround(var1, v, step);
                    if (gun.transform.rotation.z > 0.68f)
                        gun.transform.RotateAround(var1, v, -step);
                }

            }
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Alpha8)) && canShoot)
            {

                canShoot = false;
                GameObject bullet1 = Instantiate(bulletobj, gun.transform.position, gun.transform.rotation);
                bulletscript b = bullet1.AddComponent<bulletscript>() as bulletscript;
                b.obj = bullet1;
                if(bang)
                    b.bang = bang;
                if (PlayerPrefs.GetInt("sound") == 1)
                    firebullet.Play();
                StartCoroutine(ShootDelay());
            }
            if (Score.flagStop)
                Destroy(this);
        }

    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

}
