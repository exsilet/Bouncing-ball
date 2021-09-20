using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private int _money;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction Died;

    public void ApplayDamage()
    {
        Die();
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void IncreaseMoney()
    {
        _money++;
        MoneyChanged?.Invoke(_money);
    }

    public void ResetPlayer()
    {
        _money = 0;
        MoneyChanged?.Invoke(_money);
    }

}
