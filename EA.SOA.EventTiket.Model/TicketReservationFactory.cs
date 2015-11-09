﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.SOA.EventTiket.Model
{
   public class TicketReservationFactory
    {
        public static TicketReservation CreateReservation(Event Event, int tktQty)
        {
            TicketReservation reservation = new TicketReservation();

            reservation.Id = Guid.NewGuid();
            reservation.Event = Event;
            reservation.ExpiryTime = DateTime.Now.AddMinutes(1);
            reservation.TicketQuantity = tktQty;

            return reservation;
        }
    }
}
