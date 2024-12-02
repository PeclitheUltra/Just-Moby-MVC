using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Content.Common
{
    [CreateAssetMenu(menuName = "Configs/Sprite Database")]
    public class SpriteDatabase : ScriptableObject, INamedProvider<Sprite>
    {
        [SerializeField] private List<Sprite> _sprites;
        
        [CanBeNull]
        public Sprite Get(string spriteName)
        {
            var output = _sprites.FirstOrDefault(x => x.name == spriteName);
            return output;
        }
    }
}
