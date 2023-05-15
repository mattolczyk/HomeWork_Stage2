namespace WinFormsApp1;
using InventoryManagement;
using InventoryManagement.EntityFramework;
using InventoryManagement.Migrations;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;

//Initialconfig - command used in powershell
//  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//  dotnet add package Microsoft.EntityFrameworkCore.Tools
//  initial migration
//  dotnet ef migrations add InitialMigration
//  database migrate
//  dotnet ef database update
//  dotnet ef database update 0
//  dotnet ef migrations remove
//  dotnet ef migrations add InitialMigration


{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}