using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class FleeAT : ActionTask {

		public Blackboard agentBlackBoard;

		public Transform deer;
        public BBParameter<Transform> target;
		public float Speed = 3;
        public Vector3 direction;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			agentBlackBoard = agent.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			Transform subdeer = agentBlackBoard.GetVariableValue<Transform>("Deertransform");
			if(subdeer == null)
			{
				Debug.Log("Deer is null");
            }


                Transform subrab = agentBlackBoard.GetVariableValue<Transform>("Rabbit");

			 direction =(subdeer.position - subrab.position).normalized;
			subdeer.position += direction * Time.deltaTime * Speed;
			//Vector3 testttt = new Vector3(3, 3, 3);
			//subdeer.position += testttt;
            agentBlackBoard.SetVariableValue("Deertransform", subdeer);


            if (Vector2.Distance(subdeer.position,subrab.position)>8)
			{
				Debug.Log("Hid");
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