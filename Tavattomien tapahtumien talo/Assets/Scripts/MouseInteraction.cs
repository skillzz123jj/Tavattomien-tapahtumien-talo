using UnityEngine;

public class MouseInteraction : MonoBehaviour
{

     [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private HandleItems handleItems;

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world coordinates
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cast a ray that only detects objects on the "Clickable" layer
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, clickableLayer);

            // Check if the ray hit a clickable object
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Clicked on object: " + clickedObject.name);
                handleItems.ItemDiscovered(clickedObject.name);

                // Perform any actions with the clicked object here
            }
        }
    }
}
