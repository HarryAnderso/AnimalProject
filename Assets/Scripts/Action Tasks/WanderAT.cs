using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		public Blackboard agentBlackBoard;
		

		//public BBParameter<float> wanderRadius = 5f;
		public float wanderRadius = 5f;
        public BBParameter<Transform> deer;
		public Vector3 targ;


        protected override string OnInit() {
            //gets the blackboard of the agent and stores it in a variable for later use
            agentBlackBoard = agent.GetComponent<Blackboard>();

            return null;
		}


		protected override void OnExecute() {
            //defines a random point for the deer to wander to within the defined radius once called for the first time
            targ = new Vector3(Random.Range(agent.transform.position.x-wanderRadius, agent.transform.position.x + wanderRadius), 0, Random.Range(agent.transform.position.y - wanderRadius, agent.transform.position.y + wanderRadius));
		}

		protected override void OnUpdate() {
            //each frame, the deer will move towards the defined point and once it is close enough, the action will end and return true
            Vector3 movedir = targ - agent.transform.position;
            agent.transform.position += movedir.normalized * Time.deltaTime * 3;

            if (Vector3.Distance(agent.transform.position, targ) < 0.5f)
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