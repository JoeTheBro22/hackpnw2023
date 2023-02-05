using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveright : MonoBehaviour
{   Rigidbody2D rb;
    private float scale;

    private GameObject scoreText;
    private GameObject GameManager;

    public GameObject popUpTextPrefab;
    private GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");

        GameManager = GameObject.Find("GameManager");
        scoreText = GameObject.Find("scoreText");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(25,0));

        // updating scale
        float shrinkAmount = GameManager.GetComponent<GameManager>().shrinkAmount;
        transform.localScale = new Vector3(transform.localScale.x*shrinkAmount,transform.localScale.y*shrinkAmount,1);

        scale = transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(1,0));

        // also dying if we hit close to the mouse position
        if (Input.GetMouseButtonDown(0)){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            float differenceX = transform.position.x-mousePosition.x;
            float differenceY = transform.position.y - mousePosition.y;
            if(differenceX*differenceX + differenceY * differenceY < scale*scale){
                // add the +1 text
                Instantiate(popUpTextPrefab, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, Canvas.transform);

                // update the text
                int score = GameManager.GetComponent<GameManager>().score++;
                scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + (score+1).ToString();

                //destroy ourselves - goodbye world :(
                Destroy(gameObject);
            }
        }
    }
}
