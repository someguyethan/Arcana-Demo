using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    LineRenderer lr;
    Vector3 grapplePoint;
    public Transform castPoint;
    public Transform cam;
    public Transform player;
    public LayerMask whatCanGrapple;
    public float range = 100f;
    SpringJoint joint;
    public float minGrappleDist = 0.25f;
    public float maxGrappleDist = 0.8f;
    public float spring = 4.5f;
    public float damper = 7f;
    public float massScale = 4.5f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            StartGrapple();
        else if (Input.GetMouseButtonUp(1))
            StopGrapple();
    }
    private void LateUpdate()
    {
        DrawGrapple();
    }
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, range, whatCanGrapple))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distFromPoint * maxGrappleDist;
            joint.minDistance = distFromPoint * minGrappleDist;

            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lr.positionCount = 2;
            
        }
    }
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawGrapple()
    {
        if (!joint)
            return;
        lr.SetPosition(0, castPoint.position);
        lr.SetPosition(1, grapplePoint);
    }
}
