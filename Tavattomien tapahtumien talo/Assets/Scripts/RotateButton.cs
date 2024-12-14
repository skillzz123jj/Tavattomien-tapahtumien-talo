using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    public Button button;
    public GameObject openHint;
    public GameObject hint;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip questionClip;
    [SerializeField] private GameObject answerClip;
    AudioClip currentClip;
    private bool isRotating = false;
    public bool isRotated = true;
    private float rotationDuration = 1f; 

    public void TriggerRotation()
    {
        if (isRotating) return;
        isRotating = true;
        StartCoroutine(RotateObject());
    }

    //Rotates the hint buttons once they are pressed
    private IEnumerator RotateObject()
    {
        float elapsed = 0f;
        float startRotation = isRotated ? 180f : 0f; 
        float endRotation = isRotated ? 0f : 180f;   
        openHint.SetActive(false);
        hint.SetActive(false);

        float initialRotation = button.transform.eulerAngles.x;

        while (elapsed < rotationDuration)
        {
            float angle = Mathf.Lerp(startRotation, endRotation, elapsed / rotationDuration);
            button.transform.eulerAngles = new Vector2(angle, 0);
            button.enabled = false;
            _source.Stop();
            elapsed += Time.deltaTime;
            yield return null;
        }
        isRotated = !isRotated;
        button.transform.eulerAngles = new Vector2(endRotation, 0);
        button.enabled = true;
   
        if (isRotated)
        {
            hint.SetActive(true);
            if (answerClip.GetComponent<AudioSource>().clip != null)
            {
                currentClip = answerClip.GetComponent<AudioSource>().clip;
                PlayAudio(_source);
            }
        }
        else
        {
            openHint.SetActive(true);
            currentClip = questionClip;
        }

        isRotating = false;
    }

    private AudioClip lastPlayedClip = null;

    public void PlayAudio(AudioSource source)
    {

        if (source.isPlaying && currentClip == lastPlayedClip)
        {
            return;
        }
     
        source.Stop();
        source.PlayOneShot(currentClip);

        lastPlayedClip = currentClip;
    }
}


