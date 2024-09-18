using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExtendRope : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform ropePoint;
    private float lineWidth = 0.2f;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.enabled = false;
    }
    void Start()
    {
        
    }

    public void RenderLine(Vector3 maxPosition, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        }

        else
        {
            lineRenderer.positionCount = 0;

            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }

        }

        if (lineRenderer.enabled)
        {
            Vector3 temp = ropePoint.position;
            temp.z = -10f;

            ropePoint.position = temp;

            temp = maxPosition;
            temp.z = 0f;

            maxPosition = temp;

            lineRenderer.SetPosition(0, ropePoint.position);
            lineRenderer.SetPosition(1, maxPosition);
        }
    }


}
