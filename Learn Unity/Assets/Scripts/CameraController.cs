using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float followDistance;
    public float smooth;

    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 targetPos = target.transform.position - Vector3.forward * followDistance + offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth);

        Quaternion targetRot = Quaternion.LookRotation((target.transform.position - transform.position).normalized, Vector3.up);

        Quaternion.Slerp(transform.rotation, targetRot, smooth);
    }


}
