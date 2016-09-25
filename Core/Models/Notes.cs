using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int DiaryId { get; set; }
        public virtual Diary Diary { get; set; }
    }
}
