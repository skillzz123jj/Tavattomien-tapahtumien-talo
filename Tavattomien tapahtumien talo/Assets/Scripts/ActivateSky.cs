using UnityEngine;

public class ActivateSky : MonoBehaviour
{

    [SerializeField] SpriteRenderer skySprite;
    [SerializeField] string skyTag;
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
