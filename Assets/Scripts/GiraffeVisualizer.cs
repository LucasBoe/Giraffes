using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeVisualizer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRendererPrefab;
    [SerializeField] PointGroup[] points;
    [SerializeField] Transform[] leg1, leg2;

    LineRenderer bodyOutlineRenderer, leg1Renderer, leg2Renderer;

    // Start is called before the first frame update
    void Start()
    {
        bodyOutlineRenderer = Instantiate(lineRendererPrefab, transform);

        leg1Renderer = Instantiate(lineRendererPrefab, transform);
        leg2Renderer = Instantiate(lineRendererPrefab, transform);

        int i = 0;
        foreach (PointGroup group in points)
        {
            foreach (Vector3 point in group.GetPoints())
            {
                i++;
            }
        }
        bodyOutlineRenderer.positionCount = i;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        foreach (PointGroup group in points)
        {
            foreach (Vector3 point in group.GetPoints())
            {
                bodyOutlineRenderer.SetPosition(i, point);
                i++;
            }
        }

        Vector3[] leg1Points = Util.PointSmooth(Util.PositionFromTransform(leg1));
        Vector3[] leg2Points = Util.PointSmooth(Util.PositionFromTransform(leg2));

        leg1Renderer.positionCount = leg1Points.Length;
        leg1Renderer.SetPositions(leg1Points);

        leg2Renderer.positionCount = leg2Points.Length;
        leg2Renderer.SetPositions(leg2Points);
    }
}

[System.Serializable]
public class PointGroup
{
    public bool lerp = false;
    public Transform[] points;
    public Vector3[] GetPoints()
    {
        if (lerp)
            return Util.PointSmooth(Util.PointSmooth(Util.PointSmooth(points)));
        else
            return Util.PositionFromTransform(points);
    }
}
