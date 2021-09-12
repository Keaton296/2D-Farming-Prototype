using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="FarmObjects")]
public class FarmObjects : ScriptableObject
{
    [SerializeField]GameObject shop;
    [SerializeField]GameObject windmill;
    public GameObject crop;
    public GameObject droppeditem;
}
