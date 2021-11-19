

using System.Collections.Generic;

namespace WindowsFormsApp1.Entities
{
    public class Actions
    {
        public Action1[] Action1 { get; set; }
    }

    public class Action1
    {
        public Action[] Action { get; set; }
    }

    public class Action
    {
        public int actorCellId { get; set; }
        public int championId { get; set; }
        public bool completed { get; set; }
        public int id { get; set; }
        public bool isAllyAction { get; set; }
        public bool isInProgress { get; set; }
        public int pickTurn { get; set; }
        public string type { get; set; }
    }
}
