using Content.InAppAdvertisement;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Content.DI
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private MenuView _menuView;
        [SerializeField] private InAppAdvertisementView _inAppAdvertisementView;
        [SerializeField] private InAppAdvertisementController _inAppAdvertisementController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_menuView, Lifetime.Scoped);
            builder.RegisterComponentInNewPrefab(_inAppAdvertisementView, Lifetime.Scoped);
            
            builder.RegisterComponent(_inAppAdvertisementController);
            builder.Register<InAppAdvertisementModel>(Lifetime.Scoped);
        }
    }
}
