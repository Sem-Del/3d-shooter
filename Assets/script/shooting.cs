using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera cam;
    public int damageAmount = 1; // Amount of damage player's shot inflicts

    private RaycastHit hit;
    private Ray ray;
    public int enemyKillCount;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("npc")) // Check the tag of the collider
                {
                    enemie enemyScript = hit.collider.GetComponent<enemie>();
                    if (enemyScript != null)
                    {
                        // Call TakeDamage method of the enemy script
                        enemyScript.TakeDamage(damageAmount);
                        enemyKillCount++;
                    }
                }
            }
        }
    }
}
