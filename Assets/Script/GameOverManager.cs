using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync(1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
        
}
