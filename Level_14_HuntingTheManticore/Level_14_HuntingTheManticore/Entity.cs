using System;

public abstract class Entity
{
    public string Name { get; private set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    protected Entity(string name = "Entity", int startingHealth = 10)
    {
        Name = name;
        MaxHealth = startingHealth;
        CurrentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
    }

    public abstract string DeathMessage();
}

public class Player : Entity
{
    public Player(string name = "Player", int startingHealth = 10) : base(name, startingHealth) { }

    public override string DeathMessage()
    {
        return "The city of Consolas hsa been destroyed. Many lives were lost.";
    }
}

public class Enemy : Entity
{
    public int Distance { get; private set; }

    public Enemy(int distance, string name = "Enemy", int startingHealth = 10) : base(name, startingHealth)
    {
        Distance = distance;
    }
    public override string DeathMessage()
    {
        return "The Manticore has been destroyed! The City of Consolas has been saved!";
    }
}