using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [field: SerializeField] public int Money { get; private set; } = 1000;

    public void updateMoney(int amount)
    {
        Money += amount;
        Debug.Log($"Remaining money is ${Money}");
        //OnMoneyChanged.Invoke(money);
    }
    
    //TODO - probs use for UI
    //public static event Action<int> OnMoneyChanged;
}
