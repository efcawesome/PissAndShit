using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria;

namespace PissAndShit.UI
{
	internal class UIDrawNPC : UIElement
	{
		public int npcType = PaSWorld.deathHandNPCType;
		public int netID = 0;
		public NPC npc = Main.npc[PaSWorld.deathHandNPCType];
        public Vector2 spawnUIAtPosition;
  		public UIDrawNPC(Vector2 position)
		{
			position = spawnUIAtPosition;
        }
		public override void Draw(SpriteBatch spriteBatch)
		{
			Main.instance.LoadNPC(npcType);
            Vector2 drawPosition = spawnUIAtPosition;
			Texture2D texture2D = Main.npcTexture[PaSWorld.deathHandNPCType];
			Rectangle rectangle2;
			rectangle2 = new Rectangle(0, 0, Main.npcTexture[npcType].Width, Main.npcTexture[npcType].Height / Main.npcFrameCount[npcType]);

			float num = 1f;
			float num2 = 280f * 1f * 0.6f;
			if ((float)rectangle2.Width > num2 || (float)rectangle2.Height > num2)
			{
				if (rectangle2.Width > rectangle2.Height)
				{
					num = num2 / (float)rectangle2.Width;
				}
				else
				{
					num = num2 / (float)rectangle2.Height;
				}
			}
			
			drawPosition.X += 280f * 1f / 2f - (float)rectangle2.Width * num / 2f;
			drawPosition.Y += 330f * 1f / 2f - (float)rectangle2.Height * num / 2f;

			spriteBatch.Draw(texture2D, drawPosition, new Rectangle?(rectangle2), Color.White, 0f, Vector2.Zero, num, SpriteEffects.None, 0f);
			
			base.Draw(spriteBatch);
		}
	}
}