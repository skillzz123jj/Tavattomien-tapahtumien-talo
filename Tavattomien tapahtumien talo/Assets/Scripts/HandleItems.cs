using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class HandleItems : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private IterateButtons iterateItems;
    [SerializeField] private ShowHints showHints;
    [SerializeField] private TMP_Text itemCount;
    [SerializeField] public List<GameObject> items = new List<GameObject>();
    public bool itemDiscovered;
    public Items currentItem;

    private void Start()
    {
        GameData.Instance.gameOver = true;
        if (GameData.Instance.hintsEnabled)
        {     
            ResetItems();   
        }
        itemCount.text =  $"Överraskningar kvar: {items.Count}";

    }
    //When an item has been discovered it gets removed from the item list and deactivated
    public void ItemDiscovered(string item)
    {
        GameObject discovered = items.FirstOrDefault(go => go.name == item);
        Items itemAsset = showHints.items.FirstOrDefault(go => go.name == item);
        if (discovered != null)
        {
            items.Remove(discovered);
            discovered.GetComponent<AnimateItems>().TriggerAnimation();
            discovered.GetComponent<BoxCollider2D>().enabled = false;
            discovered.GetComponent<AudioSource>().Play();
            itemAsset.discoverable = false;
            itemCount.text = $"Överraskningar kvar: {items.Count}";

            if (items.Count <= 0)
            {
                Invoke("AllItemsDiscovered", 4.5f);
            }
            if (GameData.Instance.hintsEnabled)
            {
                showHints.RemoveItem(currentItem);
                iterateItems.nextIndex = iterateItems.buttons.Count - 2;
                itemDiscovered = true;
            }
        }
    }

    void AllItemsDiscovered()
    {
            GameData.Instance.gameOver = true;
            gameOver.SetActive(true);
            iterateItems.enabled = false;   
    }


  public void ActivateItem(Items item)
    {
        ResetItems();
        currentItem = item;
        GameObject chosenItem = items.FirstOrDefault(go => go.name == item.itemName);
        chosenItem.GetComponent<BoxCollider2D>().enabled = true;
        chosenItem.GetComponent<Button>().interactable = true;

    }

    private void ResetItems()
    {
        foreach (var item in items)
        {
            item.GetComponent<BoxCollider2D>().enabled = false;
        }
    }



}
