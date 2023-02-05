using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneygain : MonoBehaviour
{
    public GameObject scoreText;
    private int score;
    private GameObject GameManager;
    // Start is called before the first frame update
    void Start(){
      GameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter2D(Collision2D myCol){
      if(myCol.gameObject.tag == "money" && GameManager.GetComponent<GameManager>().moneysEnabled == true){
        Destroy(myCol.gameObject);
        score = GameManager.GetComponent<GameManager>().score+=2;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "score: " + score.ToString();
      }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
