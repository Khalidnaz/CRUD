using System.Collections.Generic;
using GameReview.Models;

namespace GameReview.Service
{
    public interface IReviewService
    {
        int Insert(ReviewRequest model);
        IEnumerable<ReviewDomain> SelectAll();
        void Update(ReviewUpdateRequest model);
        void Delete(int id);
     
    }
}