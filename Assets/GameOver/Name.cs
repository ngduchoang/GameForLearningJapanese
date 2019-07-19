using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Name : MonoBehaviour {
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
       player.GetComponent<PlayerControl>().name = gameObject.GetComponent<InputField>().text;
	}
}
