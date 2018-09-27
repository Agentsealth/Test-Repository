using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {
    public Transform Player;
    public float offset;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.position + (Vector3.up * offset);
        //transform.Translate(new Vector3(offset, 0, 0));
    }
}
