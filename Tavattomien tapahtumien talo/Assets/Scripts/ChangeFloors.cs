using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFloors : MonoBehaviour
{
    [SerializeField] private List<CinemachineCamera> floors = new List<CinemachineCamera>();
    public int currentFloorIndex = 1;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] CursorController cursorController;
    [SerializeField] List<Button> floor1Items = new List<Button>();
    [SerializeField] List<Button> floor2Items = new List<Button>();
    [SerializeField] List<Button> floor3Items = new List<Button>();
    [SerializeField] List<Button> floor4Items = new List<Button>();
    [SerializeField] List<Button> floor5Items = new List<Button>();
    [SerializeField] List<Button> floor6Items = new List<Button>();
    private List<List<Button>> allButtonLists;
    [SerializeField] private List<Button> floorSelctionButtons = new List<Button>();
    [SerializeField] private List<AudioClip> idleAudioClips = new List<AudioClip>();
    List<int> playedClips = new List<int>();

    [SerializeField] private AudioSource idleAudioSource;

    [SerializeField] private Color defaultHighlight;
    [SerializeField] private Color activatedhighlight;
    [SerializeField] private HandleItems handleItems;

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
        ChangeColor(floorSelctionButtons[chosenFloor]);
        
        PlayAudio(chosenFloor);
        
        if (!GameData.Instance.hintsEnabled)
        {
            SetAllButtonListsInteractable(false);
            SetButtonListInteractability(allButtonLists[chosenFloor], true);
        }
        else
        {
            SetAllButtonListsInteractable(false);
            SetButtonListInteractability(allButtonLists[chosenFloor], true);

            if (handleItems.currentItem.floor == currentFloorIndex)
            {

            handleItems.ActivateItem(handleItems.currentItem);
            }
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

    //Changes the elevators highlight color
    public void ChangeColor(Button button)
    {
        ResetFloorButtonColors();

        ColorBlock cb = button.colors;
        cb.highlightedColor = activatedhighlight;
        cb.selectedColor = activatedhighlight;
        button.colors = cb;
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

    private void ResetFloorButtonColors()
    {
        foreach (Button button in floorSelctionButtons)
        {
           ColorBlock cb = button.colors;
            cb.highlightedColor = defaultHighlight;
            cb.selectedColor = defaultHighlight;
            button.colors = cb;
        }
    }

    //Plays the audio for the floors only once when player goes to that floor
    private void PlayAudio(int chosenFloor)
    {
        if (idleAudioSource.isPlaying)
        {
            idleAudioSource.Stop();
        }

        if (playedClips.Contains(chosenFloor))
        {
            return; 
        }
        AudioClip clip = idleAudioClips[chosenFloor];

        if (clip == null)
        {
            return; 
        }

        idleAudioSource.PlayOneShot(clip);
        playedClips.Add(chosenFloor); 
    }

}
