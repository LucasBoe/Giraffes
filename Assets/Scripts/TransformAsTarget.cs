using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAsTarget : MonoBehaviour
{
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TargetJoint2D>().target = target.position;
    }
}
