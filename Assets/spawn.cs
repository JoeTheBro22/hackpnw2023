using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
public GameObject square;
int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { counter--;
    
    if (counter < 0) {
        Instantiate(square, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
        counter = 60;
    }}
}
