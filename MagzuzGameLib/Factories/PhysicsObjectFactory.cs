using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MagzuzGameLib.GameObjects;

namespace MagzuzGameLib.Factories
{
    sealed class PhysicsObjectFactory
    {

        public PhysicsObject CreatePhysicsObject(GameObjectManager manager, Texture2D texture, Vector2 position)
        {
            PhysicsObject go = new PhysicsObject(manager, texture, position);
            manager.gameObjects.Add(go);
            return go;
        }

        public PhysicsObject CreatePhysicsObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity)
        {
            PhysicsObject go = new PhysicsObject(manager, texture, position, velocity);
            manager.gameObjects.Add(go);
            return go;
        }

        public PhysicsObject CreatePhysicsObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity, Color tint)
        {
            PhysicsObject go = new PhysicsObject(manager, texture, position, velocity);
            manager.gameObjects.Add(go);
            return go;
        }

    }
}
