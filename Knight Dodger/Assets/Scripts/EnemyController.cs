using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;
    public float stoppingDistance = 2f;
    public float moveSpeed;
    public float acceleration;

    Transform target;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        target = PlayerManger.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            FaceToTarget();
            if (distance >= stoppingDistance)
            {
                moveSpeed += Time.deltaTime * acceleration;
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * 50);
            }
            else
            {
                FindObjectOfType<GameManger>().EndGame();
            }

        }
        else
        {
            Destroy(gameObject);
        }
	}

    void FaceToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
