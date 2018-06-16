﻿namespace Finance.Domain.Accounts
{
    using Finance.Domain.ValueObjects;
    using System;

    public class Credit : IEntity, ITransaction
    {
        public Guid Id { get; }
        public Guid AccountId { get; }
        public Amount Amount { get; }
        public string Description
        {
            get { return "Credit"; }
        }

        public Credit(Guid id, Guid accountId, Amount amount)
        {
            Id = id;
            AccountId = accountId;
            Amount = amount;
        }

        public Credit(Guid accountId, Amount amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
        }
    }
}
