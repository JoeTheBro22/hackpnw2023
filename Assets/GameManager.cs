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

    public float pipeUpgradeCost = 10f;
    public float pipeUpgradeCostMultiplier = 2;
    public int pipeUpgradeLevel = 0;
    public bool spawner2enabled = false;
    public bool spawner3enabled = false;

    public bool moneysEnabled = false;

    public float shrinkUpgradeCost = 10f;
    public float shrinkUpgradeCostMultiplier = 1.4f;
    public int shrinkUpgradeLevel = 0;
    public float shrinkAmount = 1.0f;
    
    private GameObject spawnRateText;
    private GameObject pipeText;
    private GameObject shrinkText;

    private GameObject scoreText;

    private GameObject pipeUpgradeButton;

    // Start is called before the first frame update
    void Start()
    {
        spawnRateText = GameObject.Find("spawnRateText");
        pipeText = GameObject.Find("pipeText");
        shrinkText = GameObject.Find("shrinkText");
        scoreText = GameObject.Find("scoreText");
        pipeUpgradeButton = GameObject.Find("unlockPipes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeSpawnRate(){
        if(score >= spawnDelayCost){
            score -= Mathf.RoundToInt(spawnDelayCost);
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();

            spawnDelayCost *= spawnDelayCostMultiplier;
            spawnDelay *= spawnDelayIncrement;
            spawnDelayCost = Mathf.Floor(spawnDelayCost);

            // increment the level text
            spawnDelayLevel++;
            spawnRateText.GetComponent<UnityEngine.UI.Text>().text = "Spawn Rate Level " + spawnDelayLevel.ToString() + "\n Cost: " + spawnDelayCost;
        }
    }

    public void upgradePipes(){
        // this upgrade functions functions two ways: first it allows the money sprites to actually recieve money and then second it unlocks the 2nd and 3rd pipes
        if(score >= pipeUpgradeCost){
            // update score
            score -= Mathf.RoundToInt(pipeUpgradeCost);
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();

            // increment
            pipeUpgradeCost *= pipeUpgradeCostMultiplier;

            pipeUpgradeLevel++;

            // if its level 1, then enable the moneys. If its >0, then unlock pipes
            if(pipeUpgradeLevel == 1){
                // enable moneys
                moneysEnabled = true;
                // make their color green
                GameObject[] moneys  = GameObject.FindGameObjectsWithTag("moneyCollector");
                foreach (GameObject money in moneys){
                    // money.transform.position = new Vector3(0,0,0);
                    money.GetComponent<SpriteRenderer>().color = Color.white;
                    money.GetComponent<BoxCollider2D>().enabled = true;
                    // Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
                }

                pipeText.GetComponent<UnityEngine.UI.Text>().text = "Unlock Spawner 2 \n Cost: " + pipeUpgradeCost;
            } else if(pipeUpgradeLevel == 2) {
                // unlock 2nd pipe
                spawner2enabled = true;

                pipeText.GetComponent<UnityEngine.UI.Text>().text = "Unlock Spawner 3 \n Cost: " + pipeUpgradeCost;
            } else if(pipeUpgradeLevel == 3) {
                // unlock 3rd pipe and delete the button
                spawner3enabled = true;

                Destroy(pipeUpgradeButton);
            }
        }
    }

    public void shrinkObstacles() {
        if(score >= shrinkUpgradeCost){
            // update score
            score -= Mathf.RoundToInt(shrinkUpgradeCost);
            shrinkUpgradeCost *= shrinkUpgradeCostMultiplier;
            shrinkUpgradeCost = Mathf.RoundToInt(shrinkUpgradeCost);
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();
            shrinkUpgradeLevel++;

            shrinkText.GetComponent<UnityEngine.UI.Text>().text = "Shrink Obstacles \nLevel " + shrinkUpgradeLevel.ToString() + "\nCost: " + shrinkUpgradeCost.ToString();

            shrinkAmount *= 0.97f;
        }
    }
}
