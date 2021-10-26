using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Vector3[] PositionFromTransform(Transform[] transforms)
    {
        List<Vector3> positions = new List<Vector3>();

        foreach (Transform t in transforms)
        {
            positions.Add(t.position);
        }

        return positions.ToArray();
    }

    public static Vector3[] PointSmooth(Transform[] input)
    {
        return PointSmooth(PositionFromTransform(input));
    }
    public static Vector3[] PointSmooth(Vector3[] input)
    {
        List<Vector3> output = new List<Vector3>();

        output.Add(input[0]);

        for (int i = 0; i < input.Length - 1; i++)
        {
            float lerp = 0.8f - 0.6f * ((float)i / input.Length);
            output.Add(Vector3.Lerp(input[i], input[i + 1], lerp));
        }

        output.Add(input[input.Length - 1]);

        return output.ToArray();
    }
}
