using UnityEngine;
using UnityEngine.AI;

public class enemieAttack : MonoBehaviour
{
    public float attackRange = 3f;
    public float attackCooldown = 3f;
    public int damageAmount = 1;
    private float currentCooldown = 0f;
    public float detectRange = 15f;

    private Transform player;
    private enemie enemieScript;
    private bool foundPlayer;
    private Renderer rend;
    public Material enemy;
    public Material enemieAlert;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemieScript = GetComponent<enemie>();
    }

    void Update()
    {
        //if (Vector3.Distance(transform.position, player.position) <= detectRange)
        //{
        //    rend.sharedMaterial = enemieAlert;
        //    enemieScript.minion.SetDestination(player.position);
        //    foundPlayer = true;
        //}else{
        //    enemieScript.newLocation();
        //    foundPlayer = false; 
        //    rend.sharedMaterial = enemy;
        //}
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
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); // Pass the damage amount to TakeDamage()
        }
    }
}