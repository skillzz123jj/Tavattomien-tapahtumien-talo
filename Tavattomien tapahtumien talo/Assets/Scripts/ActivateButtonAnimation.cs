using UnityEngine;

public class ActivateButtonAnimation : MonoBehaviour
{
    [SerializeField] GameObject revealHintBox;
    [SerializeField] GameObject hintBox;
    [SerializeField] Animator anim;

    public void ActivateButton()
    {
        hintBox.SetActive(true);
        revealHintBox.SetActive(false); 
        anim.enabled = false;
    }
}
