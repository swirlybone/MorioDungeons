using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerMem;
    public GameObject FadePanel;
    public GameObject FadeOutPanel;
    public float fadeWait;

    public void Awake()
    {
        {
            if(FadePanel != null)
            {
                GameObject panel = Instantiate(FadePanel, Vector3.zero, Quaternion.identity);
                Destroy(panel, 1);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerMem.initialValue = playerPosition;
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo()
    {
        if(FadePanel != null)
        {
            Instantiate(FadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
