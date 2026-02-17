using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class BleatAT : ActionTask {

        public Blackboard agentBlackBoard;

        public AudioSource audso;
		public BBParameter<AudioClip> bleatSound;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			//return null;


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
			audso.PlayOneShot(bleatSound.value);
			Debug.Log("Bleated");
            EndAction(true);
			
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}