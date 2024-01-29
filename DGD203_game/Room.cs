public class Room
{
    public const int MapSize = 5;
    public void CheckForClue(int x, int y, ref bool hasEncounteredRiddlemaster, ref bool hasAnsweredRiddleCorrectly, ref bool hasFoundClue, int npcLocationX, int npcLocationY, NPC npc)
    {
       
        if (hasEncounteredRiddlemaster && !hasAnsweredRiddleCorrectly)
        {
            
            if (x == -1 && y == 2 && !hasFoundClue)
            {
                Console.WriteLine("You found a clue! It says: [You can try the riddle again]");
                hasFoundClue = true; 
            }
            
            else if (x == npcLocationX && y == npcLocationY)
            {
                
                if (hasFoundClue)
                {
                    Console.WriteLine("You encounter the Riddlemaster again!");
                    npc.AskRiddle();
                    Console.WriteLine("Enter your answer (1-5):");

                    if (int.TryParse(Console.ReadLine(), out int playerAnswer))
                    {
                        if (npc.CheckAnswer(playerAnswer))
                        {
                            Console.WriteLine("Congratulations! You solved the riddle. You won the game!");
                            hasAnsweredRiddleCorrectly = true;
                            Environment.Exit(0);
                        }
                        
                        {
                            if (!hasFoundClue)
                            {
                                
                                if (x == -1 && y == 2)
                                {
                                    Console.WriteLine("You found a clue! It says: [You can try the riddle again]");
                                    hasFoundClue = true; 
                                }
                            }
                            else
                            {
                                Console.WriteLine("The Riddlemaster's patience wears thin. Your journey ends here.");
                                
                                Environment.Exit(0);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    }
                }
                else
                {
                    Console.WriteLine("You need to find the clue before encountering the Riddlemaster again.");
                }
            }
        }
    }

    public void PrintRoom(Player player)
    {
        Console.WriteLine($"You are standing on {player.X}, {player.Y}");
    }
}