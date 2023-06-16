using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void GoToLevel(int number)
    {
        Effects.FadeScreen(Color.black, 0, 1, 1, () => SceneManager.LoadScene(number));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
