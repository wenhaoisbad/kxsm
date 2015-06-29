using UnityEngine;
using System.Collections;

[System.Serializable]
public class Attack
{
    public GameObject shot;    //投射物
    public Transform shotSpawn;//投射物位置
    //    public float speed;       //射弹速率
    //    public bool track;       //射弹跟踪
    public float force;   //攻击力
    public float fireRate;   //攻击间隔
    public float delay;    //攻击缓冲
}
public class Unit : MonoBehaviour
{
    public static GameObject last;//最后创建的单位
    public enum TagType { 地面, 空中 }
    //     public Vector3 position;//位置
    //     public int life;//生命值
    //     public int mana;//魔法值
    //     public bool invulnerable = true;

    public Attack attack;
    public TagType tagType;//目标类型
    public float MovementSpeed;
    public float Hp;
    public GameObject die;//死亡效果
    void Start()
    {
        if (attack.shot != null && attack.shotSpawn != null)
        {
            InvokeRepeating("Fire", attack.delay, attack.fireRate);//从第一次调用开始,每隔repeatRate时间调用一次.
        }
    }
    void Update()
    {
        if (tag != "Player")
        {
            rigidbody.velocity = transform.forward * MovementSpeed; ////设置刚体的速度沿着物体的Z轴移动
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Unit>() == null || tag == other.tag) return;
        Unit u = other.GetComponent<Unit>();
        if (u.tagType == Unit.TagType.空中 && tagType == Unit.TagType.空中)
        {
            kill();
            u.kill();
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary" && tag != "Player")
        {
            Destroy(gameObject);
        }
    }
    void Fire()
    {
        GameObject unit = Instantiate(attack.shot, attack.shotSpawn.position, attack.shotSpawn.rotation) as GameObject;
        unit.tag = tag;
        unit.GetComponent<Dejectile>().attackForce = attack.force;
        if (audio != null)
            audio.Play();
    }
    //对目标造成伤害
    public void DamageTarget(Unit target, float amount)
    {
        target.hp -= amount;
        if (target.hp <= 0)
        {
            target.kill();
        }
    }
    //杀死单位
    public void kill()
    {
        Destroy(gameObject);
        if (die != null)
        {
            Destroy(Instantiate(die, transform.position, transform.rotation), 3);
        }
    }
    public void jump()
    {
        Debug.Log("jump");
        rigidbody.velocity = Vector3.up * 5;
    }
    public void MoveBy(Vector3 position)
    {
    }
    //移动
    public void MoveBy(float x, float y, float z)
    {
    }
    //攻击
    public void Attack(Unit u)
    {
    }
    //添加技能
    public void AddAbility(Ability abilityId)
    {
    }
    //删除技能
    public void RemoveAbility(Ability abilityId)
    {
    }
    public Vector3 position
    {
        get
        {
            return transform.position;
        }
        set
        {

        }

        //     transform.position = position;

    }
    //设置生命值
    public float hp
    {
        get
        {
            return Hp;
        }
        set
        {
            Hp = value;
            if (Hp <= 0)
            {
                kill();
            }
        }
    }
    //设置魔法值
    public float mana
    {
        get;
        set;
    }
    //显示/隐藏单位
    public bool show
    {
        get;
        set;
    }
    //设置单位为无敌
    public bool invulnerable { get; set; }
    //暂停单位
    public bool pause { get; set; }


}
