using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coup
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Deck _CourtDeck = new Deck() { }; // creating the courtdeck
            Bank CorruptCompany = new Bank() { };
            //WelcomeMessage(CourtDeck); //Welcome 
            List<Player> _playerList =  _CourtDeck.PutActivePlayersInList(); // gathering players
            _CourtDeck.Deal(_playerList); //Dealing two cards to everyone
            Turn(_playerList,CorruptCompany,_CourtDeck);


        }

        static Player Target(List<Player> playerList)
        {
            Console.WriteLine("Please select your target");
            for (int i = 0; i < playerList.Count(); i++)
            {
                Console.WriteLine($"{i}) {playerList[i]}");
            }
            string userInput = Console.ReadLine();
            int input = Int32.Parse(userInput);

            switch (input)
            {
                case 0:
                    {
                        Player Target = playerList[input];
                        return Target;

                    }
                case 1:
                    {
                        Player Target = playerList[input];
                        return Target;

                    }
                case 2:
                    {
                        Player Target = playerList[input];
                        return Target;

                    }

                case 3:
                    {
                        Player Target = playerList[input];
                        return Target;
                    }
                case 4:
                    {
                        Player Target = playerList[input];
                        return Target;
                    }
                case 5:
                    {
                        Player Target = playerList[input];
                        return Target;
                    }
                case 6:
                    {
                        Player Target = playerList[input];
                        return Target;
                    }
                default:
                    {
                        Player Dummy = new Player() { };
                        return Dummy;
                    }
            }
        }

        static void Turn(List<Player> playerList, Bank corruptCompany, Deck courtDeck)
        {
            for (int i = 0; i < playerList.Count(); i++)
            {
                switch (i)
                {
                    case 0://player 1

                        Console.WriteLine($"{playerList[i]}'s turn.");
                        ActionPhase(corruptCompany, playerList[i], courtDeck, playerList);
                        break;
                    case 1:
                        Console.WriteLine($"{playerList[i]}'s turn.");
                        ActionPhase(corruptCompany, playerList[i], courtDeck, playerList);
                        break;
                    case 2:
                        Console.WriteLine($"{playerList[i]}'s turn.");
                        ActionPhase(corruptCompany, playerList[i], courtDeck, playerList);
                        break;
                    case 3:
                        Console.WriteLine($"{playerList[i]}'s turn.");
                        ActionPhase(corruptCompany, playerList[i], courtDeck, playerList);
                        break;
                    case 4:
                        Console.WriteLine($"{playerList[i]}'s turn.");
                        ActionPhase(corruptCompany, playerList[i], courtDeck, playerList);
                        break;
                    case 5:
                        Console.WriteLine($"{playerList[i]}'s turn.");
                        ActionPhase(corruptCompany, playerList[i], courtDeck, playerList);
                        break;
                    case 6:
                        i = 0;
                        break;
                }
            }
        }


        static void ActionPhase(Bank corruptCompany, Player player, Deck courtdeck, List<Player> playerList)
        {

            bool continueToRun = true;
            while (continueToRun)
            {

                Console.Clear();
                Console.WriteLine($"Enter the number of the option you'd like to select: \n" +
                    "1) Choose to take 1 coin\n" +
                    "2) Take 2 coins \n" +
                    "3) Play a Duke Card \n" +
                    "4) Play a Captain Card \n" +
                    "5) Play an Ambassador Card\n" +
                    "6) Play an Assassin Card.\n" +
                    "7) Coup! \n" +
                    "8) See your cards.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            //Show all
                            player.Income(player, corruptCompany);

                            break;
                        }
                    case "2":
                        {
                            //ForeignAid
                            player.ForeignAid(player, corruptCompany);
                            break;
                        }
                    case "3":
                        {
                            //Dukes option
                            player.Tax(player, corruptCompany);
                            break;
                        }
                    case "4":
                        {
                            //Captain
                            player.Steal(player, Target(playerList)); //figure out how were going to decide to steal from
                            break;
                        }
                    case "5":
                        {
                            player.Exchange(player, courtdeck);
                            break;
                        }
                    case "6":
                        {
                            Player target = Target(playerList);
                            player.Assassinate(player,target,corruptCompany);
                            break;
                        }
                    case "7":
                        {
                            player.Coup(player, Target(playerList), corruptCompany);
                            break;
                        }
                    case "8":
                        {
                            player.ShowHand(player);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}


