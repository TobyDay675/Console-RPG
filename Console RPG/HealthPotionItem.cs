namespace Console_RPG
{
    class HealthPotionItem : Item
    {
        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }
        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
        }
    }
}
