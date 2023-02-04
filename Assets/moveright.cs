using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveright : MonoBehaviour
{   Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(25,0));
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(1,0));
    }
}
