using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnergy : MonoBehaviour, Chargeer
{
    private float energymoment;     //エネルギーの取得量

    // Start is called before the first frame update
    void Start()
    {
        energymoment = 0.0f;
    }

    public void chergee(float energy)
    {
        //エネルギー取得量の追加
        energymoment += energy;
        Debug.Log("add: " + energy + "total: " + energymoment);
    }
}
