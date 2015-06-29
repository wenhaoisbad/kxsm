using UnityEngine;
using System.Collections;
/**
 * 投射物专用脚本
 * */
public class Dejectile : MonoBehaviour {
    private float AttackForce;//攻击力
    public float Speed;       //射弹速率
    public bool Track;       //射弹跟踪
    void Start()
    {
        Destroy(gameObject,10);
        rigidbody.velocity = transform.up * Speed; ////设置刚体的速度沿着物体的Z轴移动
	}
	
	void Update () {

        if (Track == true)
        {
            Collider[] c = Physics.OverlapSphere(NTMath.PolarProjection(transform.position, 2.5f, transform.rotation.y), 5);
            if (c.Length <= 0) return;
            if (c[1].gameObject.GetComponent<Unit>()!=null&&c[1].gameObject.tag!="Player")
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, NTMath.AngleBetweenVector3(transform.position, c[1].gameObject.transform.position))), Time.time * 0.01f);
                rigidbody.velocity = transform.up * Speed; 
            }
            
       }
	}
    public float attackForce
    {
        get
        {
            return AttackForce;
        }
        set
        {
            AttackForce = value;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (tag == other.tag || other.GetComponent<Unit>() == null || other.GetComponent<Dejectile>() != null)
        {
            return;
        }
        if (other.GetComponent<Unit>().hp > 0)
        {
            Destroy(gameObject);
            other.GetComponent<Unit>().hp -= AttackForce;
        }
    }
}
