using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCardToCollection(int cardId, string userId)
        {
            var card = this.db.Cards.Find(cardId);
            var user = this.db.Users.Find(userId);

            var userCard = new UserCard
            {
                Card = card,
                User = user
            };

            this.db.UserCards.Add(userCard);
            this.db.SaveChanges();
        }

        public void Create(AddCardInputModel model)
        {
            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Description = model.Description,
                Keyword = model.Keyword,
                Health = model.Health,
                Attack = model.Attack
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();
        }

        public ICollection<AllCardsViewModel> GetAll(string userId)
        {
            var cards = this.db.Cards
                .Where(c => c.UserCards.Select(uc => uc.UserId == userId)
                .FirstOrDefault())
                .Select(c => new AllCardsViewModel
                {
                    CardId = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Keyword = c.Keyword,
                    Health = c.Health,
                    Attack = c.Attack,
                    ImageUrl = c.ImageUrl
                })
                .ToList();

            return cards;
        }

        public ICollection<AllCardsViewModel> GetAll()
        {
            var cards = this.db.Cards
                .Select(c => new AllCardsViewModel 
                {
                    CardId = c.Id,
                    Name = c.Name,
                    Description= c.Description,
                    Keyword = c.Keyword,
                    Health = c.Health,
                    Attack = c.Attack,
                    ImageUrl = c.ImageUrl
                })
                .ToList();

            return cards;
        }

        public bool IsCardAllreadyAdded(int cardId, string userId)
        {
            return this.db.UserCards.Any(x => x.CardId == cardId && x.UserId == userId);           
        }

        public void RemoveCardFromCollection(int cardId, string userId)
        {
            var userCard = this.db.UserCards
                .FirstOrDefault(x => x.CardId == cardId && x.UserId == userId);

            this.db.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
