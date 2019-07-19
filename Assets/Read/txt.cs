using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class txt : MonoBehaviour { 



    public bool isfire = false;
    public GameObject player;
    GameObject fire;

    GameObject gameobjectquest;
    Quest quest;
    GameObject gameobjectquestListening;
    QuestListening questListening;
    GameObject Competitor;

    public bool canchecktofire =false;
    public GameObject playerfired;
    void Start () {
        fire = GameObject.Find("Fire(Clone)");
        player = GameObject.FindGameObjectWithTag("Player");
        if (Application.loadedLevelName == "Read")
        {
            gameobjectquest = GameObject.Find("QuestRead");
            quest = gameobjectquest.GetComponent<Quest>();
        }
        if (Application.loadedLevelName == "Listen")
        {
            gameobjectquestListening = GameObject.Find("QuestListening");
            questListening = gameobjectquestListening.GetComponent<QuestListening>();
        }
    }
    void OnMouseDown()
    {
        isfire = true;
        player.GetComponent<PlayerControl>().isCreated = false;
    }
    void Update () {
       if (Application.loadedLevelName == "Read")
        {

            gameobjectquest = GameObject.Find("QuestRead");
            quest = gameobjectquest.GetComponent<Quest>();
            player = GameObject.FindGameObjectWithTag("Player");
           Competitor = GameObject.FindGameObjectWithTag("competitor");
        }
        if (fire)
            fire.GetComponent<Fire>().Fireto(gameObject);
        if (isfire)
            player.GetComponent<PlayerControl>().Throwing(gameObject);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (Application.loadedLevelName == "Read")
        {
            if (col.gameObject.tag == "fire" && canchecktofire == true)
            {
                


                if (quest.isChooseCorrect(gameObject.GetComponent<TextMesh>().text))
                {
                    if(gameObject.GetComponentInChildren<SpriteRenderer>().color==Color.red)
                    {
                        if (playerfired.tag == "Player")
                            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().currentHP += 20;
                        if (playerfired.tag == "competitor")
                            GameObject.FindGameObjectWithTag("competitor").GetComponent<CompetitorControl>().currentHP += 20;
                    }
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                    if (playerfired.tag == "Player")
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().point++;
                        GameObject.FindGameObjectWithTag("competitor").GetComponent<CompetitorControl>().currentHP -= 20;
                    }
                    if (playerfired.tag == "competitor")
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().currentHP -= 20;
                      
                    Competitor.GetComponent<CompetitorControl>().SetRandomTime();
                    isfire = false;
                    quest.dem++;
                    canchecktofire = false;
                    Competitor.GetComponent<CompetitorControl>().time = Time.time + Random.Range(3, 5);
                }
                if (!quest.isChooseCorrect(gameObject.GetComponent<TextMesh>().text))
                {
                    Destroy(col.gameObject);
                    isfire = false;
                    quest.dem++;
                    canchecktofire = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().currentHP -= 20;
                }

            }
        }
        if (Application.loadedLevelName == "Listen")
        {
            if (col.gameObject.tag == "fire" && canchecktofire == true)
            {
                if (questListening.isChooseCorrect(gameObject.GetComponent<TextMesh>().text.Trim()))
                {
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                    if (playerfired.tag == "Player")
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().point++;
                        GameObject.FindGameObjectWithTag("competitor").GetComponent<CompetitorControl>().currentHP -= 20;
                    }
                    if (playerfired.tag == "competitor")
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().currentHP -= 20;

                    Competitor.GetComponent<CompetitorControl>().SetRandomTime();
                    isfire = false;
                    //questListening.dem++;
                    //questListening.DownloadTheAudio(questListening.dem);
                    //questListening.one = true;
                    canchecktofire = false;
                }
                if (!questListening.isChooseCorrect(gameObject.GetComponent<TextMesh>().text.Trim()))
                {
                    Destroy(col.gameObject);
                    isfire = false;
                    //questListening.dem++;
                    ////questListening.DownloadTheAudio(questListening.dem);
                    //questListening.one = true;
                    canchecktofire = false;
                }
           
            }
        }
    }
}
