using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;


public enum PlayerState
{
    walk,
    idle,
    attack,
    interact,
    stagger,
    gameover,
}
public class NewPlayerMovement : MonoBehaviour
{
    public GameObject RestartMenu;
    //public GameObject walksfx;

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Notification healthSignal;
    public VectorValue startingPoint;
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;
    public GameObject attacksfx;
    //public GameObject walksfx;
    //public GameObject playerhitsfx;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPoint.initialValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is in an interaction
        if(currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
        
        }
    private IEnumerator AttackCo()
    {
        attacksfx.SetActive(true);
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        attacksfx.SetActive(false);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }   
    }
    
    private IEnumerator GameOver()
    {
        RestartMenu.SetActive(true);
        currentState = PlayerState.gameover;
        yield return null;
        
    }
    
    public void RaiseItem()
    {
        if(playerInventory.currentItem != null) { 
        if(currentState != PlayerState.interact)
        {
            animator.SetBool("recieve", true);
            currentState = PlayerState.interact;
            receivedItem.sprite = playerInventory.currentItem.itemSprite;
        }
        else
        {
                animator.SetBool("recieve", false);
                currentState = PlayerState.idle;
                receivedItem.sprite = null;
                playerInventory.currentItem = null;
        }
         }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            currentState = PlayerState.walk;
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void FixedUpdate()
    {
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }
    }
        //Debug.Log(change);
    void MoveCharacter()
    {
        //walksfx.SetActive(true);
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
        //walksfx.SetActive(false);
    }

    public void Knock(float knockTime, float damage)
    {
       
        currentHealth.RuntimeValue -= damage;
        healthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            //playerhitsfx.SetActive(true);
            StartCoroutine(KnockCo(knockTime));
            //playerhitsfx.SetActive(false);
        }
        else
        {
            //playerhitsfx.SetActive(true);
            StartCoroutine(GameOver());
            currentHealth.RuntimeValue = currentHealth.initialValue;
            this.gameObject.SetActive(false);

        }
         
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

}
