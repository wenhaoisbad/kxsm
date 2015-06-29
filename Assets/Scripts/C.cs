using UnityEngine;
using System.Collections;

public class C : MonoBehaviour {

    public GameObject ys;
     GameObject Player;
    public Vector3 spawnValues;
    float time = 0;
	void Start () {
        Player=GameObject.FindGameObjectWithTag("Player") as GameObject;
        Create();
	}
	
	void Update () {
        if (Player==null)
        {
            return;
        }
        time += Time.deltaTime;
        if (time >= 10)
        {
            time = 0; 
            Create();
        }
	}
    void Create()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(ys, spawnPosition, ys.transform.rotation);
    }
}
