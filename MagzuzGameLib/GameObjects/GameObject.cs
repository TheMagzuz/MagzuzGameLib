using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MagzuzGameLib.GameObjects
{
    public class GameObject : IQuadStorable
    {

        #region Variables
        /// <summary>
        /// The texture that the object is drawn with
        /// </summary>
        public Texture2D texture { get; protected set; }

        /// <summary>
        /// The position of the object
        /// This will be set to <code>position + velocity</code> every frame
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// The velocity of the object
        /// </summary>
        public Vector2 velocity;

        /// <summary>
        /// The tint of the object
        /// </summary>
        Color tint;

        /// <summary>
        /// Should the object collide with other objects?
        /// </summary>
        public bool collide = true;

        bool _hasMoved = false;

        /// <summary>
        /// Has the object moved since last frame?
        /// </summary>
        public bool HasMoved { get { return _hasMoved; } set { _hasMoved = value; } }


        /// <summary>
        /// The bounding box of the object
        /// This is used for collision
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height);
            }
        }

        public Rectangle Rect { get { return BoundingBox; } }


        /// <summary>
        /// The center of the object
        /// Defined as <code>(texture.Width / 2, texture.Height / 2) + position</code>
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return new Vector2(texture.Width / 2, texture.Height / 2) + position;
            }
        }

        /// <summary>
        /// The object that manages this object
        /// </summary>
        protected GameObjectManager owner;

#endregion

        #region Constructors
        protected internal GameObject() { }

        internal GameObject(GameObjectManager manager, Texture2D texture, Vector2 position) : this(manager, texture, position, Vector2.Zero)
        {

        }

        internal GameObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity) : this(manager, texture, position, velocity, Color.White)
        {
        }

        internal GameObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity, Color tint)
        {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            this.tint = tint;
        }
        #endregion

        internal virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        internal virtual void _update(GameTime gameTime)
        {
            Update(gameTime);
            ApplyMovement(gameTime);
        }


        /// <summary>
        /// This function is called every frame
        /// </summary>
        /// <param name="gameTime">The gametime given from <see cref="Game.Update(GameTime)"/></param>
        protected virtual void Update(GameTime gameTime)
        {
        }


        /// <summary>
        /// Called every frame after <see cref="Update(GameTime)"/>
        /// </summary>
        /// <param name="gameTime"/></param>
        protected virtual void ApplyMovement(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 prevPos = position;
            HasMoved = false;

            position.X += velocity.X * (deltaTime);
            position.Y -= velocity.Y * (deltaTime);

            if (position != prevPos) HasMoved = true;

        }

    }
}
