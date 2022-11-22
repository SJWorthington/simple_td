using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralTile : MonoBehaviour
{
    //todo - this should be a more specific class that, turret or somesuch
    private GameObject unitInTile;

    public void SetUnitInTile(GameObject unit)
    {
        unitInTile = unit;
    }

    public bool IsTileEmpty()
    {
        return unitInTile is null;
    }
}
