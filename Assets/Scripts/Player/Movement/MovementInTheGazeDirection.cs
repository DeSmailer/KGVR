using System.Collections.Generic;
using UnityEngine;

public class MovementInTheGazeDirection : MonoBehaviour
{
    [SerializeField] private Transform _rayStart;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private bool _isHit = false;

    [SerializeField] private RaycastHit _hit;

    [SerializeField] private Transform _sphere;



    void FixedUpdate()
    {
        _sphere.gameObject.SetActive(false);

        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(_rayStart.position, _rayStart.TransformDirection(Vector3.forward), out _hit, _distance, _mask))
            {
                Debug.DrawRay(_rayStart.position, _rayStart.TransformDirection(Vector3.forward) * _hit.distance, Color.yellow);


                UpdatePath();

                _isHit = true;
                ToggleDisplay(true);

                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(_rayStart.position, _rayStart.TransformDirection(Vector3.forward) * 1000, Color.white);


                _isHit = false;
                ToggleDisplay(false);

                Debug.Log("Did not Hit");
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (_isHit)
            {
                Teleport();
                ToggleDisplay(false);
            }
        }
    }

    private void Teleport()
    {
        transform.position = _hit.point + new Vector3(0, 1, 0);
    }

    public void ToggleDisplay(bool active)
    {
        //arcRenderer.enabled = active;
        _sphere.gameObject.SetActive(active);
    }

    //public float angle = 45f;
    //public float strength = 10f;
    //[SerializeField] private int maxVertexcount = 100;
    //[SerializeField] private float vertexDelta = 0.08f;
    //[SerializeField] private LineRenderer arcRenderer;
    //[SerializeField] private Vector3 velocity;
    //[SerializeField] private List<Vector3> vertexList = new List<Vector3>();

    //private void Awake()
    //{
    //    arcRenderer.enabled = false;
    //    _sphere.gameObject.SetActive(false);
    //}

    private void UpdatePath()
    {
        //vertexList.Clear();

        //arcRenderer.widthMultiplier = 0.2f;
        //arcRenderer.positionCount = maxVertexcount;

        //// A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
        //Gradient gradient = new Gradient();
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.green, 1.0f) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        //);
        //arcRenderer.colorGradient = gradient;

        //var t = Time.time;
        //for (int i = 0; i < maxVertexcount; i++)
        //{
        //    arcRenderer.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
        //}

        ////var t = Time.time;
        ////for (int i = 0; i < lengthOfLineRenderer; i++)
        ////{
        ////    lineRenderer.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
        ////}

        ////strength = Vector3.Distance(_rayStart.position, _hit.point);

        ////velocity = Quaternion.AngleAxis(-angle, transform.right) * transform.forward * strength;

        ////Vector3 pos = _rayStart.position;

        ////vertexList.Add(pos);

        ////while (vertexList.Count < maxVertexcount)
        ////{
        ////    Vector3 newPos = pos + (0.5f * vertexDelta * vertexDelta * Vector3.one);

        ////    vertexList.Add(newPos);

        ////    pos = newPos;
        ////}

        ////while (vertexList.Count < maxVertexcount)
        ////{
        ////    Vector3 newPos = pos + velocity * vertexDelta + 0.5f * Physics.gravity * vertexDelta * vertexDelta;

        ////    velocity += Physics.gravity * vertexDelta;

        ////    vertexList.Add(newPos);

        ////    pos = newPos;
        ////}

        _sphere.gameObject.SetActive(true);
        _sphere.position = _hit.point;

        //// Update Line Renderer

        //arcRenderer.positionCount = vertexList.Count;
        //arcRenderer.SetPositions(vertexList.ToArray());
    }
}