using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07_twoodru8.Models
{
	public class Categories
	{
		[Key]
		[Required]
		public int CategoriesId { get; set; }
		public string CategoryName { get; set; }
	}
}
