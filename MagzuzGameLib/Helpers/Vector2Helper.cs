using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagzuzGameLib.Helpers
{
    public class Vector2Helper
    {
        public static Vector2 GetViewportCenter(Viewport v)
        {
            return new Vector2(v.Width / 2, v.Height / 2);
        }
        public static Vector2 ToVector2(Vector3 v)
        {
            return new Vector2(v.X, v.Y);
        }

    }
}
