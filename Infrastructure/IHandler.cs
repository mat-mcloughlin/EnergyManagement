namespace Infrastructure
{
    public interface IHandler<in T>
    {
        void Handle(T message);
    }
}