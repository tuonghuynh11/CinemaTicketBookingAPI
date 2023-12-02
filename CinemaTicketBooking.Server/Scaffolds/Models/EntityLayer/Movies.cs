using System;

namespace CinemaTicketBooking.Server.Scaffolds.Models.EntityLayer
{
	public class Movies : IEntity
	{
		public Movies()
		{
		}

		public Movies(long id)
		{
			Id = id;
		}

		public bool Adult { get; set; }

		public string? BackdropPath { get; set; }

		public string? BelongsToCollection { get; set; }

		public long Budget { get; set; }

		public object Genres { get; set; } = null!;

		public string Homepage { get; set; } = null!;

		public long Id { get; set; }

		public string ImdbId { get; set; } = null!;

		public string OriginalLanguage { get; set; } = null!;

		public string OriginalTitle { get; set; } = null!;

		public string Overview { get; set; } = null!;

		public object Popularity { get; set; } = null!;

		public string PosterPath { get; set; } = null!;

		public object ProductionCompanies { get; set; } = null!;

		public object ProductionCountries { get; set; } = null!;

		public string ReleaseDate { get; set; } = null!;

		public long Revenue { get; set; }

		public long Runtime { get; set; }

		public object SpokenLanguages { get; set; } = null!;

		public string Status { get; set; } = null!;

		public string Tagline { get; set; } = null!;

		public string Title { get; set; } = null!;

		public bool Video { get; set; }

		public object VoteAverage { get; set; } = null!;

		public long VoteCount { get; set; }

		public object Casting { get; set; } = null!;

		public object Directors { get; set; } = null!;

		public DateTime CreatedTimestamp { get; set; }

		public DateTime UpdatedTimestamp { get; set; }

	}
}
