using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour
{
    public bool isUpdate;
    public GameObject unit;
    public int size=5;
    float distance = 1f;
    void Update()
    {
        if (!isUpdate) return;
        isUpdate = false;
        Create();
    }
    void Create()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size - i; j++)
            {
                (Instantiate(unit, gameObject.transform.position + new Vector3(i/2f+j-(size-1)/2 , 0, distance * (i+1) ), unit.transform.rotation) as GameObject).transform.parent = gameObject.transform;
            }
        }
    }
}
