using MagzuzGameLib.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MagzuzGameLib.Physics;
using System.Collections.Generic;


namespace MagzuzGameLib.GameObjects
{
    class PhysicsObject : GameObject
    {
        protected float gravity = PhysicsHelper.gravity;

        #region Constructors
        internal PhysicsObject(GameObjectManager manager, Texture2D texture, Vector2 position) : base(manager, texture, position)
        {

        }

        internal PhysicsObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity) : base(manager, texture, position, velocity)
        {

        }

        internal PhysicsObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity, Color tint) : base(manager, texture, position, velocity, tint)
        {

        }
        #endregion

        protected override void ApplyMovement(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 prevPos = position;
            HasMoved = false;

            // Move the player on the x-axis
            position.X += velocity.X * (deltaTime);

            // If this object should collide with other objects, check for horizontal collision.
            if (collide)
                CheckCollisions(Direction.Horizontal);

            // Apply gravity
            velocity.Y += -gravity;
            // Move the player on the y-axis
            position.Y -= velocity.Y * (deltaTime);
            // If this object should collide with other objects, check for vertical collision.
            if (collide)
                CheckCollisions(Direction.Vertical);



            if (position != prevPos) HasMoved = true;
        }

        protected virtual void CheckCollisions(Direction direction)
        {
            //Get a list of objects to test against
            List<GameObject> tiles = owner.gameObjects.GetObjects(BoundingBox);

            //Loop and check for collisions on these objects
            for (int i = 0; i < tiles.Count; i++)
            {
                if (!tiles[i].collide) continue;
                if (tiles[i].Equals(this)) continue;

                //Calculate intersection depth
                Vector2 depth;
                if (CollisionHelper.Intersects(this.BoundingBox, tiles[i].BoundingBox, direction, out depth))
                {
                    //If an intersection was found - adjust position
                    position += depth;

                    //Adjust velocity based on intersection direction
                    if (direction == Direction.Horizontal)
                        velocity.Y = 0;
                    else
                        velocity.X = 0;
                }
            }
        }

    }
}
