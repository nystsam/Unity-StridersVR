//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1026
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using StridersVR.Domain;
using StridersVR.Modules.Menu.Data;

namespace StridersVR.Modules.Menu.Logic
{
	public class StateMenuTraining : IStateMenu
	{

		private ContextMenuCamera menuCamera;

		public StateMenuTraining (ContextMenuCamera menuCamera)
		{
			this.menuCamera = menuCamera;
		}

		public Boolean menuFeatures()
		{
			DbTraining _training;

			if (this.menuCamera.TrainingList == null) 
			{
				_training = new DbTraining();
				this.menuCamera.TrainingList = _training.getTrainingList ();
				this.menuCamera.setTraining(this.menuCamera.TrainingList[0]);
			}
			return true;
		}
	}
}
