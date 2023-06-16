using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    [SerializeField]
    GameObject Sqre;
    [SerializeField]
    GameObject lig;
    [SerializeField]
    GameObject lig2;
    // Start is called before the first frame update
    void Start()
    {
        lig.SetActive(false);
        lig2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Sqre.active == true) lig.SetActive(true);
    }
}
