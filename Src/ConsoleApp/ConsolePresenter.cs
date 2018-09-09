using System;
using UseCase.Users.Create;

namespace ConsoleApp
{
    public class ConsolePresenter : IUserCreatePresenter
    {
        public void Progress(int percentage) {
            Console.WriteLine(percentage + "%");
        }

        public void Complete(UserCreateResponse response) {
            Console.WriteLine("complete");
            Console.WriteLine("created id: " + response.UserId);
        }
    }
}
