using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalMoveObstacle : MonoBehaviour
{
    public int changePosition;
    public int speed;
    int direction = -1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.position.y < changePosition){
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if we're going down and we crossed the threshold, invert direction
        if(direction == -1 && transform.position.y < changePosition){
            direction = 1;
        }

        if(direction == 1 && transform.position.y > changePosition){
            direction = -1;
        }

        rb.AddForce(new Vector2(0, direction*speed));
    }
}
