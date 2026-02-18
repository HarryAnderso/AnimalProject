using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {
        public Blackboard agentBlackBoard;

        public float EatRate = 1f;
		public float Patchsize = 5;
		public float Foodpressure = 0f;

        public AudioSource audso;
        public BBParameter<AudioClip> EatSound;

        public BBParameter<float> food;
        protected override string OnInit() {
            audso = agent.GetComponent<AudioSource>();

            if (audso == null)
                return $"{agent.name} - Bleat Action Task: Unable to get a Audio Source";
            else
                return null;
        }

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            //EndAction(true);
            audso.PlayOneShot(EatSound.value);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (food.value <= 100 && Foodpressure<Patchsize)
            {
                food.value += EatRate * Time.deltaTime;
				Foodpressure += Time.deltaTime;
            }
			else if (Foodpressure >= Patchsize)
			{
				Foodpressure = 0;
				EndAction(true);
            }



            else
			{
				Foodpressure = 0;
				food.value = 100;
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