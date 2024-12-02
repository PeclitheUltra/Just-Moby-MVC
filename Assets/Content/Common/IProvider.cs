namespace Content.Common
{
    internal interface IProvider<T>
    {
        public T Get();
    }
}