using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //lives, money, etc.

    public static int Money;
    public int startMoney = 0;

    public int startLives = 10;
    public static int Lives;

    //references for UI purposes
    public Text moneytext;
    public Text liveText;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    private void Update()
    {
        //floor cleans up the decimal places, not that useful for ints but useful for floats, etc.
        moneytext.text = Mathf.Floor(Money).ToString();
        liveText.text = Mathf.Floor(Lives).ToString();
    }

}
