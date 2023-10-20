using CatFactory.Dapper;
using CatFactory.PostgreSql;

namespace CinemaTicketBooking.CatFactory.Dapper
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Create database factory
			var databaseFactory = new PostgreSqlDatabaseFactory
			{
				DatabaseImportSettings = new DatabaseImportSettings
				{
					ConnectionString = "host=ep-sweet-haze-96588968.ap-southeast-1.aws.neon.tech;database=neondb;username=21520147;password=owKWv8iY5hkz;port=5432;",
					ImportViews = true,
					ImportTables = true,
					ImportSequences = true,
				}
			};

			// Import database
			var database = databaseFactory.Import();

			// Create instance of Dapper Project
			var project = new DapperProject
			{
				Name = "CinemaTicketBooking.Scaffold",
				Database = database,
				OutputDirectory = @"CinemaTicketBooking.Scaffold"
			};

			// Apply settings for project
			project.GlobalSelection(settings =>
			{
				settings.ForceOverwrite = true;
				//	settings.UpdateExclusions = new List<string>
				//{ "CreationUser", "CreationDateTime", "Timestamp" };
				//	settings.InsertExclusions = new List<string>
				//{ "LastUpdateUser", "LastUpdateDateTime", "Timestamp" };
			});

			//project.Selection("Sales.OrderHeader",
			//				   settings => settings.AddPagingForGetAllOperation = true);

			// Build features for project, group all entities by schema into a feature
			project.BuildFeatures();

			// Add event handlers to before and after of scaffold

			project.ScaffoldingDefinition += (source, args) =>
			{
				// Add code to perform operations with code builder instance before to create code file
			};

			project.ScaffoldedDefinition += (source, args) =>
			{
				// Add code to perform operations after of create code file
			};

			// Scaffolding =^^=
			project.ScaffoldEntityLayer().ScaffoldDataLayer();
		}
	}
}