using UnityEngine;
using System.Collections;

public class Trace : MonoBehaviour {
    Transform Player;
    public Done_Boundary boundary;
    float time = 0;
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}

   
    void FixedUpdate()
    {
        
        time += Time.deltaTime;
        if (time > 3.5f)
        {
            rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z  -20*Time.deltaTime);
        }

        if (time <=3.5f)
        {
            if (Player==null) return;
            float newManeuver = Mathf.MoveTowards(transform.position.x, Player.position.x, 3 * Time.deltaTime);
       //     Debug.Log("==>"+newManeuver);
       //     rigidbody.velocity = new Vector3(newManeuver, 0.0f, rigidbody.velocity.z);
            rigidbody.position = new Vector3
            (
                Mathf.Clamp(newManeuver, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
             );
        }
        

  //      rigidbody.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.x * -tilt);
    }
}
