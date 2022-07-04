using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        FindObjectOfType<AudioManager>().Play("gameost");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Main Scene");

        FindObjectOfType<AudioManager>().Play("gameost");

        Score.scoreValue = 0;
    }
}
