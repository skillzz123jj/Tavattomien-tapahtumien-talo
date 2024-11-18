using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IterateButtons : MonoBehaviour
{
    [SerializeField] public List<Button> buttons = new List<Button>();
    public int nextIndex = -1;
    public bool isItem;
 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            do
            {
                nextIndex = (nextIndex + 1) % buttons.Count;
            }
            while (!buttons[nextIndex].interactable || !buttons[nextIndex].gameObject.activeSelf);
            isItem = buttons[nextIndex].CompareTag("Item");  
            buttons[nextIndex].Select();
        }
    }

    public void RemoveButton(Button item)
    {
        buttons.Remove(item);
        nextIndex--;
    }
    public void SkipIndex()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        nextIndex++;
    }
    public void ReturnIndex()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        nextIndex--;
    }
}
