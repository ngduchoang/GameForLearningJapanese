using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ButtonLeftRight : MonoBehaviour {
 string getscoreCode="http://localhost:8080/Japanese/ItemsDataPoint.php";    
public typeBotton type;
    GameObject avartar;
	GameObject player;
    GameObject gameOver;
    GameObject nameBestBoard;
    public static string result="";
    
    public bool clicked = false;
    // Use this for initialization
    void Start () {
        avartar = GameObject.FindGameObjectWithTag("AvartarCharacter");
		player = GameObject.FindGameObjectWithTag("Player");
        nameBestBoard = GameObject.FindGameObjectWithTag("NameBestBoard");

    }
	// Update is called once per frame
	void Update () {
       
    }
    private void OnMouseDown()
    {
        if (type == typeBotton.left && Application.loadedLevelName == "Choosecharacter")
        {
            avartar.GetComponent<Choosecharacter>().dem--;
        }
        if (type == typeBotton.right && Application.loadedLevelName == "Choosecharacter")
        {
            avartar.GetComponent<Choosecharacter>().dem++;
        }
        if (type == typeBotton.left && Application.loadedLevelName == "Bestboard")
        {
            
            nameBestBoard.GetComponent<nameBestBoard>().dem--;
            
            clicked = true;
        }
        if (type == typeBotton.right && Application.loadedLevelName == "Bestboard")
        {

            nameBestBoard.GetComponent<nameBestBoard>().dem++;
            Debug.Log(nameBestBoard.GetComponent<nameBestBoard>().dem);
            clicked = true;
        }
        if (type == typeBotton.chooseCharacter)
        {
            PlayerPrefs.SetInt("dem", avartar.GetComponent<Choosecharacter>().dem);
            Application.LoadLevel("Menu");
            
        }
		if (type == typeBotton.savePoint)
        {
             StartCoroutine(handleEnterScore("thao",10));
             Application.LoadLevel("Menu");

        }
    }
    public enum typeBotton
    {
        left,
        right,
        chooseCharacter,
       savePoint,
    }
     IEnumerator  handleEnterScore(string name,int point)
     {
		 var form = new WWWForm();
		 form.AddField("action","submit_highscore");
		//var n = name.GetComponent<TextMesh>().;
		 form.AddField("name", player.GetComponent<PlayerControl>().name);
		 form.AddField("point",player.GetComponent<PlayerControl>().point);
		 var url = "http://localhost:8080/Japanese/ItemsDataPoint.php";
         var entereddata = new WWW (url,form);
         yield return entereddata;
     }
}
