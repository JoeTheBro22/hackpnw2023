using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorObstacle : MonoBehaviour
{
    public float xForce;
    public float yForce;
    private GameObject GameManager;
        

    void OnTriggerStay2D(Collider2D myCol)
    {
        float shrinkAmount = GameManager.GetComponent<GameManager>().shrinkAmount;
        if(myCol.gameObject.tag == "money"){
            myCol.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce*shrinkAmount, yForce*shrinkAmount));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
