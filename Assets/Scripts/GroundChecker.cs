using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform _circleCheckPosition;
    [SerializeField] private float _radius;

    public bool IsOverGround => Physics2D.OverlapCircle(CirclePosition, _radius, groundMask);

    private Vector3 CirclePosition => _circleCheckPosition.position;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(CirclePosition, _radius);
    }
}