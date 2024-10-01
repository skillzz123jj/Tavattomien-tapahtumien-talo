using UnityEngine;
using UnityEngine.UI;


public class KeyboardInteraction : MonoBehaviour
{
    [SerializeField] private HandleItems handleItems;
    [SerializeField] private GameObject itemIndicator;
    [SerializeField] private IterateButtons iterateButtons;

    void Update()
    {
        if (!iterateButtons.isItem)
        {
            itemIndicator.SetActive(false);
        }
    }

    public void DiscoverItem(GameObject item)
    {
        handleItems.ItemDiscovered(item.name);
        iterateButtons.RemoveButton(item.GetComponent<Button>());
        itemIndicator.SetActive(false);
     
    }

    public void MoveIndicator(Transform item)
    {
        itemIndicator.transform.position = item.position;
        itemIndicator.SetActive(true);
    }
}
