using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListening : MonoBehaviour {
    DataLoaderListenning dataLoaderListenning;
    public string result;
    public int dem =1;
    bool isread = false;
    private string engineName = "";
    public AudioSource _audio;
    public bool one = true;
    // Use this for initialization
    void Start()
    {
       EasyTTSUtil.Initialize(EasyTTSUtil.Japan);
        engineName = EasyTTSUtil.GetDefaultEngineName();
        dataLoaderListenning = Camera.main.GetComponent<DataLoaderListenning>();
       DownloadTheAudio(dem);
        EasyTTSUtil.SpeechAdd(result);
    }
    private void Update()
    {
        if (one)
        {
            EasyTTSUtil.SpeechAdd(result);
            one = false;
        }
    }
    public bool isChooseCorrect(string choose)
    {
        if (choose == result.Trim())
        {
            dem++;
            DownloadTheAudio(dem);
            one = true;
            return true;
        }
        else
        {
            dem++;
            DownloadTheAudio(dem);
            one = true;
            return false;
        }       
    }
   
    public  void DownloadTheAudio(int dem)
    {
        result = dataLoaderListenning.GetDataValue(dataLoaderListenning.items[dataLoaderListenning.indexquests[dem]], "Kanji:");
        //EasyTTSUtil.SpeechAdd(result);
    }
}

