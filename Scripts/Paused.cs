using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject pods;
    [SerializeField]
    GameObject zad;
    void Start()
    {
        pause.SetActive(false);
        pods.SetActive(false);
        zad.SetActive(false);
    }

    void Update()
    { 
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(zad.active == true) ZadOff();
            else if(pods.active == true) PodsOff();
            else PauseOn();
        }
    }


    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //
    public void PauseOn()
    {
        if (pause.active == true)
        {
            PauseOff();
        }
        else
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    //
    public void PodsOn()
    {
        if (pods.active == true)
        {
            PodsOff();
        }
        else
        {
            if(zad.active == false)
            pods.SetActive(true);
        }
    }

    public void PodsOff()
    {
        pods.SetActive(false);
    }

    //
    public void ZadOn()
    {
        if (zad.active == true)
        {
            ZadOff();
        }
        else
        {
            if (pods.active == false)
                zad.SetActive(true);
        }
    }

    public void ZadOff()
    {
        zad.SetActive(false);
    }
}
