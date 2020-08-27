using Microsoft.Xna.Framework;
using Steamworks;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class CursedSoul : ModNPC
    {
        private bool hit = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Soul");
        }

        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 32;
            npc.damage = 0;
            npc.defense = 0;
            npc.immortal = true;
            npc.lifeMax = 1;
            npc.HitSound = SoundID.NPCHit8;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            npc.direction = npc.spriteDirection = npc.Center.X < player.Center.X ? -1 : 1;
            Vector2 targetPosition = Main.player[npc.target].position;
            if(targetPosition.X > npc.position.X && npc.velocity.X >= -6)
            {
                npc.velocity.X -= 0.1f;
            }
            else if (targetPosition.X < npc.position.X && npc.velocity.X <= 6)
            {
                npc.velocity.X += 0.1f;
            }
            if(npc.velocity.X >= 3 || npc.velocity.X <= -3)
            {
                Dust dust;
                Vector2 position = npc.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            }
            if(hit == true)
            {
                player.statLife += 25;
                Dust dust;
                Dust dust1;
                Dust dust2;
                Dust dust3;
                Vector2 position = new Vector2(npc.Center.X - npc.width / 2, npc.Center.Y);
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust1 = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust2 = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust3 = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                npc.active = false;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            hit = true;
        }
    }
}