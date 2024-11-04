using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Scriptable Objects/Objects")]
public class Items : ScriptableObject
{
    public string itemName;
    public string whatKind;
    public string where;
    public string whatDescription;
    public int floor; 
    public AudioClip whatKindClip;
    public AudioClip whereClip;
    public AudioClip whatDescriptionClip;

}
