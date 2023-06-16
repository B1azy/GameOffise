using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input : MonoBehaviour
{

    [SerializeField]
    GameObject sce2;
    [SerializeField]
    GameObject sce3;
    private string inputt;
    void Start()
    {

    }

    void Update()
    {
        if(inputt == "192.168.1.1")
        {
            sce2.SetActive(false);
            sce3.SetActive(true);
            inputt = " ";
        }
    }

    public void EndValue(string s)
    {
        inputt = s; 
    }
}
