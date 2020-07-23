using System;
using PissAndShit.Items.Consumables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class Eggling : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eggling");
        
        }

        public override void SetDefaults()
        {
            npc.width = 220;
            npc.height = 220;
            npc.lifeMax = 80;
            npc.damage = 4;
            npc.defense = 0;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 10f;
            npc.knockBackResist = 0.75f;
            npc.aiStyle = 49;
            aiType = NPCID.AngryNimbus;
            banner = Item.NPCtoBanner(NPCID.Bunny);
            bannerItem = Item.BannerToItem(banner);   
            }
        }
    }
}
