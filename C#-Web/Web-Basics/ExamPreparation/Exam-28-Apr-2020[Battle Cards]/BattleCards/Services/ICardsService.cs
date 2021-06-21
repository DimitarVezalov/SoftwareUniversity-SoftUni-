using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void Create(AddCardInputModel model);

        ICollection<AllCardsViewModel> GetAll();

        ICollection<AllCardsViewModel> GetAll(string userId);

        void AddCardToCollection(int cardId, string userId);

        void RemoveCardFromCollection(int cardId, string userId);

        bool IsCardAllreadyAdded(int cardId, string userId);
    }
}
