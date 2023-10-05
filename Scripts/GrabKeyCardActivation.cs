using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    public GameObject sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sleepingGuardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
            
        }
    }
}
