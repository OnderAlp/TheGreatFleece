using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip AudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !GameManager.Instance.isDead)
        {
            AudioManager.Instance.PlayVoiceOver(AudioClip);
            Destroy(this);
        }
    }
}
