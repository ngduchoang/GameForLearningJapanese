using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCompetitor : MonoBehaviour {
    public GameObject competitorprefab;
    public bool isCreated;
    public int randumIndexCompetitor;
    // Use this for initialization
    void Start () {
        randumIndexCompetitor = Random.Range(1, 6);
        GameObject go = Instantiate(Resources.Load<GameObject>("Competitor" + (randumIndexCompetitor))) as GameObject;
        go.transform.position = this.transform.position;
        isCreated = true;
    }
	
	// Update is called once per frame
	void Update () {
        Spawn();
    }
    void Spawn()
    {
        GameObject co = GameObject.FindGameObjectWithTag("competitor");
        if (co)
        {
            if (co.GetComponent<CompetitorControl>().currentHP < 10)
            {
                Destroy(co);
                isCreated = false;
            }
        }
        else
        {
            if (!isCreated)
            {
                GameObject go = Instantiate(Resources.Load<GameObject>("Competitor" + (Random.Range(1,6) + 1))) as GameObject;
                go.transform.position = this.transform.position;
                isCreated = true;
            }
        }
    }
}
