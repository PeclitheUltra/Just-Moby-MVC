using Content.Common;
using Content.InAppAdvertisement;
using Content.Items;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Content.DI
{
    public class ProjectScope : LifetimeScope
    {
        [SerializeField] private SpriteDatabase _spriteDatabase;
        [SerializeField] private ItemView _itemViewPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_spriteDatabase).As(typeof(INamedProvider<Sprite>));
            builder.Register<DiProvider<ItemView>>(Lifetime.Scoped).As(typeof(IProvider<ItemView>));
            builder.RegisterComponentInNewPrefab<ItemView>(_itemViewPrefab, Lifetime.Transient);
        }
    }
}
