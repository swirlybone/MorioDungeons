using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;


public enum EnemyState {idle, walk, attack, stagger, death}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpd;

    public void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D rigidbody2D, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(rigidbody2D, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D rigidbody2D, float knockTime)
    {
        if (rigidbody2D != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody2D.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    /*
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    */
}
