using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CheckFloor : MonoBehaviour
{
    [SerializeField] List<GameObject> floorButtons = new List<GameObject>();
    private GameObject previousFloor;
    [SerializeField] GameObject currentFloor;
    [SerializeField] Color highlightColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousFloor = currentFloor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            print(collision.gameObject.name);
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
