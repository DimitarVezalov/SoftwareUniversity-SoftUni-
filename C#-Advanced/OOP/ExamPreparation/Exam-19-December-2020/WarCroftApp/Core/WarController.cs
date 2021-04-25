using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Character> party;
		private readonly List<Item> itemPool;

		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string type = args[0];
			string name = args[1];

			Character character = null;

            if (type == nameof(Warrior))
            {
				character = new Warrior(name);
            }
            else if (type == nameof(Priest))
            {
				character = new Priest(name);
            }
            else
            {
				throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, type));
			}

			party.Add(character);

			return String.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string type = args[0];

			Item item = null;

            if (type == nameof(HealthPotion))
            {
				item = new HealthPotion();
            }
            else if (type == nameof(FirePotion))
            {
				item = new FirePotion();
            }
            else
            {
				throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, type));
            }

			itemPool.Add(item);

			return String.Format(SuccessMessages.AddItemToPool, type);
		}

		public string PickUpItem(string[] args)
		{
			string name = args[0];

			Character character = this.party.FirstOrDefault(c => c.Name == name);

			CheckCharacter(name, character);

            if (!this.itemPool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = this.itemPool.Last();
			character.Bag.AddItem(item);

			//???Remove item from pool
			//this.itemPool.RemoveAt(this.itemPool.Count -1);

			return String.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemType = args[1];

			Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			Item item = character.Bag.GetItem(itemType);

			character.UseItem(item);

			return String.Format(SuccessMessages.UsedItem, characterName, itemType);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (var character in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
				string status = character.IsAlive ? "Alive" : "Dead";

				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}" +
					$", AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
        {
			StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string defenderName = args[1];

            Character attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
            Character defender = this.party.FirstOrDefault(c => c.Name == defenderName);

			CheckCharacter(attackerName, attacker);
            CheckCharacter(defenderName, defender);

			Type type = attacker.GetType();

            if (type.GetInterfaces().Any(x => x.Name == nameof(IAttacker)))
            {
				IAttacker attackerWarrior = attacker as IAttacker;

				attackerWarrior.Attack(defender);
				
				sb.AppendLine(String.Format(SuccessMessages.AttackCharacter, attackerName,
					defenderName, attacker.AbilityPoints, defenderName, defender.Health,
					defender.BaseHealth, defender.Armor, defender.BaseArmor));


				if (!defender.IsAlive)
                {
					sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, defenderName));
                }
            }
            else
            {
				throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }

			return sb.ToString().TrimEnd();
        }

        private void CheckCharacter(string characterName, Character character)
        {
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
        }

        public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = this.party.FirstOrDefault(c => c.Name == healerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

			CheckCharacter(healerName, healer);
			CheckCharacter(receiverName, receiver);

			Type type = healer.GetType();

            if (type.GetInterfaces().Any(x => x.Name == nameof(IHealer)))
            {
				IHealer healerCharacter = healer as IHealer;

				healerCharacter.Heal(receiver);

				return String.Format(SuccessMessages.HealCharacter,healerName, receiverName,
					healer.AbilityPoints, receiverName, receiver.Health);
            }
            else
            {
				throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
		}
	}
}
