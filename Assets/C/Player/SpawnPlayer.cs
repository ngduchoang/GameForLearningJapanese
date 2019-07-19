using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        GameObject go = Instantiate(Resources.Load<GameObject>("Player"+ (PlayerPrefs.GetInt("dem")+1))) as GameObject;
        go.transform.position = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
    }
}
