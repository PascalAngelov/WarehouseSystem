using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.Models.Terminals.Areas.Stacks;
using WarehouseSystem.Models.Transport;

namespace WarehouseSystem.Models.Products.Pipes
{
    public class Pipe : Product, IPipe
    {
        private ITransport transportArrival;
        private ITransport transportDispatch;
        private IStack stack;
        public Pipe(int id, string manufacturer, decimal price, string dateOfArrival, string dateOfShipment, 
            ITransport transportArrival, ITransport transportDispatch, IStack stack)
            : base(id, manufacturer, price, dateOfArrival, dateOfShipment)
        {
            this.TransportArrival = transportArrival;
            this.TransportDispatch = transportDispatch;
            this.Stack = stack;
            this.Quarantined = false;
            this.CustomsClearance = false;
            this.Dispatched = false;
            this.Repaired = false;
        }
        public ITransport TransportArrival
        {
            get
            {
                return this.transportArrival;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTransport);
                }

                this.transportArrival = value;
            }
        }

        public ITransport TransportDispatch
        {
            get
            {
                return this.transportDispatch;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTransport);
                }

                this.transportDispatch = value;
            }
        }

        public IStack Stack
        {
            get
            {
                return this.stack;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidStack);
                }

                this.stack = value;
            }
        }

        public bool Quarantined { get; set; }

        public bool CustomsClearance { get; set; }

        public bool Dispatched { get; set; }

        public bool Repaired { get; set; }

        public void ChangeStatus(string quarantined, string customsClearance, string dispatched, string repaired)
        {
            if (quarantined == "Yes")
            {
                this.Quarantined = true;
            }
            if (customsClearance == "Yes")
            {
                this.CustomsClearance = true;
            }
            if (dispatched == "Yes")
            {
                this.Dispatched = true;
            }
            if (repaired == "Yes" && this.Quarantined == true)
            {
                this.Repaired = true;
                this.Quarantined = false;
            }
        }
    }
}
