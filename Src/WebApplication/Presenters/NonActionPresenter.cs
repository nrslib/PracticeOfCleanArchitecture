using UseCase.Users.Create;

namespace WebApplication.Presenters
{
    public class NonActionPresenter : IUserCreatePresenter
    {
        public void Progress(int percentage)
        {
        }

        public void Complete(UserCreateResponse response)
        {
        }
    }
}
