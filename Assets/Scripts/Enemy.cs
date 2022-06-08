using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    private Transform target;
    private int wavepointIndex;

    //other scipts
    Shop shop;


    private void Awake()
    {
        health = 2;
        speed = 5;
    }

    private void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Die function");
        if (gameObject.name == ("Boss1(Clone)"))
        {
            Debug.Log("turret available");
            //player gains turret
            shop.PurchaseStartingTurret();
        }

        Debug.Log("Die object");
        Destroy(gameObject);

    }


    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //when the distance between its position and the waypoint is .2 units or less it will call the new method
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= (Waypoints.points.Length - 1))
        {
            EndPath();
            return;
        }
        //increasing the wavepoint so that it gets the next wavepoint
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.Lives--;
    }

}
