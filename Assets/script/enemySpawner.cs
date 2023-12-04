using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public shooting shootingScript;
    public int round1 = 3; // Number of enemies for round 1
    public int round2 = 6; // Number of enemies for round 2
    public int round3 = 4; // Number of enemies for round 3
    public int round4 = 10; // Number of enemies for round 4
    public int round5 = 3; // Number of enemies for round 5
    public int round6 = 22; // Number of enemies for round 6
    public int round7 = 15; // Number of enemies for round 7

    private int currentRound = 1;
    private int totalEnemies;
    private int enemiesRemaining;

    void Start()
    {
        StartRound();
    }

    void StartRound()
    {
        switch (currentRound)
        {
            case 1:
                totalEnemies = round1;
                break;
            case 2:
                totalEnemies = round2;
                break;
            case 3:
                totalEnemies = round3;
                break;
            case 4:
                totalEnemies = round4;
                break;
            case 5:
                totalEnemies = round4;
                break;
            case 6:
                totalEnemies = round4;
                break;
            case 7:
                totalEnemies = round4;
                break;
            case 8:
                totalEnemies = round4;
                break;
            default:
                Debug.Log("You have defeated every round!");
                return;
        }

        enemiesRemaining = totalEnemies;

        for (int i = 0; i < totalEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            enemy.GetComponent<enemie>().SetSpawner(this);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Return random spawn position within the spawner's area
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        return randomPosition;
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            currentRound++;
            StartRound();
        }
    }
}
