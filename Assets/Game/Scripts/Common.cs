using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    public static Common InstanceC;
    public bool soundPlaying;
    private void Awake()
    {
        if (!InstanceC)
        {
            InstanceC = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}