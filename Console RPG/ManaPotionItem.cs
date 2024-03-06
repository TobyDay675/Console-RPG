namespace Console_RPG
{
    class ManaPotionItem : Item
    {
        public int manaAmount;

        public static ManaPotionItem smallManaPotion = new ManaPotionItem("Small Mana Potion", "A small vil of blue liquid... hope its not dish detergent", shopPrice: 25, sellPrice: 10, maxAmount: 32, manaAmount: 25);
        public static ManaPotionItem regularManaPotion = new ManaPotionItem("Regular Mana Potion", "Has the faint taste of blueberries", shopPrice: 45, sellPrice: 20, maxAmount: 32, manaAmount: 50);
        public static ManaPotionItem largeManaPotion = new ManaPotionItem("Large Mana Potion", "Gorge yourself on this shining blue delicacy", shopPrice: 65, sellPrice: 30, maxAmount: 32, manaAmount: 100);
        public static ManaPotionItem masterManaPotion = new ManaPotionItem("Master Mana Potion", "The drink of great wizards", shopPrice: 100, sellPrice: 50, maxAmount: 32, manaAmount: 1000);
        public ManaPotionItem(string name, string description, int shopPrice, int sellPrice, int maxAmount, int manaAmount) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.manaAmount = manaAmount;
        }
        public override void Use(Entity user, Entity target)
        {
            user.currentMana += this.manaAmount;
        }
    }
}
