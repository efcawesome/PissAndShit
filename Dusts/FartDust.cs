using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Dusts
{
	public class FartDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.35f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.32f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.985f;

			if (dust.scale < 0.2f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}