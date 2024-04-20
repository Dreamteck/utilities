namespace Bpositive.Utilities
{
    using UnityEngine;

    public class OverlapUtility : PhysicsAPIUtility
    {


        public OverlapUtility(LayerMask layerMask, int capacity = 100, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) : base(layerMask, capacity, queryTriggerInteraction)
        {
        }

        public void Sphere(Vector3 position, float radius)
        {
            _count = Physics.OverlapSphereNonAlloc(position, radius, _colliderBuffer, layerMask, queryTriggerInteraction);
        }

        public void Box(Vector3 center, Vector3 halfExtents, Quaternion orientation)
        {
            _count = Physics.OverlapBoxNonAlloc(center, halfExtents, _colliderBuffer, orientation, layerMask, queryTriggerInteraction);
        }

        public void Capsule(Vector3 point1, Vector3 point2, float radius)
        {
            _count = Physics.OverlapCapsuleNonAlloc(point1, point2, radius, _colliderBuffer, layerMask, queryTriggerInteraction);
        }
    }
}