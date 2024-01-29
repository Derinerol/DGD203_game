
public class Game
{
    private Player player;
    private Room room;
    private NPC npc;

    private int npcLocationX;
    private int npcLocationY;
    private bool hasEncounteredRiddlemaster;
    private bool hasAnsweredRiddleCorrectly;
    private bool hasFoundClue; 
    private bool shouldEndGame = false;
    public void Start()
    {
        Console.WriteLine("Created map with size 5x5");
        player = new Player();
        room = new Room();
        npc = new NPC();

        npcLocationX = 1;
        npcLocationY = -1;

        while (!shouldEndGame)
        {
            Console.WriteLine("Enter your move (N, W, S, E)");
            string move = Console.ReadLine().ToUpper();

            if (move == "EXIT")
            {
                Console.WriteLine("Thanks for playing! Exiting the game.");
                shouldEndGame = true;
            }
            else if (IsValidMove(move))
            {
                MovePlayer(move);
                room.PrintRoom(player);

                if (!hasEncounteredRiddlemaster && player.X == npcLocationX && player.Y == npcLocationY)
                {
                    EncounterRiddlemaster();
                }

                if (hasEncounteredRiddlemaster && !hasAnsweredRiddleCorrectly)
                {
                    CheckForClue();
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }
    private bool IsValidMove(string move)
    {
        return move == "N" || move == "W" || move == "S" || move == "E";
    }

    private void MovePlayer(string move)
    {
        switch (move)
        {
            case "N":
                if (player.Y + 1 <= 2)
                {
                    player.Y++;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "W":
                if (player.X - 1 >= -2)
                {
                    player.X--;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "S":
                if (player.Y - 1 >= -2)
                {
                    player.Y--;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            case "E":
                if (player.X + 1 <= 2)
                {
                    player.X++;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
                break;
            default:
                Console.WriteLine("Invalid move. Try again.");
                break;
        }
    }

    private void CheckForClue()
    {
        room.CheckForClue(player.X, player.Y, ref hasEncounteredRiddlemaster, ref hasAnsweredRiddleCorrectly, ref hasFoundClue, npcLocationX, npcLocationY, npc);
    }

    private void EncounterRiddlemaster()
    {
        if (!hasEncounteredRiddlemaster)
        {
            Console.WriteLine("You encounter the Riddlemaster!");
            hasEncounteredRiddlemaster = true;
            npc.AskRiddle();
            Console.WriteLine("Enter your answer (1-5):");
        }
        else if (hasEncounteredRiddlemaster && !hasFoundClue)
        {
            Console.WriteLine("You need to find the clue before encountering the Riddlemaster again.");
            return;
        }
        else if (hasEncounteredRiddlemaster && hasFoundClue && !hasAnsweredRiddleCorrectly)
        {
            Console.WriteLine("You encounter the Riddlemaster again!");
            npc.AskRiddle();
            Console.WriteLine("Enter your answer (1-5):");
        }
        
        if (int.TryParse(Console.ReadLine(), out int playerAnswer))
        {
            if (npc.CheckAnswer(playerAnswer))
            {
                Console.WriteLine("Congratulations! You solved the riddle. You won the game!");
                hasAnsweredRiddleCorrectly = true;
                shouldEndGame = true;  
            }
            else
            {
                Console.WriteLine("Incorrect answer. The Riddlemaster frowns upon you.");              
                
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        }
    }
}