using Microsoft.Extensions.Configuration;
using CatFactory.Dapper;
using CatFactory.PostgreSql;
using CatFactory.ObjectRelationalMapping;

namespace CinemaTicketBooking.CatFactory.Dapper
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ConfigurationBuilder configurationBuilder = new();
			configurationBuilder
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);

			IConfiguration configuration = configurationBuilder.Build();

			DatabaseImportSettings databaseImportSettings = new()
			{
				ConnectionString = configuration["ConnectionStrings:DefaultConnection"],
				ImportViews = true, ImportTables = true, ImportSequences = true,
			};

			PostgreSqlDatabaseFactory postgreSqlDatabaseFactory = new()
			{
				DatabaseImportSettings = databaseImportSettings,
			};

			Database database = postgreSqlDatabaseFactory.Import();

			DapperProject dapperProject = new()
			{
				Name = "CinemaTicketBooking.Server.Scaffolds.Models",
				Database = database,
				OutputDirectory = Path.Combine(TryGetSolutionDirectoryInfo()?.FullName ?? "", "CinemaTicketBooking.Server", "Scaffolds", "Models")
			};

			dapperProject.GlobalSelection(dapperProjectSettings =>
			{
				dapperProjectSettings.ForceOverwrite = true;
				dapperProjectSettings.AddPagingForGetAllOperation = true;
			});

			//dapperProject.Selection("public.movies",
			//dapperProjectSettings => dapperProjectSettings.AddPagingForGetAllOperation = true);

			dapperProject.BuildFeatures();

			//dapperProject.ScaffoldingDefinition += (source, args) =>
			//{
			//};

			//dapperProject.ScaffoldedDefinition  += (source, args) =>
			//{
			//};

			dapperProject.ScaffoldEntityLayer().ScaffoldDataLayer();
		}

		public static DirectoryInfo? TryGetSolutionDirectoryInfo(string? currentPath = null)
		{
			DirectoryInfo? directory = new(
				currentPath ?? Directory.GetCurrentDirectory());
			while (directory != null && !directory.GetFiles("*.sln").Any())
			{
				directory = directory.Parent;
			}
			return directory;
		}
	}
}