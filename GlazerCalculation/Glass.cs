using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlazerCalculation
{
    public enum TintType { black, brown, blue };
    public class Glass
    {
        public const double MIN_WIDTH = 0.5;
        public const double MAX_WIDTH = 5.0;
        public const double MIN_HEIGHT = 0.75;
        public const double MAX_HEIGHT = 3.0;


        double width;
        double height;
        TintType tint;
        double woodLength;
        double glassArea;
        DateTime dateOrdered;
        double quantity;

        public Glass(double width, double height, TintType tint, double quantity)
        {
            this.width = width;
            this.height = height;
            this.tint = tint;
            this.woodLength = 2 * (width + height) * 3.25;
            this.glassArea = 2 * (width * height);
            dateOrdered = DateTime.Now;
            this.quantity = quantity;
        }

        public string display()
        {
            return "Width = " + width + "\nHeight = " + height + "\nTint = " + Enum.GetName(typeof(TintType), tint) + 
                "\nQuantity = " + quantity + "\nWood Length = " + woodLength + "\nGlass Area = " + glassArea + 
                "\nDate = " + dateOrdered;
        }

        public void setWidth(double width)
        {
            if (width > MIN_WIDTH && width < MAX_WIDTH)
                this.width = width;
        }

        public double getWidth()
        {
            return width;
        }

        public void setHeight(double height)
        {
            if (height > MIN_HEIGHT && height < MAX_HEIGHT)
                this.height = height;
        }

        public double getHEIGHT()
        {
            return height;
        }

        public void setTint(TintType tint)
        {
            this.tint = tint;
        }

        public TintType getTint()
        {
            return tint;
        }

        public void setQuantity(int quantity)
        {
            if (quantity > 0 && quantity < 11)
            {
                this.quantity = quantity;
            }
        }

        public double getQuantity()
        {
            return quantity;
        }
    }
}
