
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour
{
    
    public void Star()
    {
        SceneManager.LoadScene(1);
    }

     public void quit()
    {
        Application.Quit();

    }
}
