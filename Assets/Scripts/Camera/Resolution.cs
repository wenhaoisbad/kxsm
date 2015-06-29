using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

    void Start()
    {
        Screen.SetResolution(640, 960, true);
    }
}
