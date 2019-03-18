using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hydra.Scenes
{
    class GameScene : SKScene
    {
        Label label;

        SKAction pulse;

		internal override void load()
		{
            base.load();

            DisplayMode displayMode = Game1.current.graphicsDeviceManager.GraphicsDevice.DisplayMode;

            label = new Label($"{displayMode.Width},{displayMode.Height}");
            label.alpha = 0.0f;
            label.run(SKAction.fadeIn(2.0f));

            gameWorld.addChild(label);

            pulse = SKAction.group(new[] {
                
                SKAction.sequence(new[]{
                    SKAction.scaleBy(0.6f, 0.3f),
                    SKAction.scaleTo(1.0f, 0.3f)
                }),

                SKAction.sequence(new[]{
                    SKAction.fadeOut(0.3f),
                    SKAction.fadeIn(0.3f)
                })
            });
        }

		internal override void touchDown(Touch touch)
		{
            base.touchDown(touch);

            label.run(pulse, "fadeInOut");

            SKSpriteNode spriteNode = spinnyNode();
            spriteNode.color = Color.Green;
            spriteNode.position = touch.locationIn(gameWorld);
            gameWorld.addChild(spriteNode);
		}

		internal override void touchMoved(Touch touch)
		{
            base.touchMoved(touch);

            SKSpriteNode spriteNode = spinnyNode();
            spriteNode.color = Color.Blue;
            spriteNode.position = touch.locationIn(gameWorld);
            gameWorld.addChild(spriteNode);
		}

		internal override void touchUp(Touch touch)
		{
            base.touchUp(touch);

            SKSpriteNode spriteNode = spinnyNode();
            spriteNode.color = Color.Red;
            spriteNode.position = touch.locationIn(gameWorld);
            gameWorld.addChild(spriteNode);
		}

		SKSpriteNode spinnyNode()
        {
            SKSpriteNode spriteNode = new SKSpriteNode("spinnyNode");

            spriteNode.run(SKAction.repeatForever(SKAction.rotateBy((float)Math.PI, 1.0f)));

            spriteNode.run(SKAction.sequence(new[]{
                SKAction.waitForDuration(0.5f),
                SKAction.fadeOut(0.5f),
                SKAction.removeFromParent()
            }));

            return spriteNode;
        }
	}
}
