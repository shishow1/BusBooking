using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusTicketApplication.Models
{
	[Table("TblAdminLogic")]			 

	public class AdminLogic
	{
		[Key]																		   // Admin account entity
		public int AdminId { get; set; }
		[Required(ErrorMessage = "User name required")]
		[Display(Name = "User Name")]
		[MinLength(3, ErrorMessage = "Minimum name size is 3 symbols"), MaxLength(10, ErrorMessage = "10 symbols allowed")]
		public string AdName { get; set; }

		[Required(ErrorMessage = "Password required")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[MinLength(5, ErrorMessage = "Minimum password size is 5 symbols"), MaxLength(10, ErrorMessage = "10 symbols allowed")]
		public string Password { get; set; }
	}

	[Table("TblUserAccount")]                            
	public class UserAccount										   // User account entity
	{
		[Key]
		public int UserId { get; set; }

		[Display(Name = "First name")]
		[Required(ErrorMessage = "First name required")]
		[MinLength(5, ErrorMessage = "Minimum size is 5 symbols"), MaxLength(20, ErrorMessage = "20 symbols allowed")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		[Required(ErrorMessage = "Email required")]
		[MinLength(5, ErrorMessage = "Minimum size is 5 symbols"), MaxLength(20, ErrorMessage = "20 symbols allowed")]
		public string LastName { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "First name required")]
		[MinLength(5, ErrorMessage = "Minimum size is 5 symbols"), MaxLength(20, ErrorMessage = "20 symbols allowed")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password required")]
		[MinLength(5, ErrorMessage = "Minimum size is 5 symbols"), MaxLength(20, ErrorMessage = "20 symbols allowed")]
		public string Password { get; set; }

		[Display(Name = "Password confirmation")]							   // Password confirmation option
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords don't match")]
		[MinLength(5, ErrorMessage = "Minimum size is 5 symbols"), MaxLength(20, ErrorMessage = "20 symbols allowed")]
		public string CPassword { get; set; }

		public int Age { get; set; }

		[Display(Name = "Document number(series and number)")]
		[Required(ErrorMessage = "Document number required"), RegularExpression(@"^([A-Z]{2}[0-9]{7})?$")]	   // RegEx for Belarussian passport  
		[StringLength(9)]
		public string DocNumber { get; set; }
	}

	public class BusInfo										  // Bus entity
	{
		[Key]
		public int BusId { get; set; }

		[Display(Name = "Bus name")]
		[Required(ErrorMessage = "Bus name required")]
		[MinLength(5, ErrorMessage = "Minimum size is 5 symbols"), MaxLength(20, ErrorMessage = "20 symbols allowed")]
		public string BusName { get; set; }

		[Required(ErrorMessage = "Enter a capacity")]
		[Display(Name = "Amount of avialable seats ")]
		public int SeatsCapacity { get; set; }

		[Required(ErrorMessage = "Enter a price")]
		public float Price { get; set; }
	}

	[Table("TblVoyageBooking")]

	public class VoyageBooking										 //  Voyage entity. Actually allows users to find a trip. 
	{
		[Key]
		public int VoyageId { get; set; }

		[Required(ErrorMessage = "Enter a departure stop")]
		[Display(Name = "From:")]
		[StringLength(20, ErrorMessage = "20 symbols allowed")]
		public string From { get; set; }

		[Required(ErrorMessage = "Enter an arrival stop")]
		[Display(Name = "To:")]
		[StringLength(20, ErrorMessage = "20 symbols allowed")]
		public string To { get; set; }

		[Display(Name = "Departure time")]
		[StringLength(15)]
		public string Dtime { get; set; }
		public int BusId { get; set; }
		public virtual BusInfo BusInfo { get; set; }
	}

}
