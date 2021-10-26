using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosForEachChild : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector2[] positions = GetPositionsFromChildrenRecursively(transform);
        for (int i = 1; i < positions.Length; i++)
        {
            Gizmos.DrawLine(positions[i - 1], positions[i]);
        }
    }

    private Vector2[] GetPositionsFromChildrenRecursively(Transform t)
    {
        List<Vector2> pos = new List<Vector2>();
        pos.Add(t.position);

        foreach (Transform child in t)
        {
            Vector2[] childPos = GetPositionsFromChildrenRecursively(child);
            foreach (Vector2 cp in childPos)
            {
                pos.Add(cp);
            }
        }

        return pos.ToArray();
    }
}
