using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hero;
    public GameObject restart;
	void Start () {
	
	}
	
	void Update () {
        if(hero==null){
            restart.SetActive(true);
        }
	}
    public void Restart()
    {
        Application.LoadLevel("Main");
    }
    public void Exit()
    {
        Application.Quit(); 
    }
}
