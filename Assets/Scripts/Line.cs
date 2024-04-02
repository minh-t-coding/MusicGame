using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;

    private readonly List<Vector2> points = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        edgeCollider.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector2 pos) {
        if(!CanAppend(pos)) return;
 
        points.Add(pos);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,pos);

        edgeCollider.points = points.ToArray();
    }

    private bool CanAppend(Vector2 pos) {
        if (lineRenderer.positionCount == 0) return true;
 
        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public int getPointsCount() {
        return points.Count;
    }
}
