using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ObserverWithINotify.BizObjects
{
	public class Contract : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChangedEventArgs args =
					new PropertyChangedEventArgs(propertyName);
				PropertyChanged(this, args);
			}
		}

		private IList<Signee> _signees;

		public Contract()
		{
			_signees = new List<Signee>();
		}

		public void AddSignee(Signee s)
		{
			_signees.Add(s);
			
			PropertyChanged += s.WatchContract;

			s.WatchContract(this, new PropertyChangedEventArgs(""));
		}

		private PricingPlan _initialPricingPlan;
		public PricingPlan InitialPricingPlan { 
			get
			{
				return _initialPricingPlan;
			}
			set
			{
				_initialPricingPlan = value;
				OnPropertyChanged("PricingPlan");
			}
		}
	}
}
