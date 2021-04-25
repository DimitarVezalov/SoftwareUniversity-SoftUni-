namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
        public static object UsersAllDto { get; private set; }

        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genresWithGames = context
				.Genres
				.ToArray()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games
					.Where(ga => ga.Purchases.Any())
					.Select(ga => new
					{
						Id = ga.Id,
						Title = ga.Name,
						Developer = ga.Developer.Name,
						Tags = string.Join(", ", ga.GameTags.Select(gt => gt.Tag.Name).ToArray()),
						Players = ga.Purchases.Count
					})
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id)
					.ToArray(),
					TotalPlayers = g.Games.Sum(x => x.Purchases.Count) 

				})
				.ToArray()
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToArray();

			string json = JsonConvert.SerializeObject(genresWithGames, Formatting.Indented);

			return json;


		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			StringBuilder sb = new StringBuilder();

			XmlSerializer serializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("Users"));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(String.Empty, String.Empty);

			PurchaseType purchaseType = Enum.Parse<PurchaseType>(storeType);

			var data = context.Users.ToList()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new UserExportDto
				{
					Username = x.Username,
					TotalSpent = x.Cards.Sum(
						c => c.Purchases.Where(p => p.Type.ToString() == storeType)
							  .Sum(p => p.Game.Price)),
					Purchases = x.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.Select(p => new PurchaseExportDto
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameExportDto
							{
								Title = p.Game.Name,
								Price = p.Game.Price,
								Genre = p.Game.Genre.Name,
							}
						})
						.OrderBy(x => x.Date)
						.ToArray()
				})
				.OrderByDescending(x => x.TotalSpent).ThenBy(x => x.Username).ToArray();


			using (var writer = new StringWriter(sb))
            {
				serializer.Serialize(writer, data, namespaces);
            }

			return sb.ToString().TrimEnd();
		}
	}
}          