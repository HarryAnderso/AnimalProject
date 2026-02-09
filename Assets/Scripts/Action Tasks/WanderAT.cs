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

            agentBlackBoard = agent.GetComponent<Blackboard>();

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//Vector3 curpos = agent.transform.position;
			//float f = agentBlackBoard.GetValue<float>("wanderRadius");
            targ = new Vector3(Random.Range(agent.transform.position.x-wanderRadius, agent.transform.position.x + wanderRadius), 0, Random.Range(agent.transform.position.y - wanderRadius, agent.transform.position.y + wanderRadius));




            //EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

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