using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance.HasCard == true)
            {
                GameManager.Instance.GameOver();
                winCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You need the Key Card !");
            }
            
        }
    }
}
