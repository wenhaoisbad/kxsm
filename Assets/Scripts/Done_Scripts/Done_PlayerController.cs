using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    bool isDown;
    public Done_Boundary boundary;

    public GameObject shot;
    public GameObject shot2;
    public Transform[] shotSpawn;
    public float fireRate;
    Vector3 point, touch, excursion;
    private float nextFire;
    void Start()
    {
        rigidbody.velocity = transform.forward * 0.5f; //设置刚体的速度向v3移动
    }
    void Update()
    {
        shoot();
        mover();
    }
    private void shoot()
    {
        if (Time.time > nextFire)
        {
            for (int i = 0; i < shotSpawn.Length; i++)
            {
                Unit.last = Instantiate(shot2, shotSpawn[i].position, shotSpawn[i].rotation) as GameObject;
                Unit.last.tag = tag;
                Unit.last.GetComponent<Dejectile>().attackForce = GetComponent<Unit>().attack.force;
            }
   //         shotSpawn[0].position = shotSpawn[2].position+new Vector3(2*Mathf.Sin(Time.deltaTime*10), 0, 0);
    //        shotSpawn[1].position = shotSpawn[2].position + new Vector3(2 * Mathf.Sin(Time.deltaTime * 10), 0, 0);
    //        shotSpawn[3].position = shotSpawn[2].position + new Vector3(2 * Mathf.Sin(Time.deltaTime * 10), 0, 0);
   //         shotSpawn[4].position = shotSpawn[2].position + new Vector3(2 * Mathf.Sin(Time.deltaTime * 10), 0, 0);
            nextFire = Time.time + fireRate;
            audio.Play();
        }
    }
    private void mover()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //当射线彭转到对象时
            //按下得到鼠标位置，移动改变位置，上一次鼠标位置减当前鼠标位置
            //hit.point，                   touch-hit.point
            if (Physics.Raycast(ray, out hit))
            {
                if (!isDown) { touch = hit.point; }
                excursion = hit.point - touch;
                transform.position=Vector3.Lerp(transform.position, transform.position + new Vector3(excursion.x, 0, excursion.z),0.65f);
                
                touch = hit.point;//上一次触摸位置
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            transform.FindChild("sprite").GetComponent<SkeletonAnimation>().AnimationName = "fly_right";    
            rigidbody.velocity = transform.forward * 0; ////设置刚体的速度向v3移动
            isDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.FindChild("sprite").GetComponent<SkeletonAnimation>().AnimationName = "standby";
            rigidbody.velocity = transform.forward * 0.5f; ////设置刚体的速度向v3移动
            isDown = false;
        }
    }
}
