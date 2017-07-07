using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MagzuzGameLib.GameObjects;

namespace MagzuzGameLib.Factories
{

    sealed class GameObjectFactory
    {

        public GameObject CreateGameObject(GameObjectManager manager, Texture2D texture, Vector2 position)
        {
            GameObject go = new GameObject(manager, texture, position);
            manager.gameObjects.Add(go);
            return go;
        }

        public GameObject CreateGameObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity)
        {
            GameObject go = new GameObject(manager, texture, position, velocity);
            manager.gameObjects.Add(go);
            return go;
        }

        public GameObject CreateGameObject(GameObjectManager manager, Texture2D texture, Vector2 position, Vector2 velocity, Color tint)
        {
            GameObject go = new GameObject(manager, texture, position, velocity);
            manager.gameObjects.Add(go);
            return go;
        }

    }
}
