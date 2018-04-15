using System;

using Microsoft.Xna.Framework;

namespace Hydra.Scenes
{
    public class GameScene : Scene
    {
        Label label;

		internal override void load()
		{
            base.load();

            label = new Label("Hello, World!");
            label.alpha = 0.0f;
            label.run(Action.fadeIn(2.0f));

            gameWorld.addChild(label);
		}
	}
}
