using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
public class HandRayInteractor : MonoBehaviour
{
    public OVRHand hand;
    private LineRenderer lineRenderer;
    public float rayLength = 10f;
    public LayerMask uiLayer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (hand.IsTracked)
        {
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayLength, uiLayer))
            {
                lineRenderer.SetPosition(0, rayOrigin);
                lineRenderer.SetPosition(1, hit.point);

                // Check for pinch gesture
                if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    ExecuteEvents.Execute(hit.collider.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
            else
            {
                // Extend the ray if nothing is hit
                lineRenderer.SetPosition(0, rayOrigin);
                lineRenderer.SetPosition(1, rayOrigin + rayDirection * rayLength);
            }
        }
    }
}
