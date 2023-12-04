
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Image[] hearths;
    public Sprite full_hearth;
    public Sprite deadth_hearth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < hearths.Length; i++)
        {

            if(i < currentHealth)
            {
                hearths[i].sprite = full_hearth;
            }else
            {
                hearths[i].sprite = deadth_hearth;
            }

            if (i < maxHealth)
            {
                hearths[i].enabled = true;
            }else
            {
                hearths[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        currentHealth = maxHealth; // Reset player health
        transform.position = new Vector3(38.05f, 4.51f, 40.5f); // Teleport player to respawn position
    }


}
