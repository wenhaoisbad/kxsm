using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public enum ANGLE { x, y, z };
    public ANGLE angle;
    public float speed;
    private Vector3 v3;
    float time;
	void Start () {
        switch(angle){
            case ANGLE.x:
                v3 = transform.right;
                break;
            case ANGLE.y:
                v3 = transform.up;
                break;
            case ANGLE.z:
                v3 = transform.up;
                break;
        }
        rigidbody.velocity = v3 * speed; ////设置刚体的速度向v3移动
	}
    void Update()
    {
        
      //      Debug.Log(time); //0.5f速度90秒一格
    }
}
