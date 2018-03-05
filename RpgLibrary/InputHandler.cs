using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RpgLibrary
{
    public class InputHandler : GameComponent
    {
        public static KeyboardState KeyboardState { get; private set; }
        public static KeyboardState LastKeyboardState { get; private set; }

        public static GamePadState[] GamePadStates { get; private set; }
        public static GamePadState[] LastGamePadStates { get; private set; }

        public InputHandler(Game game) : base(game)
        {
            KeyboardState = Keyboard.GetState();
            GamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];

            foreach (PlayerIndex playerIndex in Enum.GetValues(typeof(PlayerIndex)))
                GamePadStates[(int) playerIndex] = GamePad.GetState(playerIndex);
        }

        public override void Update(GameTime gameTime)
        {
            LastKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

            LastGamePadStates = (GamePadState[]) GamePadStates.Clone();
            foreach(PlayerIndex playerIndex in Enum.GetValues(typeof(PlayerIndex)))
                GamePadStates[(int) playerIndex] = GamePad.GetState(playerIndex);

            base.Update(gameTime);
        }

        public static void Flush()
        {
            LastKeyboardState = KeyboardState;
        }

        public static bool IsKeyReleased(Keys key)
        {
            return KeyboardState.IsKeyUp(key) &&
                   LastKeyboardState.IsKeyDown(key);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return KeyboardState.IsKeyDown(key) &&
                   LastKeyboardState.IsKeyUp(key);
        }

        public static bool IsKeyDown(Keys key)
        {
            return KeyboardState.IsKeyDown(key);
        }

        public static bool IsButtonReleased(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int) index].IsButtonUp(button) &&
                   LastGamePadStates[(int) index].IsButtonDown(button);
        }

        public static bool IsButtonPressed(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int) index].IsButtonDown(button) &&
                   LastGamePadStates[(int) index].IsButtonUp(button);
        }

        public static bool IsButtonDown(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int) index].IsButtonDown(button);
        }
    }
}
