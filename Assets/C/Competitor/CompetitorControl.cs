using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorControl : MonoBehaviour {
    public GameObject fireprefab;
    public bool isCreated;
    int maxTime = 20;
    int minTime = 10;
    //current time
    public float time;
    //The time to spawn the object
    private float spawnTime;
   GameObject Quest;
    GameObject[] txts;
    public float currentHP;
    public float maxHP;
    GameObject healthBarmini;
    GameObject spawnCompetitor;
    // Use this for initialization
    private void Awake()
    {
        healthBarmini = GameObject.FindGameObjectWithTag("HearthCompetitor");
        Quest = GameObject.Find("QuestRead");
        spawnCompetitor = GameObject.Find("SpawnCompetitor");
    }
    void Start () {
        Updatetxts();
        SetRandomTime();
        time = minTime;

        time = Time.time + Random.Range(3, 6);
    }
   
    // Update is called once per frame
    void Update () {
        UpdateHearthBar();
        Updatetxts();
        //time += Time.deltaTime;
        ////Check if its the right time to spawn the object
        //if (time >= spawnTime)
        //{
        //    UpdateTarget();
        //    SetRandomTime();
        //}

        if (time < Time.time) {
            UpdateTarget();
            time = Time.time + Random.Range(3, 6);
        }

    }
    public void Throwing(GameObject txt)
    {
        //if (!isCreated)
       // {
            time = 0;
            new WaitForSeconds(2.0f);
            GetComponent<Animator>().Play("Player"+ spawnCompetitor.GetComponent<SpawnCompetitor>().randumIndexCompetitor+ "Throwing");
            GameObject shoot = Instantiate(fireprefab, transform.position, Quaternion.identity) as GameObject;
            shoot.GetComponent<Fire>().Fireto(txt);
             txt.GetComponent<txt>().playerfired = this.gameObject;
             txt.GetComponent<txt>().isfire = false;
          //  isCreated = true;
       // }
    }
    public void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    void UpdateTarget()
    {
        for(int i=0;i<txts.Length;i++)
        {
            if (Application.loadedLevelName == "Read")
                if (txts[i].GetComponent<TextMesh>().text== Quest.GetComponent<Quest>().result)
                     Throwing(txts[i]);
            if (Application.loadedLevelName == "Listen")
                if (txts[i].GetComponent<TextMesh>().text == Quest.GetComponent<QuestListening>().result)
                     Throwing(txts[i]);
        }
    }
    void Updatetxts()
    {
        txts = GameObject.FindGameObjectsWithTag("text");
    }
    void UpdateHearthBar()
    {
        if (currentHP > 0)
        {
            float x = currentHP / maxHP;
            if (x != 1)
                healthBarmini.transform.localScale = new Vector3(x * 0.045f, healthBarmini.transform.localScale.y, 1);
            else
                healthBarmini.transform.localScale = new Vector3(0.05f, healthBarmini.transform.localScale.y, 1);
        }
        else
        {

            healthBarmini.transform.localScale = new Vector3(0, 0.02f, 1);
        }
    }
}
