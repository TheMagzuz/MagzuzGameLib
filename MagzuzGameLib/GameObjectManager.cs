using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MagzuzGameLib.GameObjects;
using C3.XNA;

namespace MagzuzGameLib
{
    public sealed class GameObjectManager
    {

        MagzuzGame game;

        internal QuadTree<GameObject> gameObjects;

        #region Constructor
        /// <summary>
        /// Creates a GameObjectManager with the game as a parent
        /// </summary>
        /// <param name="game">The game that this manager manages the objects of</param>
        /// <param name="gameArea">The area that objects will exist. Any objects outside this area will not be processed</param>
        public GameObjectManager(MagzuzGame game, Rectangle gameArea)
        {
            this.game = game;
            gameObjects = new QuadTree<GameObject>(gameArea);
            game.update += new MagzuzGame.UpdateDelegate(Update);
        }
#endregion


        /// <summary>
        /// This should be called in the <see cref="Game.Draw(GameTime)"/> method
        /// </summary>
        /// <param name="spritebatch">The spritebatch used to draw GameObjects</param>
        public void Draw(SpriteBatch spritebatch)
        {
            foreach (GameObject go in gameObjects)
            {
                go.Draw(spritebatch);
            }
        }

        /// <summary>
        /// This should be called in <see cref="Game.Update(GameTime)">
        /// </summary>
        /// <param name="gameTime">The <see cref="GameTime"/> parameter from <see cref="Game.Update(GameTime)"/> </param>
        public void Update(GameTime gameTime)
        {
            foreach (GameObject go in gameObjects)
            {
                go._update(gameTime);
            }
        }


    }
}
