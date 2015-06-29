using UnityEngine;
using System.Collections;

public class B : MonoBehaviour {

    public GameObject fj;
    float time = 0;
    int i = 0;
    Vector3[] v3 = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0.8f, 0, -1.1f), new Vector3(1.9f, 0, -2.7f), new Vector3(3, 0, -4)
    ,new Vector3(4, 0, -4.9f),new Vector3(5, 0, -5.5f),new Vector3(6, 0, -6f),new Vector3(7, 0, -6.4f),new Vector3(8, 0, -6.8f),new Vector3(9, 0, -7f)
    ,new Vector3(10, 0, -7.1f),new Vector3(11, 0, -7f),new Vector3(12, 0, -7f)};
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            i++;
            time = 0;
            if (i <= 5)
            {

                Unit.last = Instantiate(fj, new Vector3(-7.5f, 0, 16), fj.transform.rotation) as GameObject;
                Unit.last.transform.rotation = Quaternion.Lerp(fj.transform.rotation, Quaternion.Euler(new Vector3(0, 360, 0)), 0.01f);
                fj.rigidbody.velocity = fj.transform.up * 5; ////设置刚体的速度沿着物体的Z轴移动
            //    Create();
            }
            if (i >= 13 && i < 18)
            {
                Unit.last=Instantiate(fj, new Vector3(-7.5f, 0, 16), Quaternion.Euler(new Vector3(0, 0, 0)))as GameObject;
                Unit.last.transform.rotation = Quaternion.Lerp(Unit.last.transform.rotation, Quaternion.Euler(new Vector3(0, 145, 0)),Time.time*2);
           //     Instantiate(fj, new Vector3(8.5f, 0, 16), Quaternion.Euler(new Vector3(0, -145, 0)));
            }
            if (i >= 24)
            {
                i = 0;
            }
        }
    }
    void Create()
    {
        Instantiate(fj, new Vector3(-7.5f, 0, 16), fj.transform.rotation);
        Instantiate(fj, new Vector3(7.5f, 0, 16), fj.transform.rotation);
    }
    int j = 0;
    void recursion(GameObject unit, Vector3[] v3){
        j++;
        if (unit.transform.position!= v3[j])
          {
              unit.transform.position = Vector3.Lerp(unit.transform.position, unit.transform.position+v3[j], 0.1f);
          }
    }
}
