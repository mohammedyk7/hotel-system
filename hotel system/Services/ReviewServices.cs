using HotelManagementSystem.Models;
using HotelManagementSystem.Data;

namespace HotelManagementSystem.Services
{
    public class ReviewServices
    {
        private readonly AppDbContext _context;

        public ReviewServices(AppDbContext context)
        {
            _context = context;
        }

        public void LeaveReview(int guestId, int roomId, int rating, string comment)
        {
            var review = new Review
            {
                GuestId = guestId,
                RoomId = roomId,
                Rating = rating,
                Comment = comment,
                Date = DateTime.Now
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

        public List<Review> GetReviewsForRoom(int roomId)
        {
            return _context.Reviews.Where(r => r.RoomId == roomId).ToList();
        }
    }
}
