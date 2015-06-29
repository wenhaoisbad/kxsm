using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour {

    public bool spellCast;
    public GameObject unit;
    public int size;
    float distance = 1f;
    void Start()
    {

    }
    void Update()
    {
        if (spellCast == true)
        {
            InvokeRepeating("SpellCast", 0, 0.5f);//从第一次调用开始,每隔repeatRate时间调用一次.
            spellCast = false;
            count = 0;
        }
    }
    int count;
    void SpellCast()
    {
        count++;
        for (int i = 0; i < size; i++)
        {
            Instantiate(unit, NTMath.PolarProjection(gameObject.transform.position, distance, 360 / size * i), Quaternion.Euler(new Vector3(0, 360 / size * (1+ i)+30, 0)));
        }
        if(count>=6){
            CancelInvoke("SpellCast");
        }
    }
}
