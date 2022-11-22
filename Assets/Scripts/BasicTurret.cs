using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    [SerializeField] private GameObject activeTurretPrefab;
    [SerializeField] private GameObject placeholderTurretPrefab;
    
    private GameObject activeTurret;
    private GameObject placeholderTurret;

    private void Awake()
    {
        activeTurret = Instantiate(activeTurretPrefab, transform.position, Quaternion.identity);
        activeTurret.SetActive(false);
        activeTurret.transform.parent = transform;

        placeholderTurret = Instantiate(placeholderTurretPrefab, transform.position, Quaternion.identity);
        placeholderTurret.SetActive(false);
        placeholderTurret.transform.parent = transform;
    }

    public void EnterPlaceholderMode()
    {
        activeTurret.SetActive(false);
        placeholderTurret.SetActive(true);
    }

    public void EnterActiveMode()
    {
        placeholderTurret.SetActive(false);
        activeTurret.SetActive(true);
    }
}
