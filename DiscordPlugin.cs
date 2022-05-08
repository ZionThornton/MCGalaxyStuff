using MCGalaxy;

namespace MCGalaxy {
    public sealed class Discord : Plugin{

        public override string name {get {return "Discord Plugin";}}
        public override string creator {get {return "PlayerZ";}}
        public override string MCGalaxy_Version {get {return "1.9.3.6;";}}

        public override void Load(bool startup) {
        Command.Register(new CmdDiscord());
        Command.Register(new CmdSetDiscord());
        }

        public override void Unload(bool shutdown) {
        Command.Unregister(Command.Find("Discord"));
        Command.Unregister(Command.Find("SetDiscord"));
        }

        public class CmdSetDiscord : Command {
            public override string name {get {return "Discord";}}
            public override string shortcut {get {return "setdiscord"; }}
            public override string type {get {return "Extra";}}
            public override LevelPermission defaultRank {get {return LevelPermission.Nobody;}}

            public override void Use(Player p, string message) {
                string[] args = message.SplitSpaces(1);
                var link = args[0];
                p.Message("%FThe Discord link for this server was changed to " + link);
            }

            public override void Help(Player p) {
                p.Message("%T/setdiscord");
                p.Message("%HSets the Discord Link");
            }

        }

        public class CmdDiscord : Command {
            public override string name { get {return "Discord";}}
            public override string shortcut { get {return "";}}
            public override string type { get { return "Extra";}}
            public override LevelPermission defaultRank { get {return LevelPermission.Banned;}}
    
            public override void Use(Player p, string message) {
                ref var link();
                p.Message("%FThe Discord Link For This Server Is " + link);  //Discord link needs to be inserted here. Anything inside the quotations is editable.
            }   

            public override void Help(Player p) {
                p.Message("%T/Discord");
                p.Message("%HDisplays the Discord link for the server");

            }
        }
    }  

}