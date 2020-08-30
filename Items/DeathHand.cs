using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PissAndShit.Items
{
    public class DeathHand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death's Hand");
            Tooltip.SetDefault("'Everything is under your control'\nClick an enemy to get info and control aspects of it");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = -1;
            item.width = 180;
            item.height = 180;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 0;
            item.value = Item.buyPrice(6, 24, 11, 2);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool UseItem(Player player)
        {
            var location = Main.MouseWorld.ToPoint();
            bool mouseover = false;
            if (mouseover)
            {
                CombatText.NewText(player.Hitbox, Color.DarkRed, "Mouseover is true!", dramatic: true);
            }
            for (int i = 0; i < Main.maxNPCs; i++) {
                NPC npc = Main.npc[i];
                if (npc.active) {
                    Rectangle hitbox = npc.Hitbox;
                    hitbox.Inflate(5, 5);
                    if (hitbox.Contains(location)) {
                        mouseover = true;
                        npc.life = 0;
                    }
                }
            }
            
            return true;
        }   
    }
}