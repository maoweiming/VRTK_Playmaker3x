// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Activates the VRTK Pointer by a Playmaker Action.")]

	public class  activatePointer : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_Pointer))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set this value to be true to enable the pointer. Set to false to disable the pointer")]
		public FsmBool enablePointer;

		public FsmBool everyFrame;

		VRTK.VRTK_Pointer theScript;

		public override void Reset()
		{

			enablePointer = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_Pointer>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.Toggle (enablePointer.Value);
				
		}

	}
}