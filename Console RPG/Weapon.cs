namespace Console_RPG
{
    class Weapon : Item
    {
        public int damage;

        public Weapon(string name, string description, int shopPrice, int maxAmount, int damage) : base(name, description, shopPrice, maxAmount)
        {
            this.damage = damage;
        }
        public override void Use(Entity user, Entity target)
        { }
    }
}
