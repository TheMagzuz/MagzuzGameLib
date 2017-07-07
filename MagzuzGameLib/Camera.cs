using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MagzuzGameLib
{
    public class Camera
    {
        protected float _zoom;
        public float rotation;

        public float zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; }
        }

        public Matrix transform;
        protected Vector2 _position;

        public Vector2 position
        {
            get { return _position; }
            set { setPosition(value); }
        }

        public bool hasMoved = false;

        public Camera()
        {
            zoom = 1;
            rotation = 0;
            position = Vector2.Zero;
        }

        public void move(Vector2 amount)
        {
            position += amount;
            hasMoved = true;
        }

        public void setPosition(Vector2 pos)
        {
            position = pos;
            hasMoved = true;
        }

        public Matrix getTransformation(GraphicsDevice g)
        {
            Viewport v = g.Viewport;

            Matrix t = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(v.Width / 2, v.Height / 2, 0));
            return t;
        }

        public Rectangle getWorldRect(GameWindow window)
        {
            return new Rectangle(
                Convert.ToInt32(position.X - ((window.ClientBounds.Width / 2) / zoom)),
                Convert.ToInt32(position.Y - ((window.ClientBounds.Height / 2) / zoom)),
                Convert.ToInt32(window.ClientBounds.Width / zoom),
                Convert.ToInt32(window.ClientBounds.Height / zoom));
        }

    }
}
