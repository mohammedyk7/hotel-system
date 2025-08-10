using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        void LeaveReview(Review review);
        List<Review> GetAllReviews();
        List<Review> GetReviewsForRoom(int roomId);
    }
}
