using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    public bool hovering;
    [SerializeField] Vector2 hotspotDefault = new Vector2(8, 5);
    [SerializeField] Vector2 hotspotHover = new Vector2(10, 6);

    public static CursorController cursor;

    public void ChangeCursor(Texture2D cursorType, Vector2 hotspot)
    {
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    void Update()
    {
        //Changes cursor and its hotspot based on activity
        if (hovering)    //|| CheckForClickableObjects())
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

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit)
        {
 
                if (hit.collider.gameObject.CompareTag("Item"))
                {
                Debug.Log(hit.collider.gameObject.name);
                    return true;
                }
            
        }

        return false;
    }
}
