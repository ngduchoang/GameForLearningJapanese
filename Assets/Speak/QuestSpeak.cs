using UnityEngine;
using System.Collections;

public class QuestSpeak : MonoBehaviour {
    DataLoaderSpeak dataLoaderSpeak;
    public string result;
    public int dem = 0;
    // Use this for initialization
    void Start()
    {
        dataLoaderSpeak = Camera.main.GetComponent<DataLoaderSpeak>();
    }
    private void Update()
    {
        updateQuestSpeak(dem);
    }
    public void updateQuestSpeak(int dem)
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
