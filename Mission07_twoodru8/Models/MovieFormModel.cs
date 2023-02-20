using System.ComponentModel.DataAnnotations;

namespace Mission07_twoodru8.Models
{
	public class MovieFormModel
	{
		//This is the key for the database
		//All these are required and will throw an error to the view if not entered.
		[Key]
		[Required]
		public int MovieId { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		[Range(1900, 2023)]
		public int Year { get; set; }
		[Required]
		public string Director { get; set; }
		[Required]
		//foreign key
		public int CategoriesId { get; set; }
		public Categories Categories { get; set; }
		[Required]
		public string Rating { get; set; }
		public bool Edited { get; set; }
		public string LentTo { get; set; }
		//making sure that the notes are not any longer than 25 characters
		[StringLength(25)]
		public string Notes { get; set; }


	}
}
