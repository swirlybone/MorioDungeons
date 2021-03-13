using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class SwirlyController : MonoBehaviour
{
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        //Speed controls, makes it so the character moves the same on any machine
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //Debug.Log(horizontal);
        //Debug.Log(vertical);
        //Vector2 position = transform.position;
        //position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        //position.y = position.y + 3.0f * vertical * Time.deltaTime;
        //transform.position = position;
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    
}


