using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool PreventInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return true; 
        }
        return false; 
    }

    public void ManageAudio(bool audioStatus)
    {
        if (PreventInteraction())
        {
            return; 
        }
        GameData.Instance.isAudioMuted = audioStatus;
    }

    public void ChangeScene(int scene)
    {
        if (PreventInteraction())
        {
            return; 
        }
        SceneManager.LoadScene(scene);
    }

    public void CloseGame()
    {
        if (PreventInteraction())
        {
            return;
        }
        Application.ExternalEval("window.close();");
    }
}
