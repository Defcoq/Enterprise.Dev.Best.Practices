using EA.SOA.EventTicket.ServiceProxy;
using EA.SOA.EventTicket.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EA.SOA.EventTicket.WEBUI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnReserveTickets_Click(object sender, EventArgs e)
        {
            Basket.Clear();

            TicketServiceFacade ticketService = new TicketServiceFacade(new TicketServiceClientProxy());
            TicketReservationPresentation reservation = ticketService.ReserveTicketsFor(ddlEvents.SelectedValue, int.Parse(this.txtNoOfTickets.Text));

            if (reservation.TicketWasSuccessfullyReserved)
            {
                Basket.GetBasket().Reservation = reservation;
                Response.Redirect("Checkout.aspx");
            }

            Response.Write("Your tickets were unable to be reserved.<br/>" + reservation.Description);
        }
    }
}