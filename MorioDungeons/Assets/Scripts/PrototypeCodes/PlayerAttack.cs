using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                Collider2D[] enemiesToDamage = Physics.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<><Enemy>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= timeBtwAttack.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
*/