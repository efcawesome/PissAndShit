using Microsoft.Xna.Framework;
using PissAndShit.Dusts;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit
{
    public class PaSPlayer : ModPlayer
    {
        public bool kamra = false;
        public bool soaped = false;

        public override void ResetEffects()
        {
            kamra = false;
            soaped = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (kamra)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 25;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (soaped)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, DustType<SoapBubble>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.5f;
                b *= 0.7f;
            }
        }
    }
}
