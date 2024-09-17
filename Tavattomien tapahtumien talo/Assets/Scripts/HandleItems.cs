using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class HandleItems : MonoBehaviour
{
    [SerializeField] public List<GameObject> items = new List<GameObject>();
  
    public void ItemDiscovered(string item)
    {
        GameObject discovered = items.FirstOrDefault(go => go.name == item);
        if (discovered != null)
        {
            items.Remove(discovered);
            discovered.GetComponent<AnimateItems>().TriggerAnimation();
        }
       
    }

  
 


}
