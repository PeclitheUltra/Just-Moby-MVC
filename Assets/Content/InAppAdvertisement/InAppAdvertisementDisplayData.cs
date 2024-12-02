using Content.Items;
using UnityEngine;

namespace Content.InAppAdvertisement
{
    public class InAppAdvertisementDisplayData
    {
        public readonly string Label;
        public readonly string Description;
        public readonly ItemData[] Items;
        public readonly float Price;
        public readonly float DiscountPotion01;
        public readonly string BigIconName;

        public InAppAdvertisementDisplayData(int itemAmount)
        {
            Label = "Test";
            Description = "Kind of a long description to test some nuances displaying longer strings";
            Price = 999;
            DiscountPotion01 = .25f;
            BigIconName = "poison";
            Items = new ItemData[itemAmount];
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new ItemData("test item", Random.Range(1,10) * 10, "fire");
            }
        }

        public InAppAdvertisementDisplayData(string label, string description, float price, float discountPotion01, string bigIconName, ItemData[] items)
        {
            Label = label;
            Description = description;
            Price = price;
            DiscountPotion01 = discountPotion01;
            BigIconName = bigIconName;
            Items = items;
        }
    }
}