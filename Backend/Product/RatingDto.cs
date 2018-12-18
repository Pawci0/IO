using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class RatingDto
    {
        public int ratingId { get; set; }
        public int productId { get; set; }
        public int userId { get; set; }
        public int value { get; set; }
        public string comment { get; set; }

        public RatingDto()
        {
        }

        public RatingDto(int ratingId, int productId, int userId, int value, string comment)
        {
            this.ratingId = ratingId;
            this.productId = productId;
            this.userId = userId;
            this.value = value;
            this.comment = comment;
        }
    }
}
