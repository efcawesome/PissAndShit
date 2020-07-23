using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons
{
	public class EggBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("eggcelent");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;           
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = ItemRarityID.Green;
			item.shoot = ProjectileType<Projectiles.EggBullet>(); //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                 
			item.ammo = AmmoID.Bullet;              
		}

	
		

		
	}
}
