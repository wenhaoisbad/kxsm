using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathController : MonoBehaviour {

    public Transform[] pts;
    List<Vector3> outputs = new List<Vector3>();
    void Start()
    {
        outputs = SplineBuild.InterpolateCR(pts, 4, 0.03f);
        NTSystrm.Serializer<List<Vector3>>(outputs, "E:\\adt-bundle\\test.txt");
        for (int i = 0; i < outputs.Count; i++)
        {
            outputs[i] += gameObject.transform.position;
        }
        if (GetComponent<MoveOnPath>()!=null)
          GetComponent<MoveOnPath>().StartOnPath(outputs, null);
    }
    public List<Vector3> path
    {
        get
        {
            return outputs;
        }
    }
}
