using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Background")
        {
            other.gameObject.transform.localPosition += new Vector3(0, 3f, 0);
            return;
        }
        if (other.tag == "Player" && other.gameObject.GetComponent<Unit>() != null)
        {
        }
        Destroy(other.gameObject);
    }

}