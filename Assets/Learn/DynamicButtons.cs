using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DynamicButtons : MonoBehaviour
{
    // Prefab
    public GameObject buttonPrefab;
    DataLoaderLearn dataLoaderLearn;
    // List of button names
    List<string> buttonNames = new List<string>();
    // Start
    void Start()
    {
        dataLoaderLearn = Camera.main.GetComponent<DataLoaderLearn>();
        for (int row = 0; row < 10; row++)
        {
        buttonNames.Add(dataLoaderLearn.GetDataValue(dataLoaderLearn.items[row], "Kanji:")+":"+ dataLoaderLearn.GetDataValue(dataLoaderLearn.items[row], "amHan:"));
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
}
