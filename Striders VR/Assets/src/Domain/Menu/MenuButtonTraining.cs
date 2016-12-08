using System;
using UnityEngine;

namespace StridersVR.Domain.Menu
{
	public class MenuButtonTraining : MenuButton
	{
		public MenuButtonTraining ()
		{
			this.menuContainer = GameObject.FindGameObjectWithTag("GameController");

			this.animName = "AnimTrainingMenu";
			this.animVariable = "IsTraining";
		}

		public override void buttonAction()
		{
			this.menuContainer.GetComponent<MenuContainerController> ().changeMenu (this.animName, this.animVariable, true);	
		}
	}
}
