using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
    
	void Start () {
	
	}
	
	void Update () {
        gameObject.transform.localPosition += new Vector3(0, 0.01f, 0);
	}
}
