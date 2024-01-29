using System;

public class NPC
{
    public void AskRiddle()
    {
        Console.WriteLine("Welcome, brave adventurer! Prepare yourself for a riddle.");
        Console.WriteLine("I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?");
        Console.WriteLine("1. River");
        Console.WriteLine("2. Candle");
        Console.WriteLine("3. Echo");
        Console.WriteLine("4. Mirror");
        Console.WriteLine("5. Silence");
    }

    public bool CheckAnswer(int playerAnswer)
    {
        return playerAnswer == 3;
    }
}
