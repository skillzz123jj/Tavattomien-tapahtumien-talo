using UnityEngine;
using UnityEngine.UI;

public class KeyboardInteraction : MonoBehaviour
{
    [SerializeField] private HandleItems handleItems;
    [SerializeField] private GameObject itemIndicator;
    [SerializeField] private IterateButtons iterateButtons;
    [SerializeField] private RotateAroundItem rotateAroundItem;
    public bool isItemChosen;
    Items currentItem;
    void Update()
    {
        if (!iterateButtons.isItem)
        {
            itemIndicator.SetActive(false);
        }
    }

    public void CurrentItem(Items item)
    {
        currentItem = item; 
    }
    public void DiscoverItem(GameObject item)
    {
        handleItems.ItemDiscovered(item.name);
       // iterateButtons.RemoveButton(item.GetComponent<Button>());
        isItemChosen = false;
        itemIndicator.SetActive(false);
     
    }

    public void MoveIndicator(Transform item)
    {
        if (currentItem.discoverable)
        {
        itemIndicator.SetActive(true);
        isItemChosen = true;

        }
        else
        {
            itemIndicator.SetActive(false);
        }
        itemIndicator.transform.position = item.position;

    }
}
