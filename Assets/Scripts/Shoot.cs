using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    float time;
    public float fireRate;
    public GameObject unit;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > fireRate)
        {
            time = 0;
            Unit.last=Instantiate(unit, transform.position+new Vector3(0,0,1), transform.rotation)as GameObject;
            Unit.last.GetComponent<Dejectile>().attackForce = 100;
            Unit.last.GetComponent<Dejectile>().Speed = 6;
            Unit.last.GetComponent<Dejectile>().Track = true;
            Unit.last.tag = tag;
        }
	}
}
