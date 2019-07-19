using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Fireto(GameObject txt)
    {
        transform.position = Vector3.Lerp(transform.position, txt.transform.position, 60* Time.deltaTime);
        txt.GetComponent<txt>().canchecktofire = true;
    }
   
}