using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [Header("References")]
    public Transform cameraTarget;

    [Header("Collision Settings")]
    public float cameraRadius = 0.15f;
    public float smoothSpeed = 10f;

    [Header("Collision Layers")]
    public LayerMask collisionLayers;

    private Vector3 originalLocalPosition;

    void Start()
    {
        originalLocalPosition = transform.localPosition;

        if (cameraTarget == null)
        {
            cameraTarget = transform.parent;
        }
    }



    void LateUpdate()
    {
        Vector3 targetWorldPosition =
            cameraTarget.TransformPoint(originalLocalPosition);

        Vector3 direction =
            targetWorldPosition - cameraTarget.position;

        float distance = direction.magnitude;

        if (distance <= 0.01f)
            return;

        direction.Normalize();

        Vector3 finalWorldPosition = targetWorldPosition;

        if (Physics.SphereCast(
            cameraTarget.position,
            cameraRadius,
            direction,
            out RaycastHit hit,
            distance,
            collisionLayers,
            QueryTriggerInteraction.Ignore))
        {
            finalWorldPosition =
                hit.point + hit.normal * cameraRadius;
        }

        transform.position = Vector3.Lerp(
            transform.position,
            finalWorldPosition,
            Time.deltaTime * smoothSpeed
        );
    }
}