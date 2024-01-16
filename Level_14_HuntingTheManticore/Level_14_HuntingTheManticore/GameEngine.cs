using System;

public class GameEngine
{
	private bool _gameActive;
	private int _currentTurn;
	private int _playerGuess;

	private Player City;
	private Enemy Manticore;

	public GameEngine()
	{
		_currentTurn = 1;
		_gameActive = true;
		InitPlayers();
	}

	public void RunGame()
	{
		InitPlayers();

		while (_gameActive)
		{
			Console.WriteLine("====================");
			RoundCounter();
			InputHandler();

            City.TakeDamage(1);

            _gameActive = CheckWinConditionIsMet();
            _currentTurn++;
        }
	}

	public void InitPlayers()
	{
		City = new Player("City", 15);
		Manticore = new Enemy(10, "Manticore", 10);
	}

	public void InputHandler()
	{
		Console.Write("Enter desired canon range: ");
		string playerGuess = Console.ReadLine();

		if (Int32.TryParse(playerGuess, out int result))
		{
			PlayerGuess(result);
		}
		else
		{
			Console.WriteLine("Value entered was not a number, try again.");
			InputHandler();
		}
	}

	public void RoundCounter()
	{
		Console.WriteLine($"Status: Round {_currentTurn} City: {City.CurrentHealth}/{City.MaxHealth} Manticore: {Manticore.CurrentHealth}/{Manticore.MaxHealth}");
		Console.WriteLine($"The cannon is expected to deal {CalculateDamage()} damage this round.");
	}

	public void PlayerGuess(int playerGuess)
	{
		if (playerGuess == Manticore.Distance)
		{
			Console.WriteLine("That round was a DIRECT HIT!");
			Manticore.TakeDamage(CalculateDamage());
		}
		else if (playerGuess > Manticore.Distance)
		{
			Console.WriteLine("That round OVERSHOT of the target");
		}
		else if (playerGuess < Manticore.Distance)
        {
            Console.WriteLine("That round FELL SHORT of the target");
        }
    }

	private int CalculateDamage()
	{
		if (_currentTurn != 1)
		{
			if (_currentTurn / 3 == 1 || _currentTurn / 5 == 1)
				return 3;
		}
		return 1;
	}

	public bool CheckWinConditionIsMet()
	{
		if (Manticore.CurrentHealth <= 0)
		{
            Console.WriteLine(Manticore.DeathMessage());
            return false;
        }
		if (City.CurrentHealth <= 0)  
		{
			Console.WriteLine(City.DeathMessage());
			return false;
		}
		else return true;
	}
}