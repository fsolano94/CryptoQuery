using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQueryWebAPI.Models
{
    public class ArticleDto : IEquatable<ArticleDto>
    {
        private string _id = string.Empty;
        public string Id
        {
            set
            {
                if (_id == string.Empty)
                {
                    _id = value;
                }
            }
            get
            {
                return _id;
            }
        }
        public string UpdatedAt { get; set; }
        public string CreatedAt { get; set; }
        public string DateOfPublification { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public int Complexity { get; set; }
        public int Quality { get; set; }

        public bool Equals(ArticleDto other)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (Id == other.Id) && (UpdatedAt == other.UpdatedAt) && ( CreatedAt==other.CreatedAt ) && ( DateOfPublification == other.DateOfPublification ) && ( Author == other.Author ) && ( Url == other.Url ) && ( Title == other.Title ) && ( Topic == other.Topic ) && ( Complexity == other.Complexity ) && ( Quality == other.Quality );
        }
    }
}
