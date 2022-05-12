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
            string[] args = message.SplitSpaces(0);
            Random coin = new Random();
            
            if(p.money < 2)
            {
                p.Message("%fYou do not have enough money to use /coinflip");
            }
            


            else 
            {  
                p.SetMoney(p.money - 2); // Payment for the command

                if (args[0] != "heads" || args[0] != "tails" || args[0] != "up" || args[0] != "down" || args[0] == null)
                    p.Message("%fPlease use a valid input. Check %b/help Coinflip%f for more info.");

                else
                    coin.Next(1, 2);
                    int flip = coin;
                    if (coin == 1)
                    {
                        if (args[0] == "heads" || args[0] == "up")
                        {
                            p.SetMoney(p.money + 5);
                        
                        }

                        else
                        {
                            p.Message("%fThe coin landed on tails. You gained no money.");
                        }
                    }

                    if (coin == 2)
                    {
                        if (args[0] == "tails" || args[0] == "down")
                        {
                            p.SetMoney(p.money + 5);
                        }   

                        else
                        {
                            p.Message("%fThe coin landed on heads. You gained no money.");
                        }
                    }
            }
        }
        public override void Help(Player p) {

            p.Message("%T/Coinflip {heads, tails, up, down}, /coinflip {heads, tails, up, down}");
            p.Message("%HFlips a coin. Ensure that lowercase is used.");
        }
    }

}