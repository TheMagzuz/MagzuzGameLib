using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MagzuzGameLib.Helpers;

namespace MagzuzGameLib
{
    public abstract class MagzuzGame : Game
    {

        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        /// <summary>
        /// How many units outside the game view the render area will extend
        /// </summary>
        public readonly int renderAreaExtend;

        /// <summary>
        /// The area that will be rendered. Anything outside this area will not be processed
        /// </summary>
        public Rectangle renderArea { get; protected set; }

        public readonly GameObjectManager gameObjectManager;

        public Camera camera = new Camera();

        #region Delegates
        public delegate void UpdateDelegate(GameTime gameTime);


        public event UpdateDelegate update;
#endregion
        public MagzuzGame()
        {
            gameObjectManager = new GameObjectManager(this, renderArea);
        }

        #region Initialization
        protected override void Initialize()
        {
            camera.position = Vector2Helper.GetViewportCenter(GraphicsDevice.Viewport);

            Rectangle worldRect = camera.getWorldRect(Window);

            renderArea = new Rectangle(worldRect.Location.X-renderAreaExtend, worldRect.Y+renderAreaExtend, worldRect.Width+renderAreaExtend,worldRect.Height+renderAreaExtend);
            base.Initialize();
        }
        #endregion

        #region Repeating methods
        protected override void Update(GameTime gameTime)
        {
            update(gameTime);
            if (camera.hasMoved)
            {
                renderArea = camera.getWorldRect(Window);
            }
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
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.getTransformation(GraphicsDevice));
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
