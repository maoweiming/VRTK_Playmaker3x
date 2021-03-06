// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

#if VRTK_VERSION_3_2_0_OR_NEWER

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Get use pressed event for VRTK.")]

	public class  GetUsePressed : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK_InteractUse))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This will be true if the button aliased to the use is held down.")]
		public FsmBool usePressed;

		public FsmBool everyFrame;

		VRTK_InteractUse theScript;

		public override void Reset()
		{

			usePressed = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK_InteractUse>();

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

			usePressed.Value = theScript.IsUseButtonPressed ();

		}

	}
}

#else

namespace HutongGames.PlayMaker.Actions
{
[ActionCategory("VRTKController")]
[Tooltip("Get use pressed event for VRTK.")]

public class  GetUsePressed : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
public FsmOwnerDefault gameObject;

[Tooltip("This will be true if the button aliased to the use is held down.")]
public FsmBool usePressed;

public FsmBool everyFrame;

VRTK.VRTK_ControllerEvents theScript;

public override void Reset()
{

usePressed = false;
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

usePressed.Value = theScript.usePressed;

}

}
}

#endif