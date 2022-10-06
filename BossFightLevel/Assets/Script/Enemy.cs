using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{   
    private NavMeshAgent ghost;

    public GameObject player;

    public bool isChasing = false;

    public float chaseDistance = 3.0f;

    public float ftime = 3;

    public float bossSpeed = 12.5f;

    private bool isRushing = false;

    private Vector3 rushDirection;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Stage == 1)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < chaseDistance && isChasing)
            {
                Debug.Log("Health--");

                //Vector3 directionToPlayer = transform.position - player.transform.position;

                //Vector3 newPos = transform.position - directionToPlayer;

                //ghost.SetDestination(newPos);
            }
        }
        else if (Manager.Stage == 2)
        {
            ftime += Time.deltaTime;
            if (ftime > 6f)
            {
                isRushing = true;

                rushDirection = (player.transform.position - transform.position).normalized;

                Debug.Log("Are u ready?");

                ftime = 0;
            }

            if (isRushing)
            {
                if (ftime > 1f)
                {
                    isRushing = false;
                }
                transform.Translate(rushDirection * Time.smoothDeltaTime * bossSpeed * 10);

            }
        }
    }
}
