using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    public bool hovering;
    public RotateAroundItem rotateAroundItem;
    public static CursorController cursor;

    [SerializeField] private Vector2 hotspotDefault = new Vector2(8, 5);
    [SerializeField] private Vector2 hotspotHover = new Vector2(10, 6);
    [SerializeField] private LayerMask clickableLayer;
    

    public void ChangeCursor(Texture2D cursorType, Vector2 hotspot)
    {
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    void LateUpdate()
    {
        if (hovering || CheckForClickableObjects())
        {
            ChangeCursor(hoverCursor, hotspotHover);
        }
        else
        {
            ChangeCursor(defaultCursor, hotspotDefault);
        }
    }
    public void Hovering()
    {
        hovering = true;
    }
    public void ExitHovering()
    {
        hovering = false;
    }

    bool CheckForClickableObjects()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, clickableLayer);

        if (hit)
        { 
                if (hit.collider.gameObject.CompareTag("Item"))
                {
                if (rotateAroundItem != null)
                {
                    rotateAroundItem.boxCollider = (BoxCollider2D)hit.collider;
                    rotateAroundItem.isHoveringOverItem = true;
                }

                return true;
                }
        }
        if (rotateAroundItem != null)
        {
            rotateAroundItem.boxCollider = null;
            rotateAroundItem.isHoveringOverItem = false;
        }
     
        return false;
    }
}
