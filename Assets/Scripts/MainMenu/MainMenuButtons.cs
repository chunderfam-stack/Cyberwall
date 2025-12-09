using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject howToPanel;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void enableDisablePanel()
    {
        howToPanel.SetActive(!howToPanel.activeInHierarchy);
    }
}
