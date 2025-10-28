
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour
{
    
    public void Star()
    {
        SceneManager.LoadScene("Game");
    }

     public void quit()
    {
        Application.Quit();

    }
}
