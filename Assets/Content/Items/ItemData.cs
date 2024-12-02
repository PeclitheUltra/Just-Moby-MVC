namespace Content.Items
{
    public class ItemData
    {
        public readonly string Name;
        public readonly int Amount;
        public readonly string ItemIconName;

        public ItemData(string name, int amount, string iconName)
        {
            Name = name;
            Amount = amount;
            ItemIconName = iconName;
        }
    }
}