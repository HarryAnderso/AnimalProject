using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RestAT : ActionTask {

        public Blackboard agentBlackBoard;

        public float RestRate = 1f;

        public BBParameter<float> sleep;
        protected override string OnInit() {
			return null;
		}


		protected override void OnExecute() {

		}


		protected override void OnUpdate() {
			//if the deer is tired, this increases the sleep value until it's full, ending the task.
            if (sleep.value<=100)
            {
                sleep.value += RestRate * Time.deltaTime;
            }
            else
            {
				sleep.value = 100;
                EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}


		protected override void OnPause() {
			
		}
	}
}