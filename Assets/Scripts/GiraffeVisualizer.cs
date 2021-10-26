using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeVisualizer : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] PointGroup[] points;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        int i = 0;
        foreach (PointGroup group in points)
        {
            foreach (Transform transform in group.points)
            {
                i++;
            }
        }
        lineRenderer.positionCount = i;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        foreach (PointGroup group in points)
        {
            foreach (Transform transform in group.points)
            {
                lineRenderer.SetPosition(i, transform.position);
                i++;
            }
        }
    }
}

[System.Serializable]
public class PointGroup
{
    public Transform[] points;
}
