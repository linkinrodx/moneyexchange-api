﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Money_Exchange.API.Infraestructure.Context
{
    public partial class CurrencyValue
    {
        public int CurrencyValueId { get; set; }
        public int CurrencyId { get; set; }
        public decimal SaleValue { get; set; }
        public decimal PurchaseValue { get; set; }
        public bool Removed { get; set; }
        public DateTime StartDate { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifierUserId { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Currency Currency { get; set; }
    }
}