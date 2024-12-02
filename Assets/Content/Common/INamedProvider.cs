namespace Content.Common
{
    internal interface INamedProvider<T>
    {
        public T Get(string name);
    }
}