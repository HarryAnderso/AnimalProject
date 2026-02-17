using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class FindFoodAT : ActionTask {


        public Blackboard agentblackboard;
        //public Transform pondlocation;

        private NavMeshAgent navmeshAgent;


        public float wanderRadius = 5f;
        public BBParameter<Transform> deer;
        public Vector3 targ;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
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
            targ = new Vector3(Random.Range(agent.transform.position.x - wanderRadius, agent.transform.position.x + wanderRadius), 0, Random.Range(agent.transform.position.y - wanderRadius, agent.transform.position.y + wanderRadius));
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
           

            navmeshAgent.SetDestination(targ);

            if (Vector3.Distance(agent.transform.position, targ) < 2.5f)
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