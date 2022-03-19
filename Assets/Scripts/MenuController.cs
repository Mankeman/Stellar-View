using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void LOAD_SCENE(string SceneName)
    {

        SceneManager.LoadScene(SceneName);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
