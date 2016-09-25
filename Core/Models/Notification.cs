using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SMS { get; set; }
        public string Email { get; set; }
        public int NotesId { get; set; }
        public virtual Notes Notes { get; set; }
    }
}
