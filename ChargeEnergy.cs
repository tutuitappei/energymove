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

    // ゲット関数
    public float EnergyMoment()
    {
        return energymoment;
    }

    // 引数で受け取った分エネルギーをとる
    public void PullEnergy(float amount)
    {
        energymoment -= amount;

        // バグ防止
        if (energymoment < 0)
        {
            energymoment = 0;
        }
    }
}
