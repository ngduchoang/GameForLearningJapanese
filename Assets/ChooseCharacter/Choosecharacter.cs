using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choosecharacter : MonoBehaviour {

    [SerializeField]
    private int rows;
    [SerializeField]
    private int cols;
    [SerializeField]
    private Vector2 gridSize;
    [SerializeField]
    private Vector2 gridOffset;

    //about cells
    [SerializeField]
    //private Sprite cellSprite;
    private Vector2 cellSize;
    private Vector2 cellScale;
    public int dem = 0;
    public GameObject avartar;
    GameObject cO;
    string[] nameImageAvartar= {"player1", "player2", "player3", "player4",
        "player5","player6","player7"};
    void Start()
    {

        InitCharacters(); //Initialize all cells
    }
    private void Update()
    {
      //  Sprite p = Resources.Load<Sprite>(nameImageAvartar[dem]) as Sprite;
	if (dem == -1)
        {
            dem = nameImageAvartar.Length - 1;
        }
        else if (dem == 7)
        {
            dem = 0;
        }
        else
        {
            Sprite p = Resources.Load<Sprite>(nameImageAvartar[dem]) as Sprite;
            cO.GetComponent<SpriteRenderer>().sprite = p;
        }
      //  cO.GetComponent<SpriteRenderer>().sprite = p;
        
    }
    void InitCharacters()
    {
        cO = Instantiate(avartar,this.transform.position, Quaternion.identity) as GameObject;
        
    }
}
