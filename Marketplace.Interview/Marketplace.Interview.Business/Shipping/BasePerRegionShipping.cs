﻿using System.Collections.Generic;
using System.Linq;
using Marketplace.Interview.Business.Basket;

namespace Marketplace.Interview.Business.Shipping
{
    public class BasePerRegionShipping : ShippingBase
    {
        public IEnumerable<RegionShippingCost> PerRegionCosts { get; set; }

        public override string GetDescription(LineItem lineItem, Basket.Basket basket)
        {
            return string.Format("Shipping to {0}", lineItem.DeliveryRegion);
        }

        public override decimal GetAmount(LineItem lineItem, Basket.Basket basket)
        {
            return
                (from c in PerRegionCosts
                 where c.DestinationRegion == lineItem.DeliveryRegion
                 select c.Amount).Single();
        }
    }
}