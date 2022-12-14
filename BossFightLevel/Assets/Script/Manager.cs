using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Stage == 1)
        {
            if (BossHealth == 4)
            {
                ColsDownSpeed = 0.5f;
                if (GameObject.FindGameObjectWithTag("Column").transform.position.y < -3)
                {
                    ColsDownSpeed = 0;
                }
            }
            else if (BossHealth == 3)
            {
                ColsDownSpeed = 1.5f;
                if (GameObject.FindGameObjectWithTag("Column").transform.position.y < -11)
                {
                    ColsDownSpeed = 0;
                }
            }
            else if (BossHealth == 2)
            {
                ColsDownSpeed = 4.5f;
                if (GameObject.FindGameObjectWithTag("Column").transform.position.y < -20)
                {
                    ColsDownSpeed = 0;
                    Stage = 2;
                    source.PlayOneShot(clip);
                    Debug.Log("Entering stage 2");
                }
            }
        }
        if (BossHealth == 0)
        {
            Debug.Log("Yeah it died");
            clip = null;
            Destroy(GameObject.Find("Boss"));
        }

    }
    public static int Stage = 1;
    public static int BossHealth = 5;
    public static float ColsDownSpeed = 0;
}
