using UnityEngine;

public class KeyboardInteraction : MonoBehaviour
{
    [SerializeField] private HandleItems handleItems;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiscoverItem(GameObject item)
    {
        handleItems.ItemDiscovered(item.name);
    }
}
