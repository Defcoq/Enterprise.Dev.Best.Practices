﻿using EA.SOA.EventTicket.ServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.SOA.EventTicket.WEBUI.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public TicketReservationPresentation Reservation { get; set; }

        public static Basket GetBasket()
        {
            if (HttpContext.Current.Session["Basket"] == null)
                HttpContext.Current.Session["Basket"] = new Basket { Id = Guid.NewGuid() };

            return (Basket)HttpContext.Current.Session["Basket"];
        }

        public static void Clear()
        {
            HttpContext.Current.Session["Basket"] = null;
        }
    }
}