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

    [SerializeField] private TMP_Text hint1Text;
    [SerializeField] private TMP_Text hint2Text;
    [SerializeField] private TMP_Text hint3Text;
    [SerializeField] private List<Items> items = new List<Items>();

    [SerializeField] private HandleItems handleItems;

    [SerializeField] private GameObject elevatorInstruction;


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
            hintsEnabledBox.SetActive(false);
            hintsDisabledBox.SetActive(true);
            InitializeButtons(false);
        }

    }

    public void ChooseHint()
    {
        int index = Random.Range(0, items.Count);
        Items chosenItem = items[index];
        foreach (var hint in hints)
        {
                hint.GetComponent<RotateButton>().isRotated = true;
                hint.GetComponent<Button>().onClick.Invoke();
            
        }
        ShowHint(chosenItem);
        handleItems.ActivateItem(chosenItem);
    }

    public void RemoveItem(Items item)
    {
        items.Remove(item);
    }
    public void ShowHint(Items item)
    {
        hint1Text.text = item.whatKind;
        hint2Text.text = item.where;
        hint3Text.text = item.whatDescription;


    }

    private void InitializeButtons(bool activated)
    {
        foreach (Button button in hintButtons)
        {
            button.interactable = activated;
        }
    }
}
