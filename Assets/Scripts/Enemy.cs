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

    private void Start()
    {
        target = Waypoints.points[0];
        shop = Shop.instance;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        //Debug.Log("The enemies health is now: " + health);
        if (health <= 0)
        {
            Die();
            //Debug.Log("The enemy has died");
        }
        return;
    }
    void Die()
    {
        if (gameObject.name == ("Boss1(Clone)"))
        {
            //increase amount for turret1
            shop.secondTurret.amount++;

            //player gains turret
            shop.PurchaseStartingTurret();
        }

        if (gameObject.name == ("Boss2(Clone)"))
        {
            //increase amount for turret1
            shop.thirdTurret.amount++;

            //player gains turret
            shop.PurchaseBoss2Turret();
        }

        if (gameObject.name == ("Boss3(Clone)"))
        {
            //increase amount for turret1
            shop.fourthTurret.amount++;

            //player gains turret
            shop.PurchaseBoss3Turret();
        }

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
