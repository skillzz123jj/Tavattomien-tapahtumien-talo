using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Vector2 hotspotDefault = new Vector2(8, 5);
    public Vector2 hotspotHover = new Vector2(10, 6);

    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    bool hovering;

    public static CursorController cursor;

    public void ChangeCursor(Texture2D cursorType, Vector2 hotspot)
    {
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (hovering)
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
}
