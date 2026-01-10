using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace DungeonSlime;

public class Game1 : Core
{
    private Texture2D _logo;

    // Defines the slime sprite.
    private Sprite _slime;

    // Defines the bat sprite.
    private Sprite _bat;

    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load the image from the content pipeline
        _logo = Content.Load<Texture2D>("images/logo");

        // Create the texture atlas from the XML configuration file
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // Create the slime sprite from the atlas.
        _slime = atlas.CreateSprite("slime");
        _slime.Scale = new Vector2(4.0f, 4.0f);

        // Create the bat sprite from the atlas.
        _bat = atlas.CreateSprite("bat");
        _bat.Scale = new Vector2(4.0f, 4.0f);

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the logo texture
        SpriteBatch.Draw(
            _logo,              // texture
            new Vector2(        // position
                // I want to make an extra note here to remember that
                // multiplying instead of dividing is an optimization technique
                // that improves CPU performance. 
                Window.ClientBounds.Width,
                Window.ClientBounds.Height) * .5f,
            null,               // sourceRectangle, null renders the entire texture
            Color.White,        // color, renders the texture with no tint
            0.0f,               // rotation, the amount of rotation in radians
            new Vector2(_logo.Width, _logo.Height) * .5f,       // origin, x and y coordinates for position of texture origin
            1.5f,               // scale, how to scale the texture, 1.0f is no scaling, normal size
            SpriteEffects.None, // effects, should the texture be flipped horizontally, vertically, or both
            0.0f                // layerDepth, the depth for which the texture is rendered, only applies with "SpriteSortMode.FrontToBack" or "SpriteSortMode.BackToFront"
        );

        // Draw the slime sprite.
        _slime.Draw(SpriteBatch, Vector2.Zero);

        // Draw the bat sprite 10px to the right of the slime.
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));
        
        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
