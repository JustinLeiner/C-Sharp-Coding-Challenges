using System;
using System.Text;

namespace AcmeFlix
{
	public class MovieManagement : IEquatable<MovieManagement?>
    {
        public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Director { get; set; } = string.Empty;

		public string ReleaseDate { get; set; } = string.Empty;

        public List<String> Tags { get; set; } = new List<string>();

        public int ReviewCount { get; set; }

       // public double AvgNumReviews { get; set; }


        public bool Equals(MovieManagement other)
        {
            if (other == null)
                return false;

            if (this.Name.ToLower().Trim() == other.Name.ToLower().Trim()
                && this.Director.ToLower().Trim() == other.Director.ToLower().Trim()
                && this.ReleaseDate.ToLower().Trim() == other.ReleaseDate.ToLower().Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            MovieManagement movieObj = obj as MovieManagement;
            if (movieObj == null)
                return false;
            else
                return Equals(movieObj);
        }

        public override int GetHashCode()
        {
            return this.Name.Concat(Director).Concat(ReleaseDate).GetHashCode();
        }

        /*

        public double MovieAVG ()
        {
            int average = movies.ForEach(i => counter+= i));
            return 
        }
        */

        /*
        public double avg(MovieManagement movies)
        {
            AvgNumReviews = movies.Average(movieC => movieC.ReviewCount);


            return AvgNumReviews;
        }
        */

        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Id = {0}, Name = {1}, Director = {2}, Release Date = {3}", this.Id, this.Name, this.Director, this.ReleaseDate);

            return builder.ToString();
        }

    }
}

