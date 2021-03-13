using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    public int health { get { return currentHealth; } }
    int currentHealth;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

        anim.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            anim.SetFloat("X", input_x);
            anim.SetFloat("Y", input_y);

            transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * 5f;
        }

    }
    public void ChangeHealth(int amount)
    {

    }
    /*
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    */

    }
