using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorObstacle : MonoBehaviour
{
    public float xForce;
    public float yForce;

    void OnTriggerStay2D(Collider2D myCol)
    {
        if(myCol.gameObject.tag == "money"){
            myCol.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
