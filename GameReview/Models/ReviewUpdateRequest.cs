using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameReview.Models
{
    public class ReviewUpdateRequest
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Platform { get; set; }

        [MaxLength(500)]
        public string Review { get; set; }

        [MaxLength(50)]
        public string Price { get; set; }
    }
}