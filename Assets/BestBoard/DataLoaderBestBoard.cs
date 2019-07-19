using UnityEngine;
using System.Collections;
using System;

public class DataLoaderBestBoard : MonoBehaviour {

    public string[] items;
    public GameObject srowView;
    public GameObject nameBestBoard;
    GameObject[] buttonLR;
    GameObject[] buttons;
    private void Start()
    {
        StartCoroutine(LoadData());
        srowView.GetComponent<DynamicButtonsBestBoard>().Init();
    }
    public IEnumerator LoadData()
    {
        
	var form = new WWWForm();
        Debug.Log(nameBestBoard.GetComponent<nameBestBoard>().dem);
        if (nameBestBoard.GetComponent<nameBestBoard>().dem ==0 )
             form.AddField("action", "show_highscore_read");
        if (nameBestBoard.GetComponent<nameBestBoard>().dem == 1)
             form.AddField("action","show_highscore_listen");
        if (nameBestBoard.GetComponent<nameBestBoard>().dem == 2)
             form.AddField("action", "show_highscore_speak");

        var url = "http://localhost:8080/Japanese/ItemsDataPoint.php";
        	var  itemsData =  new WWW (url,form);
        	yield return itemsData;

        string itemsDataString = itemsData.text;
        	items = itemsDataString.Split(';');
       
            Debug.Log("chieu dai la"+items.Length);
        setActive();
    }
    void setActive()
    {
        srowView.SetActive(true);
    }
    private void Update()
    {
        buttons = GameObject.FindGameObjectsWithTag("ButtonScrowview");
        buttonLR = GameObject.FindGameObjectsWithTag("ButtonLR");
        for(int i =0; i< buttonLR.Length;i++)
        if (buttonLR[i].GetComponent<ButtonLeftRight>().clicked == true)
        {
                //for (int j = 0; j < buttons.Length; j++)
                //    Destroy(buttons[j]);
                //Array.Clear(items, 0, items.Length);
                Debug.Log(nameBestBoard.GetComponent<nameBestBoard>().dem);
                StartCoroutine(LoadData());
                srowView.GetComponent<DynamicButtonsBestBoard>().Init();
                buttonLR[i].GetComponent<ButtonLeftRight>().clicked = false;
        }
       
    }
    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
