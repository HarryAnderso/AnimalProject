using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class FindWaterAT : ActionTask {

		public Blackboard agentblackboard;
		public Transform pondlocation;

		private NavMeshAgent navmeshAgent;
		public Vector3 destination;

        protected override string OnInit() {
            navmeshAgent = agent.GetComponent<NavMeshAgent>();

            if (navmeshAgent == null)
                return $"{agent.name} - NavigationTask: Unable to get NavMesh Agent Reference!";
            else
                return null;
        }

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			destination = pondlocation.position;

            navmeshAgent.SetDestination(destination);

			if(Vector3.Distance(agent.transform.position, destination) < 2.5f)
			{
				EndAction(true);
            }


        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}