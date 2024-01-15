using System;

public class GameEngine
{
	private bool _gameActive;
	private int _currentTurn;
	private int _playerGuess;

	private int _currentManticoreHealth = 10;
	private int _maxManticoreHealth = 10;
	private int _manticoreDistance = 10;


	private int _currentCityHealth = 15;
	private int _maxCityHealth = 15;

	public GameEngine()
	{
		_currentTurn = 1;
		_gameActive = true;
	}

	public void RunGame()
	{
		while (_gameActive)
		{
			Console.WriteLine("====================");
			RoundCounter();
			InputHandler();

			_currentTurn++;
		}
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
			Console.WriteLine("Could not be parsed");
		}
	}

	public void RoundCounter()
	{
		Console.WriteLine($"Status: Round {_currentTurn} City: {_currentCityHealth}/{_maxCityHealth} Manticore: {_currentManticoreHealth}/{_maxManticoreHealth}");
        Console.WriteLine($"The cannon is expected to deal {CalculateDamage()} this round");
    }

	public void PlayerGuess(int playerGuess)
	{
		if (playerGuess == _manticoreDistance)
		{
			Console.WriteLine("That round was a DIRECT HIT!");
			_currentManticoreHealth -= CalculateDamage();
		}
        else if (playerGuess != _manticoreDistance)
        {
            Console.WriteLine("That round FELL SHORT of the target");
        }
    }

	private int CalculateDamage()
	{
		if(_currentTurn != 1)
		{
			if( _currentTurn / 3 == 1 || _currentTurn / 5 == 1)
				return 3;
		}
        return 1;
    }
}
public abstract class Entity
{
	private string _name;
	private int _maxHealth;
	private int _currentHealth;
}

public class Player : Entity
{

}

public class Enemy : Entity
{
	private int _distance;
}