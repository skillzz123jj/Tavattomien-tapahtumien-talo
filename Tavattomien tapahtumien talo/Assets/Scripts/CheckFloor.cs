using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckFloor : MonoBehaviour
{
    [SerializeField] List<GameObject> floorButtons = new List<GameObject>();
    private GameObject previousFloor;
    [SerializeField] GameObject currentFloor;
    [SerializeField] Color highlightColor;

    void Start()
    {
        previousFloor = currentFloor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            HighlightFloor(collision.gameObject.name);
        }
    }

    private void HighlightFloor(string floor)
    {
       
        previousFloor.GetComponent<Image>().color = Color.white;
        foreach (GameObject obj in floorButtons)
        {
            if (obj.name == floor)
            {
                currentFloor = obj;
                currentFloor.GetComponent<Image>().color = highlightColor;

            }
        }
        previousFloor = currentFloor;
    }
}
