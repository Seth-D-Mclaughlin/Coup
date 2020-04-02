using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coup
{
    public class Bank
    {
        public int balance = 50;

        public Bank() { }
    }
    public class Deck
    {
        public List<string> influences = new List<string> { "Duke", "Duke", "Duke", "Contessa", "Contessa", "Contessa", "Assassin", "Assassin", "Assassin", "Ambassador", "Ambassador", "Ambassador", "Captain", "Captain", "Captain" };
        public Deck() { }

        //Random rnd = new Random();
        //int card = rnd.Next(14);

        public void Draw(Player player)
        {
            int deckLength = influences.Count(); //Gets length of deck
            Random number = new Random();
            int num = number.Next(0, deckLength);
            string newCard = influences[num];
            influences.RemoveAt(num);

            player.PlayerHand.Add(newCard);
        }
        public void Deal(List<Player> Players)
        {
            foreach (Player i in Players)
            {
                Draw(i);
                Draw(i);
                i.Coins += 2;
            }
        }
        public List<Player> PutActivePlayersInList()
        {
            Player Player1 = new Player(0) { };
            Player Player2 = new Player(0) { };
            Player Player3 = new Player(0) { };
            Player Player4 = new Player(0) { };
            Player Player5 = new Player(0) { };
            Player Player6 = new Player(0) { };
            List<Player> inactiveplayers = new List<Player> { Player1, Player2, Player3, Player4, Player5, Player6 };


            Console.WriteLine("How many players will there be between 2-6");
            int numOfPlayers = Int32.Parse(Console.ReadLine());
            List<Player> ActivelistOfPlayers = new List<Player>() { };
            for (int i = 0; i <= numOfPlayers; i++)
            {
                ActivelistOfPlayers.Add(inactiveplayers[i]);
            }
            return ActivelistOfPlayers;
        }
    }
    public class Player
    {
        //Properties
        public int Coins { get; set; }
        public List<string> PlayerHand = new List<string>() { };
        //Constructor
        public Player() { }
        public Player(int coins)
        {
            Coins = coins;

        }
        // Methods
        public void Steal(Player theif, Player victim)
        {
            theif.Coins += 2;
            victim.Coins -= 2;
        }
        public void Assassinate(Player Killer, Player victim, Bank Account)
        {
            if (Killer.Coins >= 3)
            {
                Killer.Coins -= 3;
                Account.balance += 3;
                if (victim.PlayerHand.Count >= 2)
                {
                    Console.WriteLine("Pass to the person you are killing.\n Press any key when victim is ready.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"0. {victim.PlayerHand[0]} \n 1. {victim.PlayerHand[1]}");
                    string victimChoice = Console.ReadLine();
                    int victimNum = Int32.Parse(victimChoice);
                    victim.PlayerHand.RemoveAt(victimNum);
                }
                else
                {
                    victim.PlayerHand.Clear();
                }
            }

        }
        public void Exchange(Player Exchanger, Deck CourtDeck)
        {
            CourtDeck.Draw(Exchanger);
            CourtDeck.Draw(Exchanger);
            if (Exchanger.PlayerHand.Count == 3)                    //1 cap  2 ass 3 ass 4 amas
            {
                Console.WriteLine("Choose 1 card to keep.");
                ShowHand(Exchanger);
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        string keeper0 = Exchanger.PlayerHand[0];
                        CourtDeck.influences.Add(Exchanger.PlayerHand[1]);
                        CourtDeck.influences.Add(Exchanger.PlayerHand[2]);
                        Exchanger.PlayerHand.Clear();
                        Exchanger.PlayerHand.Add(keeper0);
                        break;
                    case 1:
                        string keeper1 = Exchanger.PlayerHand[1];
                        CourtDeck.influences.Add(Exchanger.PlayerHand[0]);
                        CourtDeck.influences.Add(Exchanger.PlayerHand[2]);
                        Exchanger.PlayerHand.Clear();
                        Exchanger.PlayerHand.Add(keeper1);
                        break;
                    case 2:
                        string keeper2 = Exchanger.PlayerHand[2];
                        CourtDeck.influences.Add(Exchanger.PlayerHand[0]);
                        CourtDeck.influences.Add(Exchanger.PlayerHand[1]);
                        Exchanger.PlayerHand.Clear();
                        Exchanger.PlayerHand.Add(keeper2);
                        break;
                }
            }
            else if (Exchanger.PlayerHand.Count == 4)
            {
                Console.WriteLine("You may keep 2 cards. Enter first card name to keep.");
                for (int i = 1; i <= Exchanger.PlayerHand.Count; i++)
                {
                    Console.WriteLine($"{i}. {Exchanger.PlayerHand[i]}");
                }
                string input = Console.ReadLine();
                Console.WriteLine("Enter second card name to keep.");
                string input2 = Console.ReadLine();

                List<string> keepers = new List<string>() { };
                for (int i = 1; i <= Exchanger.PlayerHand.Count; i++)
                {

                    if (input == Exchanger.PlayerHand[i])
                    {
                        string keeper = Exchanger.PlayerHand[i];
                        keepers.Add(keeper);
                    }
                    else if (input2 == Exchanger.PlayerHand[i])
                    {
                        string keeper = Exchanger.PlayerHand[i];
                        keepers.Add(keeper);
                    }
                    else
                    {
                        //Fat finger case
                    }


                }
                for (int i = 1; i <= Exchanger.PlayerHand.Count; i++)
                {
                    if (keepers[i] != Exchanger.PlayerHand[i])
                    {
                        CourtDeck.influences.Add(Exchanger.PlayerHand[i]);
                        Exchanger.PlayerHand.Remove(Exchanger.PlayerHand[i]);
                    }
                }

            }



        }
        public void ShowHand(Player player)
        {
            for (int i = 0; i < player.PlayerHand.Count; i++)
            {
                Console.WriteLine($"{i}. {player.PlayerHand[i]}");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
        public void Tax(Player Duke, Bank amount)
        {
            Duke.Coins += 3;
            amount.balance -= 3;
        }
        public void Income(Player player, Bank amount)
        {
            player.Coins += 1;
            amount.balance -= 1;
        }
        public void ForeignAid(Player player, Bank amount)
        {
            player.Coins += 2;
            amount.balance -= 2;
        }
        public void Coup(Player killer, Player victim, Bank amount)
        {
            killer.Coins -= 7;
            amount.balance += 7;


            if (victim.PlayerHand.Count >= 2)
            {
                Console.WriteLine("Pass to the person you are killing.\n Press any key when victim is ready.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"0. {victim.PlayerHand[0]} \n 1. {victim.PlayerHand[1]}");
                string victimChoice = Console.ReadLine();
                int victimNum = Int32.Parse(victimChoice);
                victim.PlayerHand.RemoveAt(victimNum);
            }
            else
            {
                victim.PlayerHand.Clear();
            }
        }




    }
}

