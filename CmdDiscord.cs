using MCGalaxy;

namespace MCGalaxy {

    public sealed class CmdDiscord : Command {
        public override string name { get {return "Discord";}}
        public override string shortcut { get {return "";}}
        public override string type { get { return "Extra";}}
        public override LevelPermission defaultRank { get {return LevelPermission.Banned;}}
    
        public override void Use(Player p, string message) {
            p.Message("%FThe Discord Link For This Server Is <insert discord link here>");  //Discord link needs to be inserted here. Anything inside the quotations is editable.
        }   

        public override void Help(Player p) {
            p.Message("%T/Discord");
            p.Message("%HDisplays the Discord link for the server");

        }
    }  

}