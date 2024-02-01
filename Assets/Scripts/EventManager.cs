using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this; 
    }

    public event Action OnCoinPickUp;

    public void CoinPickUp()
    {
        OnCoinPickUp?.Invoke();
    }

    public event Action Test;

    public void Test2()
    {
        Test?.Invoke();
    }


}
