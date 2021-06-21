using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;
        private readonly IValidator validator;

        public CardsController(ICardsService cardsService, IValidator validator)
        {
            this.cardsService = cardsService;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.cardsService.GetAll();

            return this.View(cards);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel input)
        {
            if (!this.validator.ValidateCardAdd(input))
            {
                return this.Redirect("/Cards/Add");
            }

            this.cardsService.Create(input);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.cardsService.IsCardAllreadyAdded(cardId, userId))
            {
                return this.Redirect("/Cards/All");
            }

            this.cardsService.AddCardToCollection(cardId, userId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            this.cardsService.RemoveCardFromCollection(cardId, userId);

            return this.Redirect("/Cards/Collection");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var cards = this.cardsService.GetAll(userId);

            return this.View(cards);
        }

    }
}
