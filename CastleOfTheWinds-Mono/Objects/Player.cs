using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class Player : Sprite, IMoveable
    {
        KeyboardState _previousKeyboardState;
        const int TILE_SIZE = 32;
        public Player(Texture2D texture, Rectangle source, Vector2 initialPosition) : base(texture, source, initialPosition)
        {
        }

        const float MOVE_DELAY = 0.25f;
        float _moveTimer = 0f;

        public Vector2 GetNextPosition(float deltaTime)
        {
            var currentKeyboardState = Keyboard.GetState();
            var nextPosition = Position;

            _moveTimer += deltaTime;
            bool canMoveAgain = _moveTimer >= MOVE_DELAY;

            if (currentKeyboardState.IsKeyDown(Keys.Left) &&
                (canMoveAgain || !_previousKeyboardState.IsKeyDown(Keys.Left)))
            {
                nextPosition.X -= TILE_SIZE;
                _moveTimer = 0;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Right) &&
                (canMoveAgain || !_previousKeyboardState.IsKeyDown(Keys.Right)))
            {
                nextPosition.X += TILE_SIZE;
                _moveTimer = 0;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Up) &&
                (canMoveAgain || !_previousKeyboardState.IsKeyDown(Keys.Up)))
            {
                nextPosition.Y -= TILE_SIZE;
                _moveTimer = 0;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Down) &&
                (canMoveAgain || !_previousKeyboardState.IsKeyDown(Keys.Down)))
            {
                nextPosition.Y += TILE_SIZE;
                _moveTimer = 0;
            }

            _previousKeyboardState = currentKeyboardState;
            return nextPosition;
        }
    }
}
