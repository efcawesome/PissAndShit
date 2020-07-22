using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Terraria.Localization;
using Microsoft.Xna.Framework.Audio;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    public class GodSlime : ModNPC
    {
        private int frameNum = 0;
        private int frameTimer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Slime");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 492;
            npc.height = 300;

            npc.boss = true;
            npc.aiStyle = 1;
            aiType = 1;
            
            npc.npcSlots = 5;

            npc.lifeMax = 10000000;
            npc.damage = 400;
            npc.defense = 175;
            npc.knockBackResist = 0f;

            npc.value = Item.buyPrice(platinum: 15);

            npc.lavaImmune = false;
            npc.noTileCollide = false;
            npc.noGravity = false;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.LunarBoss;

            bossBag = mod.ItemType("GodSlimeTreasureBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.3f);
        }

        public override void NPCLoot()
        {
            int bossWeapon = Main.rand.Next(4);
            if (Main.expertMode)
            {
                npc.DropBossBags();
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
            } else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, 999);
                if(bossWeapon == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GodlyCross"));
                }
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), mod.NPCType("GodSlimeWorshipper"), npc.whoAmI);
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override void AI()
        {
            frameTimer++;
        }
        public override void FindFrame(int frameHeight)
        {

            if (frameTimer == 6)
            {
                frameNum++;
                frameTimer = 0;
            }

            if (frameNum == 4)
            {
                frameNum = 0;
            }

            npc.frame.Y = frameNum * frameHeight;
        }
    }
}
