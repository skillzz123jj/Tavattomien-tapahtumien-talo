using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloorItems", menuName = "Scriptable Objects/FloorItems")]
public class FloorItems : ScriptableObject
{
    public List<GameObject> items = new List<GameObject>();
    public int listIndex;
}
