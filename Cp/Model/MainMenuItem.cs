using System;

namespace Cp.Model
{
    public class MainMenuItem
    {
        public string Id { get; set; }
        public int Page_Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string Icon { get; set; }
    }
}
