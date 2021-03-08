using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private float damage;
    private float speed;

    public void Spawn(Transform _target, float _dam, float _speed)
    {
        target = _target;
        damage = _dam;
        speed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * speed, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.1f)
        {
            target.GetComponent<Entity>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
