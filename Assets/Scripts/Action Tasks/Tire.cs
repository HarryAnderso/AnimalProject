using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Tire : ActionTask {

        public Blackboard agentBlackBoard;

		public float TireRate = 1f;

		public BBParameter<float> sleep;


        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

		}

		protected override void OnUpdate()
		{

			if (sleep.value > 50)
			{
				sleep.value -= TireRate * Time.deltaTime;
			}
			else
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