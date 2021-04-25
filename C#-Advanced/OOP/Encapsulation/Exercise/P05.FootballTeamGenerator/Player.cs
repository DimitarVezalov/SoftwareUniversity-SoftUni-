using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Player
    {
        private const int STATS_MIN_VALUE = 0;
        private const int STATS_MAX_VALUE = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                this.ValidateStatsProperty(value, nameof(this.Endurance));
                this.endurance = value;
            }

        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                this.ValidateStatsProperty(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                this.ValidateStatsProperty(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                this.ValidateStatsProperty(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                this.ValidateStatsProperty(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double OverallSkillLevel => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0); 

        private void ValidateStatsProperty(int value, string propertyName)
        {
            if (value < STATS_MIN_VALUE || value > STATS_MAX_VALUE)
            {
                string excMessage = $"{propertyName} should" +
                                    $" be between {STATS_MIN_VALUE} and {STATS_MAX_VALUE}.";
                throw new ArgumentException(excMessage);
            }
        }
    }
}
