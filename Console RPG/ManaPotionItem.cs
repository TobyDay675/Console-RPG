namespace Console_RPG
{
    class ManaPotionItem : Item
    {
        public int manaAmount;

        public ManaPotionItem(string name, string description, int shopPrice, int maxAmount, int manaAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.manaAmount = manaAmount;
        }
        public override void Use(Entity user, Entity target)
        {
            user.currentMana += this.manaAmount;
        }
    }
}
