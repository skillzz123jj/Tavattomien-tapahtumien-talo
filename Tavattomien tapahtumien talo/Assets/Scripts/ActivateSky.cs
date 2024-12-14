using UnityEngine;

public class ActivateSky : MonoBehaviour
{
    [SerializeField] private SpriteRenderer skySprite;
    [SerializeField] private string skyTag;

    //Triggers sky sprite on/off based on current floor
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(skyTag))
        {
            skySprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(skyTag))
        {
            skySprite.enabled = false;
        }
    }
}
