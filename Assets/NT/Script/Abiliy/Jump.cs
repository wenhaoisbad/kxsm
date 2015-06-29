using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rigidbody.velocity = new Vector3(-8,8,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
