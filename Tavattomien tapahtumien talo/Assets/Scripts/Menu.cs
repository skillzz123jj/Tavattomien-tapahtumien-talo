using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Button stopAudioButton;
    [SerializeField] GameObject muteAudioButton;
    [SerializeField] GameObject unmuteAudioButton;

    private void Start()
    {
        if (GameData.Instance.isAudioMuted)
        {
            unmuteAudioButton.SetActive(true);
            unmuteAudioButton.GetComponent<Button>().interactable = true;

            muteAudioButton.SetActive(false);
            muteAudioButton.GetComponent<Button>().interactable = false;
        }
    }
    public bool CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return true; 
        }
        return false; 
    }

    public void ManageAudio(bool audioStatus)
    {
        if (CheckInput())
        {
            return; 
        }
        GameData.Instance.isAudioMuted = audioStatus;
        AudioListener.volume = audioStatus == false ? 1f : 0f;
    }

    public void ChangeScene(int scene)
    {
        if (CheckInput())
        {
            return; 
        }
        SceneManager.LoadScene(scene);
    }

    public void CloseGame()
    {
        if (CheckInput())
        {
            return;
        }
        Application.ExternalEval("window.close();");
    }

    public void ChooseSetting(bool settingStatus)
    {
        GameData.Instance.hintsEnabled = settingStatus;
    }
    public void PlayInstructions()
    {
        if (CheckInput())
        {
            return;
        }
        StartCoroutine(PlayAudio());
    }
    public IEnumerator PlayAudio()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
        stopAudioButton.onClick.Invoke();
    }
    public void PreventInteraction()
    {
        if (CheckInput())
        {
            return;
        }
    }
}
