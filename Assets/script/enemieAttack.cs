using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieAttack : MonoBehaviour
{

    private Transform player;
    public float attackRange = 10f;

    public Renderer ren;
    public Material defaultMaterial;
    public Material enemieAlert;

    private enemie enemieScript;
    private bool foundPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            ren.sharedMaterial = enemieAlert;
            enemieScript.minion.SetDestination(player.position);
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultMaterial;
            enemieScript.newLocation();
            foundPlayer = false;
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemieScript = GetComponent<enemie>();
        ren = GetComponent<Renderer>();
    }

}
