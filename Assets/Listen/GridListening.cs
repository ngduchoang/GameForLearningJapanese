using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridListening : MonoBehaviour {


    //grid specifics
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

    public GameObject text;
    DataLoaderListenning dataLoaderListenning;

    int dem;

    void Start()
    {
        dataLoaderListenning = Camera.main.GetComponent<DataLoaderListenning>();
        InitCells(); //Initialize all cells
        dem = 0;
    }
    private void Update()
    {
        if (dataLoaderListenning.isActiveGrid)
        {
            dem += dataLoaderListenning.numMock;
            InitCells();
        }
    }
    void InitCells()
    {
        // GameObject cellObject = new GameObject();

        //creates an empty object and adds a sprite renderer component -> set the sprite to cellSprite
        // cellObject.AddComponent<SpriteRenderer>().sprite = cellSprite;

        //catch the size of the sprite
        
        cellSize = text.GetComponent<MeshRenderer>().bounds.size;
        //get the new cell size -> adjust the size of the cells to fit the size of the grid
        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);
        cellSize = newCellSize; //the size will be replaced by the new computed size, we just used cellSize for computing the scale
        //fix the cells to the grid by getting the half of the grid and cells add and minus experiment
        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

        //fill the grid with cells by using Instantiate
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                dem++;
                //add the cell size so that no two cells will have the same x and y position
                Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x + transform.position.x, row * cellSize.y + gridOffset.y + transform.position.y);

                //instantiate the game object, at position pos, with rotation set to identity
                GameObject cO = Instantiate(text, pos, Quaternion.identity) as GameObject;


                cO.GetComponent<TextMesh>().text = dataLoaderListenning.GetDataValue(dataLoaderListenning.items[dataLoaderListenning.indexitems[dem]], "Kanji:");
                //set the parent of the cell to GRID so you can move the cells together with the grid;
                cO.transform.parent = transform;
            }
        }

        //destroy the object used to instantiate the cells
        //Destroy(text);
    }

    //so you can see the width and height of the grid on editor
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
