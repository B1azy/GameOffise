using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifi : MonoBehaviour
{
    [SerializeField]
    GameObject wif;
    [SerializeField]
    GameObject lig;
    // Start is called before the first frame update
    void Start()
    {
        wif.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lig.active == true) wif.SetActive(true);
    }
}
