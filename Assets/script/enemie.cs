using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemie : MonoBehaviour
{
    public NavMeshAgent minion;
    public float SquareOfMovement = 20f;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    private float xPostision;
    private float yPostision;
    private float zPostision;
    public float closeEnough = 3f;

    public int maxHealth = 3; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    private enemySpawner spawner;

    void Start()
    {
        xMin = zMin = -SquareOfMovement;
        xMax = zMax = SquareOfMovement;
        newLocation();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPostision, yPostision, zPostision)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void SetSpawner(enemySpawner newSpawner)
    {
        spawner = newSpawner;
    }

    public void newLocation()
    {
        xPostision = Random.Range(xMin, xMax);
        yPostision = transform.position.y;
        zPostision = Random.Range(zMin, zMax);

        minion.SetDestination(new Vector3(xPostision, yPostision, zPostision));
    }

    // Method to handle damage taken by the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // If health drops to or below 0, call the Die function
        }
    }

    void Die()
    {
        // Notify the spawner that an enemy was defeated
        spawner.EnemyDefeated();
        // The enemy gets destroyed
        Destroy(gameObject);
    }
}