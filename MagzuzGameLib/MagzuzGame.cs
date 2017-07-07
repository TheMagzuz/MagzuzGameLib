using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MagzuzGameLib.Helpers;

namespace MagzuzGameLib
{
    public abstract class MagzuzGame : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// How many units outside the game view the render area will extend
        /// </summary>
        float renderAreaExtend;

        /// <summary>
        /// The area that will be rendered. Anything outside this area will not be processed
        /// </summary>
        Rectangle renderArea;

        GameObjectManager gameObjectManager;

        public Camera camera = new Camera();

        #region Delegates
        public delegate void UpdateDelegate(GameTime gameTime);


        public event UpdateDelegate update;
#endregion
        public MagzuzGame()
        {
            gameObjectManager = new GameObjectManager(this, new Rectangle(-100, 100, 200, 200));
        }

        #region Initialization
        protected override void Initialize()
        {
            camera.position = Vector2Helper.GetViewportCenter(GraphicsDevice.Viewport);
            base.Initialize();
        }
        #endregion

        #region Repeating methods
        protected override void Update(GameTime gameTime)
        {
            update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// You probably want to use <see cref="_draw(GameTime)"/>
        /// </summary>
        /// <seealso cref="PreDraw(GameTime)"/>
        /// <seealso cref="_draw(GameTime)"/>
        /// <seealso cref="PostDraw(GameTime)"/>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            PreDraw(gameTime);
            _draw(gameTime);
            PostDraw(gameTime);

            base.Draw(gameTime);
        }


        /// <summary>
        /// Called in the <see cref="Draw(GameTime)"/> function as the first thing, by default
        /// </summary>
        /// <seealso cref="_draw(GameTime)"/>
        /// <seealso cref="PostDraw(GameTime)"/>
        /// <param name="gameTime"></param>
        protected virtual void PreDraw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
        }

        /// <summary>
        /// Called after <see cref="PreDraw(GameTime)"/>. Should be used, rather than <see cref="Draw(GameTime)"/>
        /// </summary>
        /// <seealso cref="PreDraw(GameTime)"/>
        /// <see cref="PostDraw(GameTime)"/>
        /// <param name="gameTime"></param>
        protected virtual void _draw(GameTime gameTime)
        {
            gameObjectManager.Draw(spriteBatch);
        }

        /// <summary>
        /// Called after <see cref="PreDraw(GameTime)"/> and <see cref="_draw(GameTime)"/>
        /// </summary>
        /// <seealso cref="PreDraw(GameTime)"/>
        /// <seealso cref="_draw(GameTime)"/>
        /// <param name="gameTime"></param>
        protected virtual void PostDraw(GameTime gameTime)
        {
            spriteBatch.End();
        }

#endregion


    }
}
