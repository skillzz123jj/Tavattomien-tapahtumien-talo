using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IterateButtons : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    int nextIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            do
            {
                nextIndex = (nextIndex + 1) % buttons.Count;
            }
            while (!buttons[nextIndex].interactable);

            buttons[nextIndex].Select();
        }
    }
}
