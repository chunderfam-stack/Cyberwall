using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }
}
