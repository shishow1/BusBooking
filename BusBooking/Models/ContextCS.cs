using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BusTicketApplication.Models
{
	public class ContextCS : DbContext
	{
		public ContextCS() : base("cs")
		{

		}
		public DbSet<AdminLogic> AdminLogins { get; set; }					   // Tables creation
		public DbSet<UserAccount> UserLogins { get; set; }
		public DbSet<BusInfo> BusInfo { get; set; }
		public DbSet<VoyageBooking> VoyageBookings { get; set; }

	}
}