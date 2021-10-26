using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    [SerializeField] Transform toCopyFrom;
    [SerializeField] float multiplier = 1f;

    // Update is called once per frame
    void Update()
    {
        float baseAngle = toCopyFrom.localRotation.eulerAngles.z;
        float multipliedAngle = (baseAngle - ((baseAngle > 180f) ? 360f : 0f)) * multiplier;

        Debug.Log("base angle: " + baseAngle + " => " + multipliedAngle);

        transform.localRotation = Quaternion.Euler(0,0, multipliedAngle);
    }
}
