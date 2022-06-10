using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject ImpactEffect;
    public float speed = 1f;
    public int damage = 1;

    public void Seek(Transform _target)
    {
        //can be used to pass values into the bullet, such as damage and speed
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //looking at target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude >= distanceThisFrame)
        {
            //hit something
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        //animation/particle
        //GameObject efffectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        //Destroy(efffectIns, 2f);
        Damage(target);
        
        ////destroying enemy
        //Destroy(target.gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

        PlayerStats.Money++;
    }
}
