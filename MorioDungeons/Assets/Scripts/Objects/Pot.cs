using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public GameObject hitsfx;
    private Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Smash()
    {
        anim.SetBool("smash", true);
        //sfx.SetActive(true);
        StartCoroutine(breakCo());
        
    }

    IEnumerator breakCo()
    {
        hitsfx.SetActive(true);
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        hitsfx.SetActive(false);
    }
}
