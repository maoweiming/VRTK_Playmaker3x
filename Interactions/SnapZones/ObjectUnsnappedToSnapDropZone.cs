// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Get Game Object unsnapped Successfull the SnapZone.")]
	
	public class  ObjectUnsnappedToSnapDropZone : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SnapDropZone))]    
		public FsmOwnerDefault gameObject;
		
		[TitleAttribute("Unsnapped Game Object")]
		public FsmGameObject snapZoneObject;
		
		private	VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents snapEvents;
		
		public override void Reset()
		{
			
			gameObject = null;
			snapZoneObject = null;
		}
		
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			snapEvents = go.GetComponent<VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents>();
			if (snapEvents == null)
			{
				snapEvents = go.AddComponent<VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents>();
			}
			
			snapEvents.OnObjectUnsnappedFromDropZone.AddListener(ObjectSnapped);
			
		}
		
		private void ObjectSnapped(object sender, SnapDropZoneEventArgs e)
		{
			snapZoneObject.Value = e.snappedObject;
			
		}
		
	}
	
}
