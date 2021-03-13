using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject Clue;
    public bool contextActive = false;

    public void ContextChange()
    {
        contextActive = !contextActive;
        if (contextActive)
        {
            Clue.SetActive(true);
        }
        else
        {
            Clue.SetActive(false);
        }
    }
}
