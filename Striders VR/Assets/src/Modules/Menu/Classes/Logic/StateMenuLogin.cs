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
using System.Text.RegularExpressions;
using StridersVR.Modules.Menu.Data;

namespace StridersVR.Modules.Menu.Logic
{
	public class StateMenuLogin : IStateMenu
	{

		//private ContextMenuCamera menuCamera;

		public StateMenuLogin (ContextMenuCamera menuCamera)
		{
			//this.menuCamera = menuCamera;
		}

		public Boolean menuFeatures()
		{
			/*
			DbUserLogin _userLogin;
			if(Regex.IsMatch(this.menuCamera.ActualUser, @"^[a-zA-Z0-9_-]{3,15}$"))
			{
				_userLogin = new DbUserLogin(this.menuCamera.ActualUser);
				if(_userLogin.login())
				{
					// Posible logica adicional
					return true;
				}
			}
			*/
			return false;
		}

	}
}

