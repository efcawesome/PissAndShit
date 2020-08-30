using Terraria.UI;
using Microsoft.Xna.Framework;

namespace PissAndShit.UI
{
    class DeathHandPanelDraw : UIState
    {
        public DraggablePanel TestPanel;
        public static bool DeathHandPanelVisible;

        public override void OnInitialize()
        {
        	TestPanel = new DraggablePanel();
			TestPanel.SetPadding(0);
			TestPanel.Left.Set(400f, 0f);
			TestPanel.Top.Set(100f, 0f);
			TestPanel.Width.Set(170f, 0f);
			TestPanel.Height.Set(70f, 0f);
            TestPanel.BackgroundColor = new Color(73, 94, 171);
            
            Append(TestPanel);
        }
    }
}