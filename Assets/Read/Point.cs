using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {
    GameObject player;
    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevelName == "Listen" || Application.loadedLevelName == "Read")
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (Application.loadedLevelName == "Speak")
        {
            player = GameObject.FindGameObjectWithTag("PlayerSpeak");
        }
    }
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName == "Listen" || Application.loadedLevelName == "Read")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<TextMesh>().text = player.GetComponent<PlayerControl>().point.ToString();

        }
        if (Application.loadedLevelName == "Speak")
        {
            player = GameObject.FindGameObjectWithTag("PlayerSpeak");
            GetComponent<TextMesh>().text = player.GetComponent<PlayerSpeak>().pointSpeak.ToString();
        }
    }
}
