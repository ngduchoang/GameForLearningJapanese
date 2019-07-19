using UnityEngine;
using System.Collections;

public class nameBestBoard : MonoBehaviour {

    public string[] nameBoard = { "Read", "Listen", "Speak" };
    public int dem;
    
    // Update is called once per frame
    void Update () {

        if (dem == -1)
        {
            dem = nameBoard.Length - 1;
        }
        else if (dem == 3)
        {
            dem = 0;
        }
        else
        {
            gameObject.GetComponent<TextMesh>().text = nameBoard[dem];
        }
    }
}
