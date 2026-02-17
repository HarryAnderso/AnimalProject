using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    public class WanderTask : ActionTask
    {
        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<bool> isMovingBBP;

        public float wanderDistance = 4f;
        public float wanderRadius = 3f;

        protected override void OnUpdate()
        {
            if (timeSinceLastSampleBBP.value == 0 && isMovingBBP.value == false)
            {
                Vector3 destination = CalculateTargetPosition();

                if (NavMesh.SamplePosition(destination, out NavMeshHit hitInfo, wanderDistance + wanderRadius, NavMesh.AllAreas))
                {
                    targetPositionBBP.value = hitInfo.position;
                }
            }
        }

        private Vector3 CalculateTargetPosition()
        {
            Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderDistance;
            Vector3 randomPoint = Random.insideUnitSphere.normalized * wanderRadius;

            Vector3 destination = circleCenter + randomPoint;

            DrawWanderGizmo(circleCenter, destination);

            return destination;
        }

        private void DrawWanderGizmo(Vector3 circleCenter, Vector3 destination)
        {
            Debug.DrawLine(agent.transform.position, circleCenter, Color.red, 0.5f);

            for (int i = 0; i < 360; i += 12)
            {
                Vector3 p1 = Quaternion.Euler(0, i, 0) * Vector3.right * wanderRadius;
                Vector3 p2 = Quaternion.Euler(0, i + 12, 0) * Vector3.right * wanderRadius;

                Debug.DrawLine(circleCenter + p1, circleCenter + p2, Color.white, 0.5f);
            }

            Debug.DrawLine(agent.transform.position, destination, new Color(0.4f, 0.2f, 0.7f), 0.5f);
        }
    }
}