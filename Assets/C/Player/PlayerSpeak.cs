using UnityEngine;
using System.Collections;

public class PlayerSpeak : MonoBehaviour {
    public int pointSpeak=0;
    public int timeSpeak = 3;
    GameObject gameOver;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (timeSpeak == 0)
        {
            gameOver = Instantiate(Resources.Load<GameObject>("GameOver")) as GameObject;
            timeSpeak = 3;
        }
	}
}
