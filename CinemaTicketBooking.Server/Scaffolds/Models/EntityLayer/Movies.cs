using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Movies : IEntity
	{
		public Movies()
		{
		}

		public Movies(long? id)
		{
			Id = id;
		}

		public bool? Adult { get; set; }

		public string BackdropPath { get; set; }

		public string BelongsToCollection { get; set; }

		public long? Budget { get; set; }

		public object Genres { get; set; }

		public string Homepage { get; set; }

		public long? Id { get; set; }

		public string ImdbId { get; set; }

		public string OriginalLanguage { get; set; }

		public string OriginalTitle { get; set; }

		public string Overview { get; set; }

		public object Popularity { get; set; }

		public string PosterPath { get; set; }

		public object ProductionCompanies { get; set; }

		public object ProductionCountries { get; set; }

		public string ReleaseDate { get; set; }

		public long? Revenue { get; set; }

		public long? Runtime { get; set; }

		public object SpokenLanguages { get; set; }

		public string Status { get; set; }

		public string Tagline { get; set; }

		public string Title { get; set; }

		public bool? Video { get; set; }

		public object VoteAverage { get; set; }

		public long? VoteCount { get; set; }

		public object Casting { get; set; }

		public object Directors { get; set; }

		public DateTime? CreatedTimestamp { get; set; }

		public DateTime? UpdatedTimestamp { get; set; }

	}
}
