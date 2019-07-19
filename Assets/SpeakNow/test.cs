using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    public static string testResult = "";
    public static string confidenceScore = "";
    DataLoaderSpeak dataLoaderSpeak;
    // QuestSpeak questSpeak;
    public string result;
    public int dem =0;
    private void Start()
    {
        dataLoaderSpeak = Camera.main.GetComponent<DataLoaderSpeak>();
        result = dataLoaderSpeak.GetDataValue(dataLoaderSpeak.items[dataLoaderSpeak.indexquests[dem]], "Kanji:").Trim();
        gameObject.GetComponent<TextMesh>().text = result;
    }
    void OnGUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 200, 200, 150), "Start Speech"))
            {
                SpeakNow.startSpeech(LanguageUtil.JAPANESE);
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 150), "Reset"))
            {
                
                if (checkSpeak(SpeakNow.speechResult().ToString().Trim()))
                {
                 //   GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 350, 200, 200), " Exactly ");
                    incDem();
                    updateQuestSpeak(dem);
                    SpeakNow.reset();
                }
                //else
                  //  GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 450, 200, 200), " no correct ");
                
            }

            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 230, 200, 200), "Speech Result : " + SpeakNow.speechResult());
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 260, 200, 200), "Quest : " + result);
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 350, 200, 200), checkSpeak(SpeakNow.speechResult().ToString().Trim()) ? "Exactly" : " no correct");
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 300, 200), "Please Build and Run in Android and see documentation for usage of functionalities.");
        }
    }
    void updateQuestSpeak(int dem)
    {
        result = dataLoaderSpeak.GetDataValue(dataLoaderSpeak.items[dataLoaderSpeak.indexquests[dem]], "Kanji:").Trim();
        gameObject.GetComponent<TextMesh>().text = result;
    }
    public bool checkSpeak(string str)
    {
        if (str == result)
            return true;
        else
            return false;
    }
    public void incDem()
    {
        dem++;
    }
}
