using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CringeMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class GodArmorGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Godly Greaves");
            Tooltip.SetDefault("Increases jump height and speed.\nIncreases movement speed.");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Red;
            item.defense = 50;
        }

        public override void UpdateEquip(Player player)
        {
            Player.jumpHeight += 12;
            Player.jumpSpeed *= 3;
            player.moveSpeed *= 3f;
        }
    }
}
