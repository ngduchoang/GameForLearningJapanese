using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Collections;

public class DynamicButtonsBestBoard : MonoBehaviour
{
    // Prefab
    public GameObject buttonPrefab;
    DataLoaderBestBoard dataLoaderBestBoard;
    // List of button names
    List<string> buttonNames = new List<string>();
    // Start
    public void Init()
    {
        dataLoaderBestBoard = Camera.main.GetComponent<DataLoaderBestBoard>();
        buttonNames.Clear();
        for (int row = 0; row < dataLoaderBestBoard.items.Length - 1; row++)
        {
            buttonNames.Add(dataLoaderBestBoard.GetDataValue(dataLoaderBestBoard.items[row], "name:") + ":" + dataLoaderBestBoard.GetDataValue(dataLoaderBestBoard.items[row], "point:"));

        }
        foreach (string str in buttonNames)
        {
            GameObject item = Instantiate(buttonPrefab) as GameObject;
            item.transform.SetParent(GameObject.Find("ScrollContent").transform);
            item.AddComponent<ButtonController>();

            Button itemBt = item.GetComponent<Button>();
            ButtonController buttonController = item.GetComponent<ButtonController>();
            item.GetComponentInChildren<Text>().text = str;
            buttonController.BtName = str;
            itemBt.onClick.AddListener(buttonController.ClickMe);
        }
    }
     void Start()
    {
        Init();
    }
    private void Update()
    {
        
    }
}
