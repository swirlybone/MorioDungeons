using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string worldName;
    public GameObject text;
    public Text worldText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            CameraMovement cam = Camera.main.GetComponent<CameraMovement>();
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange;
            player.transform.position += new Vector3(playerChange.x,
                                                     playerChange.y,
                                                    0);
            StartCoroutine(worldNameCo());
        }
    }
    */

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) 
        {
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(worldNameCo());
            }
        }
    }
    

    private IEnumerator worldNameCo()
    {
        text.SetActive(true);
        worldText.text = worldName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
