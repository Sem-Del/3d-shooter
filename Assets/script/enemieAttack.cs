using UnityEngine;

public class enemieAttack : MonoBehaviour
{
    public float attackRange = 10f; // Range within which the enemy can attack
    public float attackCooldown = 3f; // Cooldown period between attacks
    public int damageAmount = 1; // Amount of damage the enemy inflicts
    private float currentCooldown = 0f; // Current cooldown time
    private Transform player;
    private enemie enemieScript;
    private bool foundPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemieScript = GetComponent<enemie>();
    }

    void Update()
    {
        if (currentCooldown <= 0f)
        {
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
                currentCooldown = attackCooldown; // Reset cooldown
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime; // Reduce cooldown time
        }
    }

    void AttackPlayer()
    {
        // Check if the player has a PlayerHealth script attached
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); // Pass the damage amount to TakeDamage()
        }
    }
}
