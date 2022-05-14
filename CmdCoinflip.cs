using MCGalaxy;
using System;

namespace MCGalaxy
{
	public sealed class CmdCoinflip : Command
	{
		public override string name { get { return "Coinflip"; } }
		public override string shortcut { get { return "cf"; } }
		public override string type { get { return "other"; } }
		public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

		public override void Use(Player p, string message)
		{
			string[] args = message.SplitSpaces();

			// Check to see if player is a broke boy
			if (p.money < 2)
			{
				p.Message("%SYou do not have enough money to use %T/coinflip");
				return; // Use return here so the code stops
			}

			// Check to see if player has input anything after the command
			// E.g, /coinflip heads
			// If nothing is specified, args.Length will be 0 and we want to cancel the command
			if (args.Length == 0)
			{
				p.Message("%SPlease specify either %Theads %Sor %Ttails");
				return;
			}

			string chosen = args[0].ToLower(); // Optional, but neater

			// Use .ToLower() to fix case-sensitive input. E.g, if player types /coinflip HeAds, it will be converted to /coinflip heads

			// Check to see if player's input DOESN'T contain heads or tails, return if so
			if (chosen != "heads" && chosen != "tails")
			{
				p.Message("%SPlease specify either %Theads %Sor %Ttails");
				return;
			}

			p.SetMoney(p.money - 2); // We want to take the money ONLY after all checks have been completed else player will get scammed

			Random random = new Random(); // Initialize random so we can use it for our 'index' variable
			string[] outcomes = new string[] { "heads", "tails" };

			int index = random.Next(outcomes.Length); // Choose a random index from our 'outcomes' array
			string outcome = outcomes[index]; // Turn the indexed outcome into a string

			p.Message("The coin landed on " + outcome); // Tell player the outcome

			// If player's input matches the outcome, give them some schmackeroos
			if (chosen == outcome)
			{
				p.Message("%SYou gained %b5 %TChips %Sfor winning.");
				p.SetMoney(p.money + 5); // Give schmackeroos to player
			}
		}

		public override void Help(Player p)
		{
			p.Message("%T/Coinflip [Heads/Tails]");
			p.Message("%T/COinflip - Flip a coin for a chance to win Chips");
		}
	}

}
