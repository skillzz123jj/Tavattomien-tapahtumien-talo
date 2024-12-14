using UnityEngine;

public class KeyboardInteraction : MonoBehaviour
{
    [SerializeField] private HandleItems handleItems;
    [SerializeField] private GameObject itemIndicator;
    [SerializeField] private IterateButtons iterateButtons;
    [SerializeField] private RotateAroundItem rotateAroundItem;
    [SerializeField] private IterateButtons iterateItems;
    public bool isItemChosen;
    Items currentItem;

    //Handles actions on keyboard
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
        if (currentItem.discoverable)
        {
        handleItems.ItemDiscovered(item.name);
        itemIndicator.SetActive(false);
        isItemChosen = false;

        }
     
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

    public void ItemBounds(GameObject bounds)
    {
        if (currentItem.discoverable)
        {
            bounds.SetActive(false);
        }
    }

    public void ChangeButtonIndex(int index)
    {
        if (handleItems.itemDiscovered)
        {
        iterateItems.nextIndex = iterateItems.buttons.Count - index;
        handleItems.itemDiscovered = false;
            
        }

    }
}
