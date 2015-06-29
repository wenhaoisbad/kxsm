using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour {
    public bool spellCast;
    public GameObject shot;    //投射物
    public Transform[] shotSpawn;
    public float fireRate;   //攻击间隔
    public float delay;    //攻击缓冲
	void Start () {
	}


    void Update()
    {
        if (spellCast == true)
        {
            spellCast = false;
            InvokeRepeating("SpellCast", delay, fireRate);//从第一次调用开始,每隔repeatRate时间调用一次.
        }
	}
    void SpellCast() {
        for (int i = 0; i < shotSpawn.Length; i++)
        {
            Unit.last=Instantiate(shot, shotSpawn[i].position, shotSpawn[i].rotation)as GameObject;
            Unit.last.tag = tag;
            Unit.last.GetComponent<Dejectile>().attackForce = GetComponent<Unit>().attack.force;
        }
    }
}
