using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMove : MonoBehaviour
{

    public bool DropFrag;                                // 起動用フラグ

    public GameObject CatchObject;                       // 受け取る側のオブジェクト
    public GameObject ReleaseObject;                     // 放たれる側のオブジェクト

    [SerializeField, Range(0F, 90F)] private float Releaseangle = 0f;         // 角度


    // Start is called before the first frame update
    void Start()
    {
        DropFrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DropFrag)
        {
            Drop();
        }
    }

    private void Drop()
    {
        if ((CatchObject != null)&&(ReleaseObject != null))
        {
            GameObject DropItem = Instantiate(ReleaseObject, this.transform.position, Quaternion.identity);

            Vector3 targetPosition = CatchObject.transform.position;

            float angle = Releaseangle;

            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            Rigidbody rid = DropItem.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);



        }
    }

    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
