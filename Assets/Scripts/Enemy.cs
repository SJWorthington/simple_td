using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveVelocity = 2;
    private int _currentTargetIndex = 0;
    private Vector2 currentTarget;
    private List<Transform> waypoints = new List<Transform>();
    [field: SerializeField] public int Damage { get; } = 1;
    [SerializeField] int currencyValue = 100;
    private MoneyManager _moneyManager;
    
    private void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (waypoints.Count == 0) return;
        var sqrRemainingDistance = ((Vector2) transform.position - currentTarget).sqrMagnitude;
        if (sqrRemainingDistance < 0.0005)
        {
            _currentTargetIndex++;
            currentTarget = waypoints[_currentTargetIndex].position;
        }

        float step = moveVelocity * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, step);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _moneyManager.updateMoney(currencyValue);
        }
        Destroy(gameObject);
    }

    public void setWaypoints(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
        currentTarget = waypoints[0].transform.position;
    }
}