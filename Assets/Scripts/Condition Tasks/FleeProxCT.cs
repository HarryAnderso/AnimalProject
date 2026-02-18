using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FleeProxCT : ConditionTask {

		public Transform rabbit;

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {

        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//return true;
			
			if (Vector2.Distance(rabbit.position, agent.transform.position) < 5)
			{
				Debug.Log("Too close!");
                return true;
			}
			else
			{
				return false;
			}

        }
	}
}