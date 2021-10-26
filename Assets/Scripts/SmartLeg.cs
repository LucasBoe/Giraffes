using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartLeg : MonoBehaviour
{
    [SerializeField] float maxDistance = 1f;
    [SerializeField] Vector3 offset;

    Transform parent;

    void Start()
    {
        parent = transform.parent;
        transform.parent = null;

        StartCoroutine(LegRoutine());
    }

    private IEnumerator LegRoutine()
    {
        bool moving = false;
        Vector3 movingTarget = Vector3.zero;

        while (true)
        {
            Vector3 parentWithOffset = parent.position + offset;

            if (moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, movingTarget, Time.deltaTime * 10);
                if (Vector3.Distance(transform.position, movingTarget) < 0.0001f)
                {
                    moving = false;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, parentWithOffset) > maxDistance)
                {
                    moving = true;
                    movingTarget = transform.position + ((parentWithOffset - transform.position) * 1.75f);
                }
            }

            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.parent.position + offset, maxDistance / 2f);
    }
}
