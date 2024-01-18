using System;
using CLIGameEngine;

namespace Level_16_SimulasTest
{
    public class Game
    {
        GameEngine gameEngine;

        private ChestState _chestState;
        private string _playerAction;

        public Game()
        {
            gameEngine = new GameEngine();
            gameEngine.RunGame(Start,Update);
        }

        private void Start()
        {
            _chestState = ChestState.locked;
        }

        private void Update()
        {
            _playerAction = gameEngine.InputHandler($"The chest {_chestState}. What do you want to do? ");
            ManipulateChest(_playerAction);
        }

        private void ManipulateChest(string playerAction)
        {
            playerAction = playerAction.ToLower();
            if(_chestState == ChestState.open)
            {
                if(playerAction == "close")
                    _chestState = ChestState.closed;
            }
            else if (_chestState == ChestState.closed)
            {
                if (playerAction == "open")
                    _chestState = ChestState.open;
                else if (playerAction == "lock")
                    _chestState= ChestState.locked;
            }
            else if (_chestState == ChestState.locked)
            {
                if (playerAction == "unlock")
                    _chestState = ChestState.closed;
            }
            else
            {
                Console.WriteLine("Nothing interesting happens.");
            }
        }

        public enum ChestState
        {
            open,
            closed,
            locked
        }
    }
}
