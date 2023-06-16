using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sce3 : MonoBehaviour
{
    [SerializeField]
    GameObject scen3;
    private string inputt;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (inputt == "123ASDq")
        {
            scen3.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void EndValue(string s)
    {
        inputt = s;
    }
}
