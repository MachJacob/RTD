using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Transform target;
    private MoveSprite agent;
    [SerializeField] private float maxHealth;
    private float health;
    private ParticleSystem part;

    void Start()
    {
        health = maxHealth;
        agent = GetComponent<MoveSprite>();
        part = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float _dam)
    {
        health -= _dam;
        part.Play();
    }

}
