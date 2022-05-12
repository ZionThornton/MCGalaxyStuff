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

            
            Command.Find("cuboid").Use(p, "1");
            Command.Find("mark").Use(p, args[0] + " " + args[4] + " " + args[1]);
            Command.Find("mark").Use(p, args[2] + " " + args[4] + " " + args[3]);
        
        }
        public override void Help(Player p) {

            p.Message("%T/Create [StartX] [StartY] [StartZ] [EndX] [EndY] [EndZ]");
            p.Message("%HGenerates a Cuboid that automatically places a mark");
	    p.Message("depending on [StartX] [StartY] [StartZ] [EndX] [EndY] [EndZ]");
        }

    }

}
