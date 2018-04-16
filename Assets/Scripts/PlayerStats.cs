using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Lives;
    public static int Money;

    public int startLives = 20;
    public int startMoney = 400;

    public static int rounds;

    private void Start()
    {
        rounds = 0;
        Lives = startLives;
        Money = startMoney;
    }
}
