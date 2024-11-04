using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class HandleItems : MonoBehaviour
{
    [SerializeField] public List<GameObject> items = new List<GameObject>();
    [SerializeField] private GameObject gameOver;
    [SerializeField] private IterateButtons iterateItems;
    [SerializeField] private ShowHints showHints;
    public Items currentItem;

    private void Start()
    {
        if (GameData.Instance.hintsEnabled)
        {     
            ResetItems();   
        }
    }
    public void ItemDiscovered(string item)
    {
        GameObject discovered = items.FirstOrDefault(go => go.name == item);
        if (discovered != null)
        {
            items.Remove(discovered);
            discovered.GetComponent<AnimateItems>().TriggerAnimation();
            discovered.GetComponent<BoxCollider2D>().enabled = false;
            discovered.GetComponent<AudioSource>().Play();
  
            if (items.Count <= 0)
            {
                Invoke("AllItemsDiscovered", 4);
            }
            if (GameData.Instance.hintsEnabled)
            {
                showHints.RemoveItem(currentItem);
            }
        }

    }

    void AllItemsDiscovered()
    {
        
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
