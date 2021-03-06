﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Money_Exchange.API.Infraestructure.Context
{
    public partial class Query
    {
        public int QueryId { get; set; }
        public string Guid { get; set; }
        public int? UserId { get; set; }
        public int StartCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal StartValue { get; set; }
        public decimal TargetValue { get; set; }
        public DateTime QueryDate { get; set; }
        public bool Removed { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifierUserId { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Currency StartCurrency { get; set; }
        public virtual Currency TargetCurrency { get; set; }
    }
}