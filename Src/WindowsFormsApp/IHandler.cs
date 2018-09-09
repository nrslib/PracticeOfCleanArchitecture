namespace WindowsFormsApp {
    public interface IHandler<T> {
        void Handle(T model);
    }
}
