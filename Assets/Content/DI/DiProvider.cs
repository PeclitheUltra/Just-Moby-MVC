using Content.Common;
using Content.InAppAdvertisement;
using VContainer;

namespace Content.DI
{
    public class DiProvider<T> : IProvider<T>
    {
        private readonly IObjectResolver _resolver;

        public DiProvider(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public T Get()
        {
            return _resolver.Resolve<T>();
        }
    }
}