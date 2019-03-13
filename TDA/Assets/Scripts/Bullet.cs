
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
       private Transform target;
    public GameObject impactEffect;
    public float explotionRadius = 0f;

    public float speed = 70f;

       public void seek(Transform _target) {
        target = _target; 

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);


    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        if (explotionRadius > 0) {
            Explode();
        }
        else{
            Damage(target);
        }
        
        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explotionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Destroy(enemy.gameObject);
        PlayerStats.Money += 10;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotionRadius);
    }
}
