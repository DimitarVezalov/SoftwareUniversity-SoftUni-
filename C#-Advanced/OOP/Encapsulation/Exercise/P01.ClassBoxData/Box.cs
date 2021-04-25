using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * (this.Length * this.Width) + 
                    2 * (this.Length * this.Height) + 
                    2 * (this.Width * this.Height);
        }

        public double GetLateralSurfaceArea()
        {
            return  2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
