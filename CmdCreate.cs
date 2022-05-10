using MCGalaxy;
using MCGalaxy.Commands;
using System;
namespace MCGalaxy
{

    public sealed class CmdCreate : Command
    {
        public override string name { get { return "Create"; } }
		public override string shortcut { get { return "Create"; } }
		public override string type { get { return "other"; } }
		public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message)
        {
            string[] args = message.SplitSpaces();

            
            Command.Find("cuboid").Use(null, "1");
            Command.Find("mark").Use(null, args[0] + " " + args[4] + " " + args[1]);
            Command.Find("mark").Use(null, args[2] + " " + args[4] + " " + args[3]);
        
        }
        public override void Help(Player p) {

            p.Message("%T/RNG [min] [max], /rng [min] [max]");
            p.Message("%HGenerates a random number between [min] and [max]");
        }

    }

}