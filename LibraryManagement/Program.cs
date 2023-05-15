// See https://aka.ms/new-console-template for more information
//Initialconfig - command used in powershell
//  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//  dotnet add package Microsoft.EntityFrameworkCore.Tools
//  initial migration
//  dotnet ef migrations add InitialMigration
//  database migrate
//  dotnet ef database update 0



using LibraryManagement;
using LibraryManagement.EntityFramework;
using LibraryManagement.Migrations;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;

var menu = new Menu();
var booksRepository = new BooksRepository();
var booksValidator = new BooksValidator();

var borrowersRepository = new BorrowersRepository();
var borrowersValidator = new BorrowerValidator();

while (true)
{
    menu.Show();
    var selectedAction = Console.ReadLine();


    if (selectedAction == "1")
    {
        try
        {

            var borrowers = await borrowersRepository.GetAll();
            foreach (var borrower in borrowers)
            {
                //var isBookAvailable = book.Availability ? "Available" : "Borrowed";
                Console.WriteLine($"{borrower.Id} {borrower.Name} {borrower.Email} {borrower.Phone} {borrower.TotalBorrowedBooks}");
            }
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    if (selectedAction == "2")
    {
        Console.Clear();

        Console.WriteLine("Provide Name: ");
        var name = Console.ReadLine();
        if (!borrowersValidator.IsNameValid(name))
        {
            Console.WriteLine("Provided name is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Email: ");
        var email = Console.ReadLine();
        if (!borrowersValidator.IsEmailValid(email))
        {
            Console.WriteLine("Provided email is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Phone: ");
        var phone = Console.ReadLine();
        if (!borrowersValidator.IsPhoneValid(phone))
        {
            Console.WriteLine("Provided phone is invalid! Try again.");
            return;
        }

        var borrowerRecord = new Borrowers
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Phone = phone,
            TotalBorrowedBooks = 0
        };

        try
        {
            await borrowersRepository.Add(borrowerRecord);
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }


        Console.WriteLine("Borrower added!");
        Console.ReadLine();
    }

    if (selectedAction == "3")
    {
        Console.Clear();

        Console.WriteLine("Provide Borrower Id: ");
        var borrowerId = Console.ReadLine();
        if (!borrowersValidator.IsIdValid(borrowerId))
        {
            Console.WriteLine("Provided book id is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Name: ");
        var name = Console.ReadLine();
        if (!borrowersValidator.IsNameValid(name))
        {
            Console.WriteLine("Provided name is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Email: ");
        var email = Console.ReadLine();
        if (!borrowersValidator.IsEmailValid(email))
        {
            Console.WriteLine("Provided email is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Phone: ");
        var phone = Console.ReadLine();
        if (!borrowersValidator.IsPhoneValid(phone))
        {
            Console.WriteLine("Provided phone is invalid! Try again.");
            return;
        }

        var borrowerRecord = new Borrowers
        {
            Id = Guid.Parse(borrowerId),
            Name = name,
            Email = email,
            Phone = phone,
            TotalBorrowedBooks = 0
        };

        try
        {
            await borrowersRepository.Add(borrowerRecord);
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }


        Console.WriteLine("Borrower edited!");
        Console.ReadLine();
    }

    if (selectedAction == "4")
    {
        Console.Clear();

        Console.WriteLine("Provide BorrowerId: ");
        var borrowerId = Console.ReadLine();
        if (!borrowersValidator.IsIdValid(borrowerId))
        {
            Console.WriteLine("Provided borrower id is invalid! Try again.");
            return;
        }

        borrowersRepository.Remove(Guid.Parse(borrowerId));

        Console.WriteLine("Borrower removed!");
        Console.ReadLine();
    }

    if (selectedAction == "5")
    {

        Console.WriteLine("Please enter the NAME of the borrower you are looking for: ");
        string pattern = Console.ReadLine();

        Console.WriteLine("Borrower(s) containing searched word (" + pattern + ") in it's NAME:");
        var borrowers = await borrowersRepository.GetAll();
        foreach (var borrower in borrowers)
        {


            Match match = Regex.Match(borrower.Name.ToLower(), pattern.ToLower());
            if (match.Success)
            {
                Console.WriteLine("Name: " + borrower.Name+ " , Email: " + borrower.Email + " , ID: " + borrower.Id);
            }
        }
    }

    if (selectedAction == "6")
    {
        var books = await booksRepository.GetAll();
        foreach (var book in books)
        {
            var isBookAvailable = book.Availability ? "Available" : "Borrowed";
            Console.WriteLine($"{book.Id} {book.Title} {book.Author} {book.ISBN} {isBookAvailable}");
        }
    }

    if (selectedAction == "7")
    {
        Console.Clear();

        Console.WriteLine("Provide Title: ");
        var title = Console.ReadLine();
        if (!booksValidator.IsTitleValid(title))
        {
            Console.WriteLine("Provided title is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Author: ");
        var author = Console.ReadLine();
        if (!booksValidator.IsAuthorValid(author))
        {
            Console.WriteLine("Provided author is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide ISBN: ");
        var isbn = Console.ReadLine();
        if (!booksValidator.IsValidISBN(isbn))
        {
            Console.WriteLine("Provided isbn is invalid! Try again.");
            return;
        }

        var bookRecord = new Books
        {
            Id = Guid.NewGuid(),
            Author = author,
            Availability = true,
            ISBN = isbn,
            Title = title
        };

        booksRepository.Add(bookRecord);

        Console.WriteLine("Book added!");
        Console.ReadLine();
    }

    if (selectedAction == "8")
    {
        Console.Clear();

        Console.WriteLine("Provide BookId: ");
        var bookId = Console.ReadLine();
        if (!booksValidator.IsIdValid(bookId))
        {
            Console.WriteLine("Provided book id is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Title: ");
        var title = Console.ReadLine();
        if (!booksValidator.IsTitleValid(title))
        {
            Console.WriteLine("Provided title is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide Author: ");
        var author = Console.ReadLine();
        if (!booksValidator.IsAuthorValid(author))
        {
            Console.WriteLine("Provided author is invalid! Try again.");
            return;
        }

        Console.WriteLine("Provide ISBN: ");
        var isbn = Console.ReadLine();
        if (!booksValidator.IsValidISBN(isbn))
        {
            Console.WriteLine("Provided isbn is invalid! Try again.");
            return;
        }

        var bookRecord = new Books
        {
            Id = Guid.NewGuid(),
            Author = author,
            Availability = true,
            ISBN = isbn,
            Title = title
        };

        booksRepository.Edit(bookRecord);

        Console.WriteLine("Book edited!");
        Console.ReadLine();
    }

    if (selectedAction == "9")
    {
        Console.Clear();

        Console.WriteLine("Provide BookId: ");
        var bookId = Console.ReadLine();
        if (!booksValidator.IsIdValid(bookId))
        {
            Console.WriteLine("Provided book id is invalid! Try again.");
            return;
        }

        booksRepository.Remove(Guid.Parse(bookId));

        Console.WriteLine("Book removed!");
        Console.ReadLine();
    }

    if (selectedAction == "10")
    {
        Console.WriteLine("Please enter the TITLE of the book you are looking for: ");
        string pattern = Console.ReadLine();
        Console.WriteLine("Book(s) containing searched word (" + pattern + ") in it's title:");
        var books = await booksRepository.GetAll();
        foreach (var book in books)
        {
            Match match = Regex.Match(book.Title.ToLower(), pattern.ToLower());
            if (match.Success)
            {
                Console.WriteLine("Title: " + book.Title + " , Author: " + book.Author + " , ID: " + book.Id);
            }
        }
        //foreach (var book in books)
        //{
        //    if (search.Equals(book.Title))
        //    {
        //        Console.WriteLine(" found <" + search + "> in book: " + book.Title + ", " + book.Author);
        //    }
        //}
    }

    if (selectedAction == "11")
    {
        Environment.Exit(0);
    }

}