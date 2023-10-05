using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;
    public Animator anim;
    private MeshRenderer meshRenderer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            meshRenderer = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.03f);
            meshRenderer.material.SetColor("_TintColor", color);
            anim.enabled = false;
            StartCoroutine(AlertRoutine());
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.GameOver();
        gameOverCutscene.SetActive(true);
    }
}
