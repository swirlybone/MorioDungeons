using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public float amountToHeal;
    public FloatValue heartContainers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& !collision.isTrigger)
        {
            playerHealth.RuntimeValue += amountToHeal;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 2f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            }
            powerUpNotif.Raise();
            Destroy(this.gameObject);
        }
    }
}
