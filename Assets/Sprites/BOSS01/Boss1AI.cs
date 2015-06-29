using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss1AI : MonoBehaviour {
    public enum state { }
    private float time;
	void Start () {
	
	}
	
	void Update () {
        time += Time.deltaTime;
        if (time > 1.5f)
            rigidbody.velocity = transform.forward *0.5f;
	
	}

}
