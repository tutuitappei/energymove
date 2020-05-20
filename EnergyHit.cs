using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHit : MonoBehaviour, IHitPlayer
{
    public GameObject _chargeTarget;　　//エネルギー保存オブジェクト
    public float _chargmoment = 1.0f;   //エネルギーの量

    private bool smallFlag;             //エネルギーの縮小フラグ

    // Start is called before the first frame update
    void Start()
    {
        smallFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        var Chargeertarget = _chargeTarget.GetComponent<Chargeer>();

        //エネルギーの縮小化
        if (smallFlag == true)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.11f);
        }
        if ((transform.localScale.x < 0)&&(transform.localScale.y < 0) &&(transform.localScale.z < 0))
        {
            if (Chargeertarget != null)
            {
                _chargeTarget.GetComponent<Chargeer>().chergee(_chargmoment);
            }
            Destroy(gameObject);    　//エネルギーの削除
        }
    }
    //プレイヤーとの当たり判定
    public void HitPlayer(GameObject player)
    {
        smallFlag = true;
    }
}

