using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameObject Platform;
    public Transform GenerationPoint;

    private float platformwidth;

    public GameObject[] Platforms;
    private int platformSelector;

	// Use this for initialization
	void Start () {
        platformwidth = Platform.GetComponent<BoxCollider>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > GenerationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x - platformwidth, transform.position.y, transform.position.z);

            platformSelector = Random.Range(0, Platforms.Length);

            Instantiate(Platforms[platformSelector], transform.position, transform.rotation);
        }
        
	}
}
