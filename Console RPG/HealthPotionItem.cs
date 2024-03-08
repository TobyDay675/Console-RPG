namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public int healAmount;

        public static HealthPotionItem smallHealthPotion = new  HealthPotionItem("Small Health Potion", "A small vile of red liquid... I dont think it is blood", shopPrice: 25, sellPrice: 10, maxAmount: 32, healAmount: 25);
        public static HealthPotionItem regularHealthPotion = new HealthPotionItem("Regular Health Potion", "Has the faint taste of strawberries", shopPrice: 45, sellPrice: 20, maxAmount: 32, healAmount: 50);
        public static HealthPotionItem largeHealthPotion = new HealthPotionItem("Large Health Potion", "Gorge yourself on this shining red delicacy", shopPrice: 65, sellPrice: 30, maxAmount: 32, healAmount: 100);
        public static HealthPotionItem masterHealthPotion = new HealthPotionItem("Master Health Potion", "The drink of gods", shopPrice: 100, sellPrice: 50, maxAmount: 32, healAmount: 1000);
        public HealthPotionItem(string name, string description, int shopPrice, int sellPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }
        public override void Use(Entity user, Entity target)
        {
            if (this.healAmount < user.stats.maxHP)
            {
                user.currentHP += this.healAmount;
            }
            else if (this.healAmount > target.stats.maxHP) 
            {
                user.currentHP = user.stats.maxHP;
            }
        }
    }
}