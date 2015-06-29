using UnityEngine;
using System.Collections;

public class Spiral : MonoBehaviour {
    public bool isUpdate;
    public GameObject unit;
    public int size=9;
    public int number=7;
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
            for (int j = 1; j <= number; j++)
            {
                (Instantiate(unit, gameObject.transform.position + new Vector3(distance * j * Mathf.Sin(2 * Mathf.PI / size * (i + 0.1f * j)), 0, distance * j * Mathf.Cos(2 * Mathf.PI / size * (i + 0.1f * j))), unit.transform.rotation) as GameObject).transform.parent = gameObject.transform;
            }
        }
    }
}
