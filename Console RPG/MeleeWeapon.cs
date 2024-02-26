namespace Console_RPG
{
    class MeleeWeapon : Weapon
    {
        public static MeleeWeapon placeHolderSword = new MeleeWeapon("Place Holder Sword", "Tessstinnng", 1000, 1, 10);

        public MeleeWeapon(string name, string description, int shopPrice, int maxAmount, int damage) : base(name, description, shopPrice, maxAmount, damage)
        { }
        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= (this.damage + user.stats.strength) - target.stats.defense;
        }
    }
}
