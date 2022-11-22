using JetBrains.Annotations;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{
    //todo - delete when we start using the UI to pass in turrets
    [SerializeField] private GameObject tempTurretPrefab;

    private BasicTurret selectedTurret;
    private MoneyManager moneyManager;

    private NeutralTile currentTile;

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        SetSelectedTurret(tempTurretPrefab);
    }

    public void SetSelectedTurret(GameObject turret)
    {
        selectedTurret = Instantiate(turret, transform.position, Quaternion.identity)
            .GetComponent<BasicTurret>();
        selectedTurret.EnterPlaceholderMode();
    }

    void Update()
    {
        //todo - stop fudging the money bit
        if (!Input.GetMouseButtonDown(0) || moneyManager.Money < 300 || currentTile is null) return;
        selectedTurret.EnterActiveMode();
        currentTile.SetUnitInTile(selectedTurret.gameObject);
        SetSelectedTurret(tempTurretPrefab);
        moneyManager.updateMoney(-300);
    }

    public void NotifyOfUpdatedTile([CanBeNull] NeutralTile tile)
    {
        currentTile = tile;
        selectedTurret.transform.position = tile?.transform.position ?? transform.position;
    }
}