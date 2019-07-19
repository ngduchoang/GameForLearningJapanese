using UnityEngine;
using System.Collections;

public class SpeakResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<TextMesh>().text = SpeakNow.speechResult();

    }
}
