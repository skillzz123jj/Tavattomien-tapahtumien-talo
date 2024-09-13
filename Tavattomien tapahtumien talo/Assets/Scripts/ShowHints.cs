using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowHints : MonoBehaviour
{
    [SerializeField] private GameObject hintsDisabledBox;
    [SerializeField] private GameObject hintsEnabledBox;

    [SerializeField] private List<GameObject> hints = new List<GameObject>();

    [SerializeField] private TMP_Text hint1Text;
    [SerializeField] private TMP_Text hint2Text;
    [SerializeField] private TMP_Text hint3Text;
    [SerializeField] private List<Items> items = new List<Items>();


    void Start()
    {
        if (GameData.Instance.hintsEnabled)
        {
            hintsEnabledBox.SetActive(true);
            hintsDisabledBox.SetActive(false);
            ChooseHint();
        }
        else
        {
            hintsEnabledBox.SetActive(false);
            hintsDisabledBox.SetActive(true);

        }
    }

    public void ChooseHint()
    {
        int index = Random.Range(0, items.Count);
        Items chosenItem = items[index];
        foreach (var hint in hints)
        {
            if (hint.GetComponent<RotateButton>().isRotated)
            {
                hint.GetComponent<Button>().onClick.Invoke();
            }
        }
        ShowHint(chosenItem);
    }

    public void ShowHint(Items item)
    {
        hint1Text.text = item.whatKind;
        hint2Text.text = item.where;
        hint3Text.text = item.whatDescription;

    }
}
