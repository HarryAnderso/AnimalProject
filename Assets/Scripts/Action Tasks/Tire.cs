using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Tire : ActionTask {

        public Blackboard agentBlackBoard;

		public float TireRate = 1f;
		public float HungerRate = 1f;
		public float ThirstRate = 1f;

        public BBParameter<float> sleep;
        public BBParameter<float> food;
        public BBParameter<float> water;


        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

		}

		protected override void OnUpdate()
		{

			if (sleep.value > 10)
			{
				sleep.value -= TireRate * Time.deltaTime;
			}
			else
			{
				//EndAction(true);
			}

            if (food.value > 10)
            {
                food.value -= HungerRate * Time.deltaTime;
            }
            else
            {
                //EndAction(true);
            }

            if (water.value > 10)
            {
                water.value -= ThirstRate * Time.deltaTime;
            }
            else
            {
                //EndAction(true);
            }
            EndAction(true);
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}