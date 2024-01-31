using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample8_01.Shared.Models
{
    public class BoardsVM
    {
        public IEnumerable<Board> boards { get; set; }
        public string Keyword { get; set; }
        public PageInfo Page { get; set; }
    }
}
