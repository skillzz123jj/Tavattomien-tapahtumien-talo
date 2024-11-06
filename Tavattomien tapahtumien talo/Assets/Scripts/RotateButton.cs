using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    public Button button;
    public GameObject openHint;
    public GameObject hint;

    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip questionClip;
    [SerializeField] GameObject answerClip;
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
            _source.mute = true;
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
                _source.mute = false;


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

        //if (lastPlayedClip)
        //{
        //    if (lastPlayedClip == source.clip)
        //    {
        //        // Do nothing if the same clip is already playing
        //        return;
        //    }
                
        //}

        // If a different clip is requested, stop the current one and play the new one
        source.Stop();
        source.PlayOneShot(currentClip);

        // Update the last played clip
       // lastPlayedClip = currentClip;
    }
}


