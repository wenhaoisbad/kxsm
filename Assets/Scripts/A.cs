using UnityEngine;
using System.Collections;

public class A : MonoBehaviour {
    public GameObject ys;
    public Vector3 spawnValues;
    float time=0;

    
	void Update () {
        time += Time.deltaTime;
        if (time>1.5f)
        {
            time = 0;
            Create();
        }
    }
    void Create()
    {
        for (int i = 0; i < 13;i++ ) {
            Vector3 spawnPosition = new Vector3(-spawnValues.x + 10/5 * i, spawnValues.y, spawnValues.z);
          //  Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ys, spawnPosition, ys.transform.rotation);
        }
    }
}
