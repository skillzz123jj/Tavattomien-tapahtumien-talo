using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFloors : MonoBehaviour
{
    [SerializeField] private List<CinemachineCamera> floors = new List<CinemachineCamera>();
    private int currentFloorIndex = 1;
    [SerializeField] GameObject upArrow;
    [SerializeField] GameObject downArrow;

    public void ChangeFloor(int chosenFloor)
    {
        CinemachineCamera cam = floors[chosenFloor];
        cam.Priority = 1;
        currentFloorIndex = chosenFloor;
        CheckFloorStatus();

        for (int i = 0; i < floors.Count; i++)
        {
            if (i != chosenFloor)
            {
                floors[i].Priority = 0;
            }
        }
    }

    public void ChooseUpperFloor()
    {
        currentFloorIndex++;
        ChangeFloor(currentFloorIndex);

    }

    public void ChooseLowerFloor()
    {
        currentFloorIndex--;
        ChangeFloor(currentFloorIndex);

    }

    public void ChangeColor(Button button)
    {

        button.interactable = false;
        button.interactable = true;

    }

    private void CheckFloorStatus()
    {
        if (currentFloorIndex == 5)
        {
            upArrow.SetActive(false);
        }
        else
        {
            upArrow.SetActive(true);
        }

        if (currentFloorIndex == 0)
        {
            downArrow.SetActive(false);
        }
        else
        {
            downArrow.SetActive(true);
        }
    }
}
