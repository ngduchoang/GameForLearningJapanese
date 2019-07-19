using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonmenu : MonoBehaviour {

    public Sprite choose;
    Sprite normal;
    public typeBotton type;
    void Start () {
        normal = GetComponent<SpriteRenderer>().sprite;
        if (type == typeBotton.learnN4)
        {
            if (PlayerPrefs.GetInt("Scene2") != 1)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
        }
        if (type == typeBotton.learnN3)
        {
            if (PlayerPrefs.GetInt("Scene3") != 1)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
        }
        if (type == typeBotton.learnN2)
        {
            if (PlayerPrefs.GetInt("Scene3") != 1)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
        }
        if (type == typeBotton.learnN1)
        {
            if (PlayerPrefs.GetInt("Scene3") != 1)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = choose;
        //Camera.main.GetComponent<Controller>().ads.Play();
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normal;
    }
    private void OnMouseUp()
    {

        GetComponent<SpriteRenderer>().sprite = normal;
        if (type == typeBotton.map)
        {
            if (!GameObject.Find("Map(Clone)"))
                Instantiate(Resources.Load("level"));
           // if (GameObject.Find("level(Clone)").transform.Find("loadbarbg").gameObject.active)
             //   GameObject.Find("level(Clone)").transform.Find("loadbarbg").gameObject.SetActive(false);
            GameObject[] mang = GameObject.FindGameObjectsWithTag("ButtonMenu");
            for (int i = 0; i < mang.Length; i++)
            {
                mang[i].GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
        if (type == typeBotton.learn)
        {
            if (!GameObject.Find("MapLearn(Clone)"))
                Instantiate(Resources.Load("Map/MapLearn"));
         //   if (GameObject.Find("MapLearn(Clone)").transform.Find("loadbarbg").gameObject.active)
           //     GameObject.Find("MapLearn(Clone)").transform.Find("loadbarbg").gameObject.SetActive(false);
            GameObject[] mang = GameObject.FindGameObjectsWithTag("Learn");
            for (int i = 0; i < mang.Length; i++)
            {
                mang[i].GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
        if (type == typeBotton.map1)
        {
            Application.LoadLevel("ChooseTypePlay");
        }
        if (type == typeBotton.map2)
        {
            Application.LoadLevel("ChooseTypePlay");
        }
        if (type == typeBotton.map3)
        {
            Application.LoadLevel("S3");
        }
        //button learn
        if (type == typeBotton.learnN5)
        {
            Application.LoadLevel("MenuTypePlay");
        }
        if (type == typeBotton.learnN4)
        {
            Application.LoadLevel("MenuTypePlay");
        }
        if (type == typeBotton.learnN3)
        {
            Application.LoadLevel("MenuTypePlay");
        }
        if (type == typeBotton.learnN2)
        {
            Application.LoadLevel("MenuTypePlay");
        }
        if (type == typeBotton.learnN1)
        {
            Application.LoadLevel("LearMenuTypePlaynN1");
        }
        //button lobby
        if (type == typeBotton.lobbyN5)
        {
            Application.LoadLevel("LobbyN5");
        }
        if (type == typeBotton.lobbyN4)
        {
            Application.LoadLevel("LobbyN4");
        }
        if (type == typeBotton.lobbyN3)
        {
            Application.LoadLevel("LobbyN3");
        }
        if (type == typeBotton.lobbyN2)
        {
            Application.LoadLevel("LobbyN2");
        }
        if (type == typeBotton.lobbyN1)
        {
            Application.LoadLevel("LobbyN1");
        }

        if (type == typeBotton.exit)
        {
            Destroy(transform.parent.gameObject);
        }
        if (type == typeBotton.arena)
        {
            Application.LoadLevel("Arena");
        }
        if (type == typeBotton.menu)
        {
            //  if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name !="Menu")
            Application.LoadLevel("Menu");
            //Time.timeScale = 1;
        }
        if (type == typeBotton.online1)
        {
            Application.LoadLevel("LobbyScene2D");
        }
        if (type == typeBotton.library)
        {
            Application.LoadLevel("Learn");
		}
        if (type == typeBotton.listeningbtn)
        {
            Application.LoadLevel("playlistenning");
        }
        if (type == typeBotton.readingbtn)
        {
            Application.LoadLevel("play");
        }
        if (type == typeBotton.buttontyperead)
        {
            Application.LoadLevel("Read");
        }
        if (type == typeBotton.buttontypelisten)
        {
            Application.LoadLevel("Listen");
        }
        if (type == typeBotton.buttontypespeak)
        {
            Application.LoadLevel("Speak");
        }
        if (type == typeBotton.buttonbestboard)
        {
            Application.LoadLevel("Bestboard");
        }
        if (type == typeBotton.buttonbackmenu)
        {
            Application.LoadLevel("Menu");
        }
        if (type == typeBotton.buttonbackchoosecharacter)
        {
            Application.LoadLevel("Choosecharacter");
        }
    }
    public enum typeBotton
    {
        
        map,
        shop,
        map1,
        map2,
        exit,
        arena,
        menu,
        map3,
        learn,
        learnN5,
        learnN4,
        learnN3,
        learnN2,
        learnN1,
        lobbyN5,
        lobbyN4,
        lobbyN3,
        lobbyN2,
        lobbyN1,
        library,
        listeningbtn,
        speakingbtn,
        readingbtn,
        online1,
        buttontyperead,
        buttontypelisten,
        buttontypespeak,
        buttonbestboard,
        buttonbackmenu,
        buttonbackchoosecharacter,

    }

}
