using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class RatingService
    {
        private DBManager db;

        public RatingService()
        {
            db = new DBManager();
        }

        public RatingDto GetRating(int id)
        {
            Database.Rating rating = db.GetRatingById(id);
            if (rating != null)
            {
                return new RatingDto(rating.Rating_Id, rating.Product_Id, 
                    rating.User_id, rating.Value, rating.Comment);
            }
            return null;
        }

        public void CreateRating(RatingDto rating)
        {
            db.CreateRating(rating.productId, rating.userId, rating.value, 
                rating.comment);
        }

        public void UpdateRating(RatingDto rating)
        {
            db.UpdateRatingById(rating.ratingId, rating.productId, rating.userId, rating.value,
                rating.comment);
        }

        public void DeleteRating(int id)
        {
            db.DeleteRatingById(id);
        }
    }
}
