using System;
using ClArc.Sync;
using UseCase.Users.Create;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Run();
            var bus = ServiceProvider.GetService<UseCaseBus>();

            Console.WriteLine("Welcome to practice of clean architecture.");
            prompt:
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("[C]reate user");
            Console.WriteLine("[Q]uit");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("type command(C/Q)");
            Console.Write("> ");
            var rawInput = Console.ReadLine();
            var input = rawInput.ToLower();
            switch (input) {
                case "c":
                    Console.WriteLine("type username");
                    Console.Write("> ");
                    var username = Console.ReadLine();
                    var request = new UserCreateRequest(username);
                    bus.Handle(request);
                    goto prompt;
                case "q":
                    break;
                default:
                    Console.WriteLine("not command");
                    goto prompt;
            }

        }
    }
}
