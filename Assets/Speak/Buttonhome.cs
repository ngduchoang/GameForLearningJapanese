using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonhome : MonoBehaviour {
    public static string testResult = "";
    public static string confidenceScore = "";
    DataLoaderSpeak dataLoaderSpeak;
    public GameObject questSpeak;
    public GameObject resultSpeak;
    public string result;
    public Sprite choose;
    GameObject playerSpeak;
    Sprite normal;
    public typeBotton type;
    bool creategameOver = false;
    void Start () {
        dataLoaderSpeak = Camera.main.GetComponent<DataLoaderSpeak>();
        playerSpeak = GameObject.Find("PlayerSpeak");
    }
	
	// Update is called once per frame
	void Update () {
        if (creategameOver==true&&!questSpeak.GetComponent<QuestSpeak>().checkSpeak(SpeakNow.speechResult().ToString().Trim())&&(SpeakNow.speechResult().ToString().Trim())!="")
        {
            playerSpeak.GetComponent<PlayerSpeak>().timeSpeak--;
            resultSpeak.GetComponent<TextMesh>().text = "False, please speak againt!!!";
            creategameOver = false;
        }
    }
    private void OnMouseDown()
    {
    }
    private void OnMouseExit()
    {

    }
    private void OnMouseUp()
    {
       
        if (type == typeBotton.buttonStartSpeak)
        {
            SpeakNow.startSpeech(LanguageUtil.JAPANESE);
            creategameOver = true;
        }
        if (type == typeBotton.buttonCheckSpeak)
        {
            if (questSpeak.GetComponent<QuestSpeak>().checkSpeak(SpeakNow.speechResult().ToString().Trim()))
            {
                playerSpeak.GetComponent<PlayerSpeak>().pointSpeak++;
                questSpeak.GetComponent<QuestSpeak>().incDem();
                questSpeak.GetComponent<QuestSpeak>().updateQuestSpeak(questSpeak.GetComponent<QuestSpeak>().dem);
                SpeakNow.reset();
            }
        }
    }
    public enum typeBotton
    {
        buttonStartSpeak,
        buttonCheckSpeak,
        
    }
  
}
