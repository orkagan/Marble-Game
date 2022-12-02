using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public List<Transform> marbles;
    public Vector3 Offset;
    void Update()
    {
        Vector3 meanVector = Vector3.zero;
        for (int i = marbles.Count-1; i >= 0; i--)
        {
            Transform marble = marbles[i];
            if (marble != null)
            {
                meanVector += marble.position;
            }
            else
            {
                marbles.RemoveAt(i);
            }
        }

        Vector3 result = (meanVector / marbles.Count);
        transform.position = result + Offset;
    }
}
