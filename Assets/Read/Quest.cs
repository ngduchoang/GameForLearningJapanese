using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Quest : MonoBehaviour
{

    DataLoader dataLoader;
    TextMesh textMesh;
    public string j1, j2, j3, result;
    public int dem=0;
    void Start () {
       dataLoader = Camera.main.GetComponent<DataLoader>(); 
    }
    private void Update()
    {
            CmdupdateQuest(dem);
    }
    void CmdupdateQuest(int dem)
    {
        result = dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "Kanji:");
        if (int.Parse(dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "itme:")) == 1)
            j1 = "<color=#4B088A>" + dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "j1:") + "</color>";
        else
            j1 = dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "j1:");
        if (int.Parse(dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "itme:")) == 2)
            j2 = "<color=#4B088A>" + dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "j2:") + "</color>";
        else
            j2 = dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "j2:");
        if (int.Parse(dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "itme:")) == 3)
            j3 = "<color=#4B088A>" + dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "j3:") + "</color>";
        else
            j3 = dataLoader.GetDataValue(dataLoader.items[dataLoader.indexquests[dem]], "j3:");
        gameObject.GetComponent<TextMesh>().text = j1 + j2 + j3;
    }
    public bool isChooseCorrect(string choose)
    {
        if (choose == result)
            return true;
        else
            return false;
    }
}
