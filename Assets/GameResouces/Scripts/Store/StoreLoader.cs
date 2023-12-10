using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLoader : MonoBehaviour
{
    private const string CHARACTERS_KEY = "characters";
    private const string LOCATION_KEY = "locations";


    [SerializeField]
    private InternalPurchasePanel[] _characters;
    [SerializeField]
    private InternalPurchasePanel[] _locations;


}
