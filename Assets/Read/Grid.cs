using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int rows;
    public int cols;
    public Vector2 gridSize;
    public Vector2 gridOffset;
    public Vector2 cellSize;
    public Vector2 cellScale;

    public GameObject text;
    DataLoader dataLoader;
    int dem;
    void Start()
    {
        dataLoader = Camera.main.GetComponent<DataLoader>();
        InitCells(); 
        dem = 0;
    }
    private void Update()
    {
        if (dataLoader.isActiveGrid)
        {
            dem += dataLoader.numMock;
            InitCells();
        }
    }
    void InitCells()
    {
        
        cellSize = text.GetComponent<MeshRenderer>().bounds.size;
        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);
        cellSize = newCellSize;
        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                dem++;
                Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x + transform.position.x, row * cellSize.y + gridOffset.y + transform.position.y);
                GameObject cO = Instantiate(text, pos, Quaternion.identity) as GameObject;
                if(dataLoader.indexitems[dem]== dataLoader.indexitemblood)
                {
                    cO.GetComponent<TextMesh>().text = dataLoader.GetDataValue(dataLoader.items[dataLoader.indexitems[dem]], "Kanji:");
                    cO.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                cO.GetComponent<TextMesh>().text = dataLoader.GetDataValue(dataLoader.items[dataLoader.indexitems[dem]], "Kanji:");
                cO.transform.parent = transform;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
