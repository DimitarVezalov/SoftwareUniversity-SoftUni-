namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();
			var games = JsonConvert
				.DeserializeObject<IEnumerable<GameImportDto>>(jsonString);
			foreach (var jsonGame in games)
			{
				if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0)
				{
					// Invalid data
					output.AppendLine("Invalid Data");
					continue;
				}

				// Valid data
				var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre)
					?? new Genre { Name = jsonGame.Genre };
				var developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer)
					?? new Developer { Name = jsonGame.Developer };

				var game = new Game
				{
					Name = jsonGame.Name,
					Genre = genre,
					Developer = developer,
					Price = jsonGame.Price,
					ReleaseDate = jsonGame.ReleaseDate.Value,
				};
				foreach (var jsonTag in jsonGame.Tags)
				{
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag };
					game.GameTags.Add(new GameTag { Tag = tag });
				}

				context.Games.Add(game);
				context.SaveChanges();
				output.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
			}

			return output.ToString();

		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var userDtos = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

			List<User> validUsers = new List<User>();

            foreach (var dto in userDtos)
            {
                if (!IsValid(dto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

                if (dto.Cards.Any(c => IsValid(c) == false))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User
				{
					FullName = dto.FullName,
					Username = dto.Username,
					Email = dto.Email,
					Age = dto.Age
				};

                foreach (var cardDto in dto.Cards)
                {
                    CardType cardType;
                    bool parsedType = Enum.TryParse<CardType>(cardDto.Type, out cardType);

                    if (!parsedType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Card card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    };

                    user.Cards.Add(card);
                }

                validUsers.Add(user);
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
               
            }

			context.Users.AddRange(validUsers);
			context.SaveChanges();

			return sb.ToString().TrimEnd();

		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlSerializer serializer = 
				new XmlSerializer(typeof(PurchaseImportDto[]), new XmlRootAttribute("Purchases"));

			PurchaseImportDto[] dtos;

            using (var reader = new StringReader(xmlString))
            {
				dtos = (PurchaseImportDto[])serializer.Deserialize(reader);
            }

			List<Purchase> validPurchases = new List<Purchase>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				DateTime dateTime;
				bool isDateParsed = DateTime.TryParseExact(dto.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

                if (!isDateParsed)
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				PurchaseType purchaseType;
				bool isPurchaseTypeParsed = Enum.TryParse<PurchaseType>(dto.Type, out purchaseType);

                if (!isPurchaseTypeParsed)
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				Purchase purchase = new Purchase
				{
					Type = purchaseType,
					ProductKey = dto.Key,
					Date = dateTime,
					Card = context.Cards.FirstOrDefault(c => c.Number == dto.Card),
					Game = context.Games.FirstOrDefault(g => g.Name == dto.Title)
				};

				validPurchases.Add(purchase);
				sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

			context.Purchases.AddRange(validPurchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}