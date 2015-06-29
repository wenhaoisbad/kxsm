using UnityEngine;
using System.Collections;

public class AngleBetweenUnit : MonoBehaviour
{
    public GameObject target;
    public float velocity;

    
    void Update()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(90,  NTMath.AngleBetweenVector3(target.gameObject.transform.position, transform.position),0)), Time.time * velocity);
      //     transform.LookAt(target.transform.position, Vector3.forward);
        //    transform.rotation = Quaternion.Lerp(target.gameObject.transform.rotation, transform.rotation, Time.time * velocity);
          //         var relativePos = target.gameObject.transform.position - transform.position;
          //         transform.rotation = Quaternion.LookRotation(target.gameObject.transform.position, Vector3.forward);
        }
    }
}
