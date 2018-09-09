namespace UseCase.Users.Create {
    public interface IUserCreatePresenter {
        void Progress(int percentage);
        void Complete(UserCreateResponse response);
    }
}
