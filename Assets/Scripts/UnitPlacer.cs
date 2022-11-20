
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{
    [SerializeField] private GameObject selectedTurret;
    private MoneyManager _moneyManager;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _moneyManager = FindObjectOfType<MoneyManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _moneyManager.Money >= 500) //TODO - get cost of unit from selected unit
        {
            var position = _camera.ScreenToWorldPoint(Input.mousePosition);
            position.z = _camera.nearClipPlane;
            Instantiate(selectedTurret, position, Quaternion.identity);
            _moneyManager.updateMoney(-500);
        }
    }
}
