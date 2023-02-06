using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject square;
    public GameObject goldenSquare;
    
    float counter = 0.0f;
    private GameObject GameManager;
    public float spawnDelayCoefficient = 1.0f;

    public int spawnerNumber;
    // Start is called before the first frame update
    void Start(){
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool spawnerIsEnabled = false;
        if(spawnerNumber == 1){
            spawnerIsEnabled = true;
        } else if(spawnerNumber == 2){
            if(GameManager.GetComponent<GameManager>().spawner2enabled == true){
                spawnerIsEnabled = true;
            }
        } else if(spawnerNumber == 3){
            if(GameManager.GetComponent<GameManager>().spawner3enabled == true){
                spawnerIsEnabled = true;
            }
        }
        if(spawnerIsEnabled){
            counter--;
            if (counter < 0) {
                if(Random.Range(0.0f, 100.0f) > 99.0f){
                    // rare golden box
                    Instantiate(goldenSquare, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
                } else {
                    Instantiate(square, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
                }
                
                counter = /*30*/GameManager.GetComponent<GameManager>().spawnDelay*spawnDelayCoefficient;
            }
        }
        
    }
}
