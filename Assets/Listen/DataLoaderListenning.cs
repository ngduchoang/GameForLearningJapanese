using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoaderListenning : MonoBehaviour {
    public string[] items;
    public int[] indexitems;
    public int lengthitems;

    public int[] indexquests;
    public int lengthquests;

    public GameObject GridListening;
    public GameObject QuestListening;
    public GameObject SpawnCompetitor;

    GameObject[] txts;
    public int lengthitemsBegin, lengthitemsEnd, lengthitemstotal;
    public int lengthquestsBegin, lengthquestsEnd, lengthqueststotal;
    public int numMock = 10;
    public bool isActiveGrid = false;
    // Use this for initialization
    IEnumerator Start()
    {
        indexitems = new int[1000];
        indexquests = new int[1000];
        WWW itemsData = new WWW("https://japanese-190203.appspot.com/");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        items = itemsDataString.Split(';');
        setActive();
        lengthitemstotal = items.Length - 1;
        lengthqueststotal = items.Length - 1;
        lengthitemsBegin = 0;
        lengthitemsEnd = numMock;
        lengthquestsBegin = 0;
        lengthquestsEnd = numMock;
        mixquests();
        mixitems();
    }
    private void Update()
    {
        txts = GameObject.FindGameObjectsWithTag("text");
        if (txts.Length == 0)
        {
            lengthitemsBegin += numMock;
            lengthitemsEnd += numMock;
            lengthquestsBegin += numMock;
            lengthquestsEnd += numMock;
            mixquests();
            mixitems();
            isActiveGrid = true;
        }
        else
        {
            isActiveGrid = false;
        }
    }
    void setActive()
    {
        GridListening.SetActive(true);
        QuestListening.SetActive(true);
        SpawnCompetitor.SetActive(true);
    }
    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    void mixitems()
    {
        for (int i = lengthitemsBegin; i < lengthitemsEnd; i++)
        {
            indexitems[i] = i;
        }
        for (int i = lengthitemsBegin; i < lengthitemsEnd; i++)
        {
            int temp = indexitems[i];
            int index = Random.Range(i, lengthitemsEnd);
            indexitems[i] = indexitems[index];
            indexitems[index] = temp;
        }
    }
    void mixquests()
    {
        for (int i = lengthquestsBegin; i < lengthquestsEnd; i++)
        {
            indexquests[i] = i;
        }
        for (int i = lengthquestsBegin; i < lengthquestsEnd; i++)
        {
            int temp = indexquests[i];
            int index = Random.Range(i, lengthquestsEnd);
            indexquests[i] = indexquests[index];
            indexquests[index] = temp;
        }
    }
}
