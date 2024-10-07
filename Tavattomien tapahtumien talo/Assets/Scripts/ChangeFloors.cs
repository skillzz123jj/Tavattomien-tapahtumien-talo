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
    [SerializeField] CursorController cursorController;
    [SerializeField] List<Button> floor1Items = new List<Button>();
    [SerializeField] List<Button> floor2Items = new List<Button>();
    [SerializeField] List<Button> floor3Items = new List<Button>();
    [SerializeField] List<Button> floor4Items = new List<Button>();
    [SerializeField] List<Button> floor5Items = new List<Button>();
    [SerializeField] List<Button> floor6Items = new List<Button>();
    private List<List<Button>> allButtonLists;

    void Start()
    {
        allButtonLists = new List<List<Button>> {
            floor1Items, floor2Items, floor3Items,
            floor4Items, floor5Items, floor6Items};
        SetAllButtonListsInteractable(false);
        ChangeFloor(1);
    }
        public void ChangeFloor(int chosenFloor)
    {
        CinemachineCamera cam = floors[chosenFloor];
        cam.Priority = 1;
        currentFloorIndex = chosenFloor;
        CheckFloorStatus();

        if (!GameData.Instance.hintsEnabled)
        {
            SetAllButtonListsInteractable(false);
            SetButtonListInteractability(allButtonLists[chosenFloor], true);
        }
     
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
            cursorController.ExitHovering();
        }
        else
        {
            upArrow.SetActive(true);
        }

        if (currentFloorIndex == 0)
        {
            downArrow.SetActive(false);
            cursorController.ExitHovering();

        }
        else
        {
            downArrow.SetActive(true);
        }
    }

    private void SetAllButtonListsInteractable(bool isInteractable)
    {
        foreach (var buttonList in allButtonLists)
        {
            SetButtonListInteractability(buttonList, isInteractable);
        }
    }

    private void SetButtonListInteractability(List<Button> buttonList, bool isInteractable)
    {
        foreach (var button in buttonList)
        {
            button.interactable = isInteractable;
        }
    }
}
