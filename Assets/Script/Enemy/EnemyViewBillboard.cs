using System;
using UnityEngine;

public class EnemyViewBillboard : MonoBehaviour
{
    void Update()
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        transform.LookAt( targetPos );
    }
}
