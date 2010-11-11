using System;
using NUnit.Framework;
using ObserverWithINotify.BizObjects;

namespace ObserverWithINotify.Tests
{
	public class ContractTests
	{
		[Test]
		public void ValidPricingInfoTransferredToSigneesAfterOneIsAddedTest()
		{
			Contract c = new Contract
			{
				InitialPricingPlan = new PricingPlan
				{
					Dues = 42M
				}
			};

			Signee s = new Signee();
			c.AddSignee(s);

			Assert.That(s.CurrentDues, Is.EqualTo(42M));
		}

		[Test]
		public void SigneeGetsPricingInfoWhenItChangesTest()
		{
			Contract c = new Contract();
			Signee s = new Signee();
			c.AddSignee(s);

			c.InitialPricingPlan = new PricingPlan { Dues = 42M };

			Assert.That(s.CurrentDues, Is.EqualTo(42));
		}
	}
}
