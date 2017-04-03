using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace XRpgLibrary
{
    public class GameStateManager : GameComponent
    {
        private static int StartDrawOrder { get; } = 5000;
        private static int DrawOrderInc { get; } = 100;

        private Stack<GameState> GameStates { get; } = new Stack<GameState>();
        private int DrawOrder { get; set; }

        public GameState CurrentState => GameStates.Peek();

        public event EventHandler OnStateChange;

        public GameStateManager(Game game) : base(game)
        {
            DrawOrder = StartDrawOrder;
        }

        public void PopState()
        {
            if (GameStates.Count <= 0)
            {
                return;
            }
            RemoveState();
            DrawOrder -= DrawOrderInc;

            OnStateChange?.Invoke(this, null);
        }

        public void PushState(GameState newState)
        {
            DrawOrder += DrawOrderInc;
            newState.DrawOrder = DrawOrder;

            AddState(newState);

            OnStateChange?.Invoke(this, null);
        }

        public void ChangeState(GameState newState)
        {
            while (GameStates.Count > 0)
            {
                RemoveState();
            }

            newState.DrawOrder = StartDrawOrder;
            DrawOrder = StartDrawOrder;

            AddState(newState);

            OnStateChange?.Invoke(this, null);
        }

        private void RemoveState()
        {
            var state = GameStates.Peek();
            OnStateChange -= state.StateChange;
            Game.Components.Remove(state);
            GameStates.Pop();
        }

        private void AddState(GameState newState)
        {
            GameStates.Push(newState);

            Game.Components.Add(newState);

            OnStateChange += newState.StateChange;
        }

    }
}
