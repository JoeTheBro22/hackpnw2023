using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // basically what this script does is it recieves the game's upgrade state and then dec obstacle radius/ spawns more stuff/ etc
    public int score = 0;
    public float spawnDelay;
    public float spawnDelayCost = 10f;
    public float spawnDelayCostMultiplier = 1.2f;
    public float spawnDelayIncrement = 0.9f;
    public int spawnDelayLevel = 0;
    
    private GameObject spawnRateText;

    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        spawnRateText = GameObject.Find("spawnRateText");
        scoreText = GameObject.Find("scoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void upgradeSpawnRate(){
        if(score >= spawnDelayCost){
            score -= Mathf.RoundToInt(spawnDelayCost);
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "score: " + score.ToString();

            spawnDelayCost *= spawnDelayCostMultiplier;
            spawnDelay *= spawnDelayIncrement;
            spawnDelayCost = Mathf.Floor(spawnDelayCost);

            // increment the level text
            spawnDelayLevel++;
            spawnRateText.GetComponent<UnityEngine.UI.Text>().text = "Spawn Rate Level " + spawnDelayLevel.ToString() + "\n Cost: " + spawnDelayCost;
        }
    }
}
