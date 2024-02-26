namespace Console_RPG
{
    class RangedWeapon : Weapon
    {
        public int ammo;
            public RangedWeapon(string name, string description, int shopPrice, int maxAmount, int damage, int ammo) : base(name, description, shopPrice, maxAmount, damage)
        {
            this.ammo = ammo; 
        }
        public override void Use(Entity user, Entity target)
        {
            if (ammo == 0)
                return;

            target.currentHP -= (this.damage + user.stats.strength) - target.stats.defense;
            --ammo;
        }
    }
}
