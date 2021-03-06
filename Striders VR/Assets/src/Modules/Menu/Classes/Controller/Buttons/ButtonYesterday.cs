using UnityEngine;
using System;

namespace StridersVR.Buttons
{
	public class ButtonYesterday : StatisticsPanelButton
	{
		protected override void PanelAction ()
		{
			if(!this.isSelected)
			{
				MenuStatisticsController.Current.NewButtonActive(this);
				MenuStatisticsController.Current.GetYesterdayPlays();
			}
		}
		
		#region Script
		void Start()
		{
			this.SetValues();
		}
		#endregion
	}
}

