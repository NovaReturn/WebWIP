using System.Drawing;

namespace WebApp1.Models
{
    public class Shouts
    {
        public int Id { get; set; }
        public string ShoutEntry { get; set; }

        public DateTime ShoutDate { get; set; }
        public string ShoutName { get; set; }

        public Shouts()
        {
            ShoutDate = DateTime.Now;
            
        }
    }
}
