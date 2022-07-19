using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public float gizmoRadius = 0.3F;
   void OnDrawGizmos()
    {
        Vector3 cubeDims = new Vector3(gizmoRadius, gizmoRadius, gizmoRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, cubeDims);
    }
}
