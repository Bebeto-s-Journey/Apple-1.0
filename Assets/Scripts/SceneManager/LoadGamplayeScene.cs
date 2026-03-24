using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGamplayeScene : MonoBehaviour
{
    
   public void Play(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1f;
    }
}
