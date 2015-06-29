using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<ScriptController>() != null)
        {
            ScriptController sc = other.gameObject.GetComponent<ScriptController>();
                for(int i=0;i<sc.script.Length;i++){
                    (other.gameObject.GetComponent(sc.script[i]) as MonoBehaviour).enabled = true;
                }
        }
        if (other.tag=="Father")
        {
            foreach (Transform child in other.gameObject.transform)
            {
                Debug.Log("a0"+child.gameObject.name);
            }
        }
    }
}
