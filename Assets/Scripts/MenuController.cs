using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void NextScene()
    {
        //Move to the next scene more efficiently
        //Loading a scene with a string can get messy, because what if the scene name got changed?
        //Grab the scenes in the build and move accordingly
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        //Exit the game when it becomes built.
        Application.Quit();
    }
}
