// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

#if VRTK_VERSION_3_2_0_OR_NEWER

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("VRTKController")]
	[Tooltip("Get pointer pressed event for VRTK.")]

	public class  GetPointerPressed : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK_Pointer))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This will be true if the button aliased to the pointer is held down.")]
		public FsmBool pointerPressed;

		public FsmBool everyFrame;

		VRTK_Pointer theScript;

		public override void Reset()
		{

			pointerPressed = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			theScript = go.GetComponent<VRTK_Pointer>();

			MakeItSo();

			if (!everyFrame.Value)
			{
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

			pointerPressed.Value = theScript.IsActivationButtonPressed();
		}

	}
}

#else

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("VRTKController")]
[Tooltip("Get pointer pressed event for VRTK.")]

public class  GetPointerPressed : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
public FsmOwnerDefault gameObject;

[Tooltip("This will be true if the button aliased to the pointer is held down.")]
public FsmBool pointerPressed;

public FsmBool everyFrame;

VRTK.VRTK_ControllerEvents theScript;

public override void Reset()
{

pointerPressed = false;
gameObject = null;
everyFrame = false;
}

public override void OnEnter()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);

theScript = go.GetComponent<VRTK.VRTK_ControllerEvents>();

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

pointerPressed.Value = theScript.pointerPressed;

}

}
}

#endif