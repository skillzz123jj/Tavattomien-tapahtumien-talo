using UnityEngine;
using UnityEngine.UI;

public class MouseInteraction : MonoBehaviour
{

     [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private HandleItems handleItems;
    [SerializeField] private IterateButtons iterateButtons;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, clickableLayer);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Clicked on object: " + clickedObject.name);
                handleItems.ItemDiscovered(clickedObject.name);
                iterateButtons.RemoveButton(hit.collider.gameObject.GetComponent<Button>());
            }
        }
    }
}
