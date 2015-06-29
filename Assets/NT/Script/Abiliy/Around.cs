using UnityEngine;
using System.Collections;

public class Around : MonoBehaviour {

    public Unit target;//自己
    public Unit[] satellite;//围绕单位
    public float Rate = 1;//旋转速度
    public float distance = 1;//距离
    float j = 0;
    void FixedUpdate()
    {
        j += Time.deltaTime * Rate;
        for (int i = 1; i <= satellite.Length; i++)
        {
            satellite[i - 1].transform.position = target.transform.position + new Vector3(distance * Mathf.Cos(2 * Mathf.PI / satellite.Length * i + j), 0, distance * Mathf.Sin(2 * Mathf.PI / satellite.Length * i + j));
        }
    }
}
