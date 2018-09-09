using System.IO;
using UseCase.Users.Create;

namespace ConsoleApp
{
    public class FilePresenter : IUserCreatePresenter {
        private const string FileName = "FilePresenterOutput.txt";
        public FilePresenter() {
            if (!File.Exists(FileName)) {
                File.Create(FileName).Close();
            }
        }

        public void Progress(int percentage) {
            File.AppendAllLines(FileName, new []{ percentage + "%" });
        }

        public void Complete(UserCreateResponse response) {
            File.AppendAllLines(FileName, new[] {
                "complete",
                "id: " + response.UserId
            });
        }
    }
}
