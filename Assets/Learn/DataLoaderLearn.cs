using UnityEngine;
using System.Collections;

public class DataLoaderLearn : MonoBehaviour {

    public string[] items;
    public GameObject srowView;

    IEnumerator Start()
    {
        WWW itemsData = new WWW("https://japaneseread.appspot.com/");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        items = itemsDataString.Split(';');
        setActive();
    }
    void setActive()
    {
        srowView.SetActive(true);
    }
    private void Update()
    {
    }
    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
