using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject fireprefab;
    public bool isCreated;
    public float currentHP;
    public float maxHP;
   public int point = 0;
    public string name;
    GameObject healthBarmini;

	GameObject gameOver;
    public void Throwing(GameObject txt)
    {
        if (!isCreated)
        {
            new WaitForSeconds(2.0f);

            string i = GetComponentInChildren<TextMesh>().text;
            GetComponent<Animator>().Play("Player"+i+ "Throwing");
            GameObject shoot = Instantiate(fireprefab, transform.position, Quaternion.identity) as GameObject;
            shoot.GetComponent<Fire>().Fireto(txt);
            txt.GetComponent<txt>().isfire = false;
            txt.GetComponent<txt>().playerfired = this.gameObject;
            isCreated = true;
        }
    }
	void Start()
    {
        healthBarmini = GameObject.FindGameObjectWithTag("Hearth");
    }
    private void Awake()
    {
        healthBarmini = GameObject.FindGameObjectWithTag("Hearth");
    }
     void Update()
    {

        healthBarmini = GameObject.FindGameObjectWithTag("Hearth");
        UpdateHearthBar();
    }
    void UpdateHearthBar()
    {
	  healthBarmini = GameObject.FindGameObjectWithTag("Hearth");
        if (currentHP > 0)
        {
            float x = currentHP / maxHP;
            if(x!=1)
                healthBarmini.transform.localScale = new Vector3(x * 0.045f, healthBarmini.transform.localScale.y, 1);
            else
                healthBarmini.transform.localScale = new Vector3(0.05f, healthBarmini.transform.localScale.y, 1);
        }
        else
        {
            healthBarmini.transform.localScale = new Vector3(0, 0.02f, 1);
	if(!gameOver)
	   gameOver = Instantiate(Resources.Load<GameObject>("GameOver")) as GameObject;
        }
    }
}


