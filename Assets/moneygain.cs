using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneygain : MonoBehaviour
{
    public GameObject scoreText;
    private int score;
    // Start is called before the first frame update
    void Start(){}

    void OnCollisionEnter2D(Collision2D myCol){
      if(myCol.gameObject.tag == "money"){
        Destroy(myCol.gameObject);
        score++;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "score: " + score.ToString();
      }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
