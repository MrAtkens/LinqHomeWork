using LinqHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomeWork
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new LibraryContext())
			{

				context.Books.Add(new Book
				{
					Name="1001 способ приготовить банан",
					AuthorName="Seamus Cowden",
					Price=1001
				});

				context.Books.Add(new Book
				{
					Name = "Правильный Андед",
					AuthorName = "Tina Lin Tsang",
					Price = 1203
				});

				context.Books.Add(new Book
				{
					Name = "Moonlighter для чайников",
					AuthorName = "Pawel Feldman",
					Price = 9999
				});

				context.Books.Add(new Book
				{
					Name = "Разлом",
					AuthorName = "Румур",
					Price = 1321
				});

				context.SaveChanges();

				Console.WriteLine("1. Вывести всех");
				Console.WriteLine("2. Поиск по Id");
				Console.WriteLine("3. Поиск по названию книги");
				Console.WriteLine("4. Поиск по имени автора");

				int choise = 0;

				bool correct=int.TryParse(Console.ReadLine(), out choise);

				if (correct == true)
				{
					if (choise == 1)
					{
						var result = context.Books.ToList();

						foreach (var i in result)
						{
							Console.WriteLine("Id: "+i.Id);
							Console.WriteLine("Название книги:" + i.Name);
							Console.WriteLine("Имя автора:" + i.AuthorName);
							Console.WriteLine("Цена:" + i.Price);
						}
					}
					else if (choise == 2)
					{
						int idConsole;
						Console.WriteLine("Введите id книги: ");
						bool answer = int.TryParse(Console.ReadLine(), out idConsole);

						var result = context.Books.Where(book => book.Id== idConsole).ToList();
						foreach (var i in result)
						{
							Console.WriteLine("Id: " + i.Id);
							Console.WriteLine("Название книги:" + i.Name);
							Console.WriteLine("Имя автора:" + i.AuthorName);
							Console.WriteLine("Цена:" + i.Price);
						}
					}
					else if (choise == 3)
					{
						string bufferName;
						Console.WriteLine("Введите название книги: ");
						bufferName = Console.ReadLine();

						var result = context.Books.Where(book => book.Name == bufferName).ToList();
						foreach (var i in result)
						{
							Console.WriteLine("Id: " + i.Id);
							Console.WriteLine("Название книги:" + i.Name);
							Console.WriteLine("Имя автора:" + i.AuthorName);
							Console.WriteLine("Цена:" + i.Price);
						}
					}
					else if (choise == 4)
					{
						string bufferAuthorName;
						Console.WriteLine("Введите имя автора: ");
						bufferAuthorName = Console.ReadLine();

						var result = context.Books.Where(book => book.AuthorName == bufferAuthorName).ToList();
						foreach (var i in result)
						{
							Console.WriteLine("Id: " + i.Id);
							Console.WriteLine("Название книги:" + i.Name);
							Console.WriteLine("Имя автора:" + i.AuthorName);
							Console.WriteLine("Цена:" + i.Price);
						}
					}

					else
					{
						Console.WriteLine("Вводите коректные данные");
						Environment.Exit(0);

					}
				}
				else {
					Console.WriteLine("Вводите коректные данные");
					Environment.Exit(0);

				}
			}
			Console.Read();
		}
	}
}
