using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    private Vector2 previousMousePos;
    private Camera mainCamera;

    private NeutralTile latestTile;

    [SerializeField] private UnitPlacer unitPlacer;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (mousePos == previousMousePos)
        {
            return;
        }

        previousMousePos = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //todo - Learn more about c# null wrappers, this could probably use those _or_ or switch to be much more concise
        //also, feels like the mouse input manager is doing more than it should here, maybe it should just pass its hit through and the data can be parsed elsewhere
        if (hit.collider is null || !hit.transform.CompareTag("NeutralTile"))
        {
            unitPlacer.NotifyOfUpdatedTile(null);
            latestTile = null;
            return;
        }

        var tile = hit.transform.GetComponent<NeutralTile>();
        if (tile is null)
        {
            unitPlacer.NotifyOfUpdatedTile(null);
            latestTile = null;
            return;
        }

        if (!tile.IsTileEmpty())
        {
            unitPlacer.NotifyOfUpdatedTile(null);
            latestTile = null;
            return;
        }

        if (latestTile is null || latestTile.GetInstanceID() != tile.GetInstanceID())
        {
            unitPlacer.NotifyOfUpdatedTile(tile);
            latestTile = tile;
        }
    }
}