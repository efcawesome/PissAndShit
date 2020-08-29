using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Items.DaedalusDamage
{
    public abstract class DaedalusDamageItem : ModItem
    {
        public override bool CloneNewInstances => true;
        public virtual void SafeSetDefaults()
        {

        }
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
		}
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			add += DaedalusDamagePlayer.ModPlayer(player).daedalusDamageAdd;
			mult *= DaedalusDamagePlayer.ModPlayer(player).daedalusDamageMult;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback += DaedalusDamagePlayer.ModPlayer(player).daedalusKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit += DaedalusDamagePlayer.ModPlayer(player).daedalusCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " daedalus " + damageWord;
			}
		}
	}
}
