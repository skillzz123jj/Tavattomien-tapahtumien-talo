using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowHints : MonoBehaviour
{
    [SerializeField] private GameObject hintsDisabledBox;
    [SerializeField] private GameObject hintsEnabledBox;

    [SerializeField] private List<GameObject> hints = new List<GameObject>();

    [SerializeField] private List<Button> hintButtons = new List<Button>();

    [SerializeField] private GameObject hint1;
    [SerializeField] private GameObject hint2;
    [SerializeField] private GameObject hint3;
    [SerializeField] public List<Items> items = new List<Items>();

    [SerializeField] private HandleItems handleItems;

    [SerializeField] private GameObject elevatorInstruction;

    [SerializeField] private ChangeFloors changeFloors;

    void Start()
    {
        if (GameData.Instance.hintsEnabled)
        {
            hintsEnabledBox.SetActive(true);
            hintsDisabledBox.SetActive(false);
            InitializeButtons(true);
            ChooseHint();
        }
        else
        {
            ResetItems(true);
            hintsEnabledBox.SetActive(false);
            hintsDisabledBox.SetActive(true);
            InitializeButtons(false);
        }
        StartCoroutine(ShowInstructions(20));

    }

    public void ChooseHint()
    {
        if (items.Count > 0)
        {
            ResetItems(false);
            int index = Random.Range(0, items.Count);
            Items chosenItem = items[index];
            foreach (var hint in hints)
            {
                hint.GetComponent<RotateButton>().isRotated = true;
                hint.GetComponent<Button>().onClick.Invoke();

            }
            ShowHint(chosenItem);
            handleItems.currentItem = chosenItem;
            chosenItem.discoverable = true;

            if (handleItems.currentItem.floor == changeFloors.currentFloorIndex)
            {
                handleItems.ActivateItem(handleItems.currentItem);
            }
        }
    }

    public void RemoveItem(Items item)
    {
        items.Remove(item);
    }
    public void ShowHint(Items item)
    {
        hint1.GetComponent<TMP_Text>().text = item.whatKindClip.name;
        hint2.GetComponent<TMP_Text>().text = item.whereClip.name;
        hint3.GetComponent<TMP_Text>().text = item.whatDescriptionClip.name;

        if (item.whatKindClip != null)
        {
            hint1.GetComponent<AudioSource>().clip = item.whatKindClip;
        }

        if (item.whereClip != null)
        {
            hint2.GetComponent<AudioSource>().clip = item.whereClip;
        }

        if (item.whatDescriptionClip != null)
        {
            hint3.GetComponent<AudioSource>().clip = item.whatDescriptionClip;
        }
    }

    private void InitializeButtons(bool activated)
    {
        foreach (Button button in hintButtons)
        {
            button.interactable = activated;
        }
    }

    IEnumerator ShowInstructions(float time)
    {
        if (elevatorInstruction != null)
        {
            elevatorInstruction.SetActive(true);
        }
        yield return new WaitForSeconds(time);

        elevatorInstruction.SetActive(false);
    }

    private void ResetItems(bool activate)
    {
        foreach(Items item in items)
        {
            item.discoverable = activate;
        }
    }
}
