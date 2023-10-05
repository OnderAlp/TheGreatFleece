using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventDestroying : MonoBehaviour
{
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
}
