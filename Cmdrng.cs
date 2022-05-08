using MCGalaxy;
using System;
namespace McGalaxy
{

    public sealed class CmdRNG : Command
    {
        public override string name { get { return "RNG"; } }
		public override string shortcut { get { return "rng"; } }
		public override string type { get { return "other"; } }
		public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message)
        {
            string[] args = message.SplitSpaces(2);
            var min = int.Parse(args[0]);
            var max = int.Parse(args[1]);
            Random rnd = new Random();
            var gen = rnd.Next(min, max);
            string rng = gen.ToString();
            p.Message("%f" + rng);
            p.Message("%fGenerated from " + min + " - " + max);
        }

        public override void Help(Player p) {

            p.Message("%T/RNG [min], /rng [max]");
            p.Message("%HGenerates a random number between [min] and [max]");
        }

    }
}