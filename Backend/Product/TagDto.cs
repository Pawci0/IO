using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule
{
    public class TagDto
    {
        public int tagId { get; set; }
        public string name { get; set; }

        public TagDto()
        {
        }

        public TagDto(int tagId, string name)
        {
            this.tagId = tagId;
            this.name = name;
        }
    }
}
