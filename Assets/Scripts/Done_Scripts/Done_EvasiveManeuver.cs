using UnityEngine;
using System.Collections;

public class Done_EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	void Start ()
	{
		currentSpeed = rigidbody.velocity.z;
		StartCoroutine(Evade());
	}
	
	IEnumerator Evade ()
	{
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));//在给定的秒数内，暂停协同程序的执行。
		while (true)
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate ()
    {                  //MoveTowards:改变一个当前值向目标值靠近。
		float newManeuver = Mathf.MoveTowards (rigidbody.velocity.x, targetManeuver, smoothing * Time.deltaTime);
		rigidbody.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
	//	rigidbody.rotation = Quaternion.Euler (0, -180, rigidbody.velocity.x * -tilt);
	}
}
