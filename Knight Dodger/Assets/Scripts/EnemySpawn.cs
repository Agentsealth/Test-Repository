using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] enemy;
    public Transform enemyPos;
    Transform target;
    private float repeatRate = 5.0f;
    private int enemySelector;
    // Use this for initialization
    void Start () {
        target = PlayerManger.instance.player.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void EnemySpawner()
    {
        enemySelector = Random.Range(0, enemy.Length);
        Instantiate(enemy[enemySelector], enemyPos.position, Quaternion.identity);
    }
}
