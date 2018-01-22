//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XftWeapon;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("XWeaponTrail")]
	[Tooltip(" ")]
	public class XWT_Deactivate : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(XWeaponTrail))] 
		public FsmOwnerDefault gameObject;

		public FsmBool everyFrame;

		XWeaponTrail theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<XWeaponTrail>();


			if (!everyFrame.Value)
			{
				DoTheMethod();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMethod();
			}
		}

		void DoTheMethod()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.Deactivate();            
		}

	}
}