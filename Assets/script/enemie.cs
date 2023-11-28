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

    void Start()
    {
        xMin = zMin = -SquareOfMovement;
        xMax = zMax = SquareOfMovement;
        newLocation();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPostision, yPostision, zPostision)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        xPostision = Random.Range(xMin, xMax);
        yPostision = transform.position.y;
        zPostision = Random.Range(xMin, xMax);

        minion.SetDestination(new Vector3(xPostision, yPostision, zPostision));
    }

}
