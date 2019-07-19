using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataLoader :MonoBehaviour {
   
	public string[] items;
    public int[] indexitems;
    public int indexitemblood;
    public int[] indexquests;
    GameObject[] txts;
    public int lengthitemsBegin, lengthitemsEnd, lengthitemstotal;
    public int lengthquestsBegin, lengthquestsEnd, lengthqueststotal;
    public GameObject Grid;
    public GameObject Quest;
    public GameObject SpawnCompetitor;
    public int numMock=10;
    public bool isActiveGrid= false;

    IEnumerator Start(){
            indexitems = new int[1000];
            indexquests = new int[1000];
            WWW itemsData = new WWW("https://japaneseread.appspot.com/");
            yield return itemsData;
            string itemsDataString = itemsData.text;
            items = itemsDataString.Split(';');
             setActive();
            lengthitemstotal = items.Length - 1;
            lengthqueststotal = items.Length - 1;
            lengthitemsBegin = 0;
            lengthitemsEnd = numMock;
            lengthquestsBegin =0 ;
            lengthquestsEnd = numMock;
            Cmdmixquests();
            Cmdmixitems();
    }
    private void Update()
    {
        txts = GameObject.FindGameObjectsWithTag("text");
        if(txts.Length==0)
        {
            lengthitemsBegin += numMock;
            lengthitemsEnd += numMock;
            lengthquestsBegin += numMock;
            lengthquestsEnd += numMock;
            Cmdmixquests();
            Cmdmixitems();
            isActiveGrid = true;
        }
        else
        {
            isActiveGrid = false;
        }
    }
    void setActive()
    {
        Grid.SetActive(true);
          Quest.SetActive(true);
        SpawnCompetitor.SetActive(true);
    }
    public string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}
    void Cmdmixitems()
    { 
        indexitemblood = Random.Range(lengthitemsBegin, lengthitemsEnd);
        for (int i = lengthitemsBegin; i <lengthitemsEnd; i++)
        {
            indexitems[i]= i;
        }
        for (int i=lengthitemsBegin;i<lengthitemsEnd; i++)
        {
            int temp = indexitems[i];
            int index = Random.Range(i,lengthitemsEnd);
            indexitems[i] = indexitems[index];
            indexitems[index] = temp;
        }
    }
    void Cmdmixquests()
    {
        for (int i = lengthquestsBegin; i < lengthquestsEnd; i++)
        {
            indexquests[i]=i;
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



























