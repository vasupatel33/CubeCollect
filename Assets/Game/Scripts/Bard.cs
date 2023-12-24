using UnityEngine;

public class Bard : MonoBehaviour
{
    static int staticId = 0;
  
    [HideInInspector] public int CubeID;

    public static Bard instance;
    private void Awake()
    {
        CubeID = staticId++;
        //Debug.Log("ID is = "+CubeID);
    }
    void Start()
    {
        instance = this;
    }
}