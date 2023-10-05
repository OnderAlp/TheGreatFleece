using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get 
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is null !");
            }  

            return _instance; 
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public GameObject gameOverCutscene;

    public void Restart()
    {
        //GameObject[] virtualCams = GameObject.FindGameObjectsWithTag("vCam");

        //foreach (var cam in virtualCams)
        //{
            //CinemachineVirtualCamera comp = cam.GetComponent<CinemachineVirtualCamera>();
            //comp.gameObject.SetActive(false);
        //}
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
