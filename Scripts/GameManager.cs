using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is null!");
            }

            return _instance;
        }
    }

    public bool HasCard { get; set; }
    public bool isDead { get; set; }
    public PlayableDirector introCutscene;

    private void Awake()
    {
        _instance = this;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 61.0f;
            Debug.Log("GM okey 1");
            //AudioManager.Instance.PlayMusic();
            //Debug.Log("GM okey 2");
        }
    }

    public void GameOver()
    {
        if (!isDead)
        {
            isDead = true;
        }
    }
}
