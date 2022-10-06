using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent bossAI;

    public GameObject player;

    //public bool isChasing = false;

    //public float chaseDistance = 3.0f;

    public float ftime = 3;

    public float bossNormalSpeed = 6f;
    public float bossNormalAcc = 3f;

    public float bossDashSpeed = 12.5f;
    public float bossDashAcc = 6f;
    public AudioSource source;
    public AudioClip clip;

    private bool isRushing = false;

    private Vector3 rushDirection;

    // Start is called before the first frame update
    void Start()
    {
        bossAI = GetComponent<NavMeshAgent>();
        bossAI.speed = bossNormalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Stage == 1)
        {
            MoveToPlayer();
            

        }
        else if (Manager.Stage == 2)
        {
            MoveToPlayer();
            
            //source.PlayOneShot(clip);

            ftime += Time.deltaTime;

            if (ftime > 6f)
            {
                isRushing = true;

                //rushDirection = (player.transform.position - transform.position).normalized;

                Debug.Log("Are u ready?");
                
                ftime = 0;
            }

            if (isRushing)
            {   
                bossAI.acceleration = bossDashAcc;
                bossAI.speed = bossDashSpeed;

                if (ftime > 1f)
                {   
                    bossAI.acceleration = bossNormalAcc;
                    bossAI.speed = bossNormalSpeed;
                    isRushing = false;
                    
                }
                //transform.Translate(rushDirection * Time.smoothDeltaTime * bossDashSpeed * 10);

            }
        }
    }

    void MoveToPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //Debug.Log("Health--");

        Vector3 directionToPlayer = transform.position - player.transform.position;

        Vector3 newPos = transform.position - directionToPlayer;

        bossAI.SetDestination(newPos);
    }
}
