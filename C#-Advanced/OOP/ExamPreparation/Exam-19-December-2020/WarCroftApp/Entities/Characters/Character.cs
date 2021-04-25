using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double baseHealth;
		private double health;
		private double baseArmor;
		private double armor;


        public  Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = health;
			this.Health = this.BaseHealth;
            this.BaseArmor = armor;
			this.Armor = this.BaseArmor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
        }


		public string Name
		{ 
			get => this.name;
			private set
            {
				if (String.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}

				this.name = value;
            }
		}

        public double BaseHealth
		{
			get => baseHealth;
			private set => baseHealth = value;
		}

        public double Health
        {
			get => this.health;
			set
            {
                if (value <= 0)
                {
					this.IsAlive = false;
					value = 0;
                }

                if (value > this.BaseHealth)
                {
					value = this.BaseHealth;
                }
				this.health = value;
            }
        }

        public double BaseArmor
        {
			get => this.baseArmor;
			private set => this.baseArmor = value;
        }

        public double Armor
        {
			get => this.armor;
			private set
            {
                if (value < 0)
                {
					value = 0;
                }

				this.armor = value;
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
        {
			this.EnsureAlive();

            if (this.Armor > 0)
            {
                if (hitPoints > this.Armor)
                {
					hitPoints -= this.Armor;
					this.Armor = 0;

					this.Health -= hitPoints;
                }
                else
                {
					this.Armor -= hitPoints;
                }
            }
            else
            {
				this.Health -= hitPoints;
			}

			
        }

		public void UseItem(Item item)
        {
			item.AffectCharacter(this);
        }
	}
}