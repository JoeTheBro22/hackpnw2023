using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneygain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {}

      void OnCollisionEnter2D(Collision2D myCol){

                 Destroy(myCol.gameObject);
                 Debug.Log("money +1");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
