using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Networking;

public class DataLoaderSpeak : MonoBehaviour {

    public string[] items;
    public int[] indexitems;
    public int lengthitems;

    public int[] indexquests;
    public int lengthquests;

    //public GameObject GridListening;
   // public GameObject questSpeak;
    public GameObject go;
    // Use this for initialization
    IEnumerator Start()
    {
        indexitems = new int[1000];
        indexquests = new int[1000];
        WWW itemsData = new WWW("https://japanese-190203.appspot.com/");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        items = itemsDataString.Split(';');
        
        Debug.Log(itemsDataString);
        //active
        setActive();
        //mix
        lengthitems = items.Length - 1;
        lengthquests = items.Length - 1;
        mixquests();
        mixitems();
    }
    void setActive()
    {
        // GridListening.SetActive(true);
        go.SetActive(true);
       // questSpeak.SetActive(true);
    }
    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    void mixitems()
    {
        for (int i = 0; i < lengthitems; i++)
        {
            indexitems[i] = i;
        }
        for (int i = 0; i < lengthitems; i++)
        {
            int temp = indexitems[i];
            int index = Random.Range(i, lengthitems);
            indexitems[i] = indexitems[index];
            indexitems[index] = temp;

        }
        for (int i = 0; i < lengthitems; i++)
        {
            Debug.Log(GetDataValue(items[indexitems[i]], "Kanji:"));
        }
    }
    void mixquests()
    {
        for (int i = 0; i < lengthquests; i++)
        {
            indexquests[i] = i;
        }
        for (int i = 0; i < lengthquests; i++)
        {
            int temp = indexquests[i];
            int index = Random.Range(i, lengthquests);
            indexquests[i] = indexquests[index];
            indexquests[index] = temp;
        }
    }
}
