namespace Trading
{
    public interface IHandler<in T>
    {
        void Hanlde(T message);
    }
}