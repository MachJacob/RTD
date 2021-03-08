using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float engageCap;
    [SerializeField] private Transform target;
    [SerializeField] private Entity targetEnemy;
    [SerializeField] private float attackCool;
    private Vector3 leashPos;

    public string enemyTag = "Enemy";
    public GameObject proj;

    private MoveSprite agent;

    void Awake()
    {
        agent = GetComponent<MoveSprite>();
        InvokeRepeating("UpdateTarget", 0.0f, 0.1f);
        attackCool = 0;
        leashPos = transform.position;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortest_distance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance_to_enemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance_to_enemy < shortest_distance)
            {
                shortest_distance = distance_to_enemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortest_distance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Entity>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        attackCool -= Time.deltaTime;
        if (target != null && attackCool < 0)
        {
            if (Vector3.Distance(transform.position, target.position) > 1)  //outside of melee range
            {
                Shoot();
            }
            else
            {
                Attack();
            }
            attackCool = 10 / attackSpeed;
        }
    }

    void Attack()
    {

    }

    void Shoot()
    {
        GameObject _proj = Instantiate(proj, transform.position, Quaternion.identity);
        _proj.GetComponent<Projectile>().Spawn(target, damage, 0.1f);
    }
}
