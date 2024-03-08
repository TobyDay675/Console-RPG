using System.Data;

namespace Console_RPG
{
    class MeleeWeapon : Weapon
    {
        public static MeleeWeapon dagger = new MeleeWeapon("Dagger", "Stabby stabby", shopPrice: 10, sellPrice: 5, 1, 25);
        public static MeleeWeapon theSword = new MeleeWeapon("The Sword", "You haven't heard about The Sword?", shopPrice: 100, sellPrice: 50, maxAmount: 1, damage: 100);
        public static MeleeWeapon bubblePopper = new MeleeWeapon("Bubble Popper", "Quickly pop dem bubbles", shopPrice: 600, sellPrice: 300, maxAmount: 1, damage: 200);
        public static MeleeWeapon shovel = new MeleeWeapon("Shovel", "We do be digging", shopPrice: 250, sellPrice: 125, maxAmount: 1, damage: 150);
        public static MeleeWeapon pickaxe = new MeleeWeapon("Pickaxe", "Not to be confused with the sentient pick", shopPrice: 1000, sellPrice: 500, maxAmount: 1, damage: 500);
        

        public MeleeWeapon(string name, string description, int shopPrice, int sellPrice, int maxAmount, int damage) : base(name, description, shopPrice, sellPrice, maxAmount, damage)
        { }
        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= (this.damage + user.stats.strength) - target.stats.defense;
        }
    }
}
