using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DrinkAT : ActionTask {

        public Blackboard agentBlackBoard;

        public float DrinkRate = 1f;

        public BBParameter<float> water;
        protected override string OnInit() {
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
            if (water.value <= 100)
            {
                water.value += DrinkRate * Time.deltaTime;
            }
            else
            {
                water.value = 100;
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