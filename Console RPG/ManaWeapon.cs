namespace Console_RPG
{
    class ManaWeapon : Weapon
    {
        public int manaUsed;
        public ManaWeapon(string name, string description, int shopPrice, int maxAmount, int damage, int manaUsed) : base(name, description, shopPrice, maxAmount, damage)
        {
            this.manaUsed = manaUsed;
        }
        public override void Use(Entity user, Entity target)
        {
            if (user.currentMana == 0)
                return;

            target.currentHP -= this.damage;
            user.currentMana -= manaUsed;
        }
    }
}
