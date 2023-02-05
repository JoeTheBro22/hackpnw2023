using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject square;
    
    float counter = 0.0f;
    private GameObject GameManager;
    public float spawnDelayCoefficient = 1.0f;
    // Start is called before the first frame update
    void Start(){
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    { counter--;
    
    if (counter < 0) {
        Instantiate(square, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
        counter = /*30*/GameManager.GetComponent<GameManager>().spawnDelay*spawnDelayCoefficient;
    }}
}
