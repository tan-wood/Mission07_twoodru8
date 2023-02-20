using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission07_twoodru8.Models
{
	public class MovieFormDBContext : DbContext
	{

		//Constructor
		public MovieFormDBContext(DbContextOptions<MovieFormDBContext> options) : base(options)
		{
			//Leave blank for now
		}
		//Setting the title of the table
		public DbSet<MovieFormModel> Responses { get; set; }
		public DbSet<Categories> Categories { get; set; }



		protected override void OnModelCreating(ModelBuilder mb)
		{
			mb.Entity<Categories>().HasData(

				new Categories
				{
					CategoriesId = 1,
					CategoryName = "Action"
				},
				new Categories
				{
					CategoriesId = 2,
					CategoryName = "Comedy"
				},
				new Categories
				{
					CategoriesId = 3,
					CategoryName = "Romance"
				},
				new Categories
				{
					CategoriesId = 4,
					CategoryName = "Scary"
				}


				);
			//Seeding the data with my 3 favorite movies
			mb.Entity<MovieFormModel>().HasData(

				new MovieFormModel
				{
					MovieId = 100,
					Title = "Star Wars: Episode III",
					Year = 2005,
					Director = "George Lucas",
					CategoriesId = 1,
					Rating = "PG-13",

				},
				new MovieFormModel
				{
					MovieId = 101,
					Title = "Star Wars: Episode II",
					Year = 2002,
					Director = "George Lucas",
					CategoriesId = 1,
					Rating = "PG"
				},
				new MovieFormModel
				{
					MovieId = 102,
					Title = "Star Wars: Episode I",
					Year = 1999,
					Director = "George Lucas",
					CategoriesId = 1,
					Rating = "PG"
				}


				);


		}
	}
}
