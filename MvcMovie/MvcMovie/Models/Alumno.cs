using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
	public class Alumno
	{

		public int ID { get; set; }

		[Required(ErrorMessage = "Please enter first name")]
		[StringLength(20)]
		[DisplayName("First Name")]
		public string firstName { get; set; }

		[Required(ErrorMessage = "Please enter last name")]
		[StringLength(20)]
		public string lastName { get; set; }

		public DateTime birthDate { get; set; }
	}
}
