using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D rigidbody2D;
    public Transform target;
    public float chaseRadius;
    public float atkRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //holds the location information
        target = GameObject.FindWithTag("Player").transform;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > atkRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpd * Time.deltaTime);
                AnimChange(temp - transform.position);
                rigidbody2D.MovePosition(temp);
                StateChange(EnemyState.walk);
                anim.SetBool("wakeup", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeup", false);
        }
    }

    private void SetAnimFloat(Vector2 vet)
    {
        anim.SetFloat("moveX", vet.x);
        anim.SetFloat("moveY", vet.y);
    }

    private void AnimChange(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    
    private void StateChange(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

}
