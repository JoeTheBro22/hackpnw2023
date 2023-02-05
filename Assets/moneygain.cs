using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneygain : MonoBehaviour
{
    public GameObject scoreText;
    private int score;
    private GameObject GameManager;
    private GameObject Canvas;

    public GameObject popUpTextPrefab;
    // Start is called before the first frame update
    void Start(){
      GameManager = GameObject.Find("GameManager");
      Canvas = GameObject.Find("Canvas");
      // a
    }

    void OnCollisionEnter2D(Collision2D myCol){
      if(myCol.gameObject.tag == "money" && GameManager.GetComponent<GameManager>().moneysEnabled == true){
        // getting half the width and height of canvas
        float halfHeight = Canvas.GetComponent<RectTransform>().rect.height/2;
        float halfWidth = Canvas.GetComponent<RectTransform>().rect.width/2;
        //new Vector3(transform.position.x*halfWidth*2.0f, transform.position.y*halfHeight*2.0f, 0)
        
        Instantiate(popUpTextPrefab, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, Canvas.transform);

        Destroy(myCol.gameObject);
        score = GameManager.GetComponent<GameManager>().score+=2;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();
      }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
