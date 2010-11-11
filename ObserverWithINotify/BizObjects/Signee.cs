using System;
using System.ComponentModel;

namespace ObserverWithINotify.BizObjects
{
	public class Signee
	{		
		public decimal? CurrentDues { get; set; }

		public void WatchContract(object sender, PropertyChangedEventArgs args)
		{
			switch (args.PropertyName)
			{
				case "InitialPricingPlan":
					CurrentDues = (sender as Contract).InitialPricingPlan.Dues;
					break;
				default:
					if ((sender as Contract).InitialPricingPlan != null)
					{
						CurrentDues = (sender as Contract).InitialPricingPlan.Dues;
					}
					break;
			}
		}
	}
}
