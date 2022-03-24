using System.ComponentModel.DataAnnotations;

namespace noteTaker
{
    public class note
    {
        public int id { get; set; }
        public string title { get; set; }
        public string noteText { get; set; }
    }
}
