using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFloor : MonoBehaviour
{
    [SerializeField] private Dictionary<string, GameObject> floorButtons = new Dictionary<string, GameObject>();
    [SerializeField] private List<GameObject> floorButtonsList = new List<GameObject>();
    [SerializeField] private GameObject currentFloor;
    [SerializeField] private Color highlightColor;
    private GameObject previousFloor;

    void Start()
    {
        previousFloor = currentFloor;

        foreach (var obj in floorButtonsList)
        {
            floorButtons.Add(obj.name, obj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            HighlightFloor(collision.gameObject.name);
        }
    }

    private void HighlightFloor(string floorName)
    {
        previousFloor.GetComponent<Image>().color = Color.white;

        if (floorButtons.TryGetValue(floorName, out GameObject floorButton))
        {
            currentFloor = floorButton;
            currentFloor.GetComponent<Image>().color = highlightColor;
        }

        previousFloor = currentFloor;
    }
}
