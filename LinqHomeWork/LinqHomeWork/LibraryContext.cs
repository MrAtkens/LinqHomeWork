using LinqHomeWork.Models;
using System.Data.Entity;

namespace LinqHomeWork
{

	public class LibraryContext : DbContext
	{

		public LibraryContext()
			: base("name=LibraryContext")
		{
		}
		public DbSet<Book> Books { get; set; }


	}

}