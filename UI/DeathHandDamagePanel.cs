using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.GameContent.UI.Elements;

namespace PissAndShit.UI
{
    class DeathHandDamagePanel : UIState
    {
        public DraggablePanel BackgroundPanel;
        public UINumberPanel UINumPanel;
        public static bool DeathHandPanelVisible;
        public override void OnInitialize()
        {
        	BackgroundPanel = new DraggablePanel();
			BackgroundPanel.SetPadding(0);
			BackgroundPanel.Left.Set(400f, 0f);
			BackgroundPanel.Top.Set(50f, 0f);
			BackgroundPanel.Width.Set(60f, 0f);
			BackgroundPanel.Height.Set(20f, 0f);
            BackgroundPanel.BackgroundColor = new Color(73, 94, 171);

            UINumPanel = new UINumberPanel();
            //UINumPanel.SetPadding(0); // ?????
            UINumPanel.Left.Set(20f, 0f);
            UINumPanel.Top.Set(10f, 0f);
            BackgroundPanel.Append(UINumPanel);

            Append(BackgroundPanel);
        }
        /*private void HitButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            int damageToDeal = 0;
            Int32.TryParse(UINumPanel.text, out damageToDeal);
            NPC npc = Main.npc[PaSWorld.deathHandNPCIdentifier];
            npc.life =- 0;
        }*/
    }
}