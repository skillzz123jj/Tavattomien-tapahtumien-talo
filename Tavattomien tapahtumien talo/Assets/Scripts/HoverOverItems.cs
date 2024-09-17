using UnityEngine;

public class HoverOverItems : MonoBehaviour
{
    public CursorController cursorController;

  

    void OnMouseEnter()
    {
        cursorController?.Hovering(); 
    }

    void OnMouseExit()
    {
        cursorController?.ExitHovering(); 
    }
}
