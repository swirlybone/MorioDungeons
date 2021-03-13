using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}
public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoor;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;



    private void Update()
    {
        {
            if (playerInventory.numberOfKeys == 1)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (inRange && thisDoor == DoorType.key)
                    {
                        //checks if player has key
                        if (playerInventory.numberOfKeys > 0)
                        {
                            //removes a player key
                            playerInventory.numberOfKeys--;
                        }
                        //if player does, call open
                        Open();
                    }
                }
            }
        }
    }

    public void Open()
    {
        //turn the door's sprite renderer off
        doorSprite.enabled = false;
        //set open to true
        open = true;
        //turns off door box collider
        physicsCollider.enabled = false;
    }

    public void Close()
    {

    }
}
