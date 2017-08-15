using System;

namespace DecoratorPattern
{
    public enum BeverageSize
    {
        Small,
        Medium,
        Large
    }

    public abstract class Beverage
    {
        private string description;
        private BeverageSize size;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public BeverageSize Size
        {
            get { return size; }
            set { size = value; }
        }

        public Beverage(BeverageSize size)
        {
            this.size = size;
        }

        public virtual double Cost()
        {
            return 0;
        }
    }

    /// <summary>
    /// 調味料装飾器
    /// </summary>
    public abstract class CondimentDecorator : Beverage
    {
        public Beverage beverage;

        public CondimentDecorator(BeverageSize size) : base(size)
        {
            this.Size = size;
        }
    }

    public class Espresso : Beverage
    {
        public Espresso(BeverageSize size) : base(size)
        {
            Description = Size.ToString() + " Espresso";
            Size = size;
        }

        public override double Cost()
        {
            if (Size == BeverageSize.Small)
            {
                return 7.9;
            }
            if (Size == BeverageSize.Medium)
            {
                return 8.9;
            }
            return 9.9;
        }
    }

    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage.Size)
        {
            this.beverage = beverage;
            this.Size = beverage.Size;
            Description = "Milk, " + beverage.Description;
        }

        public override double Cost()
        {
            if (Size == BeverageSize.Small)
            {
                return 0.99 + beverage.Cost();
            }
            if (Size == BeverageSize.Medium)
            {
                return 1.99 + beverage.Cost();
            }
            return 1.99 + beverage.Cost();
        }
    }

    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage.Size)
        {
            this.beverage = beverage;
            this.Size = beverage.Size;
            Description = "Mocha, " + beverage.Description;
        }

        public override double Cost()
        {
            if (Size == BeverageSize.Small)
            {
                return 1.99 + beverage.Cost();
            }
            else if (Size == BeverageSize.Medium)
            {
                return 2.99 + beverage.Cost();
            }
            else
            {
                return 3.99 + beverage.Cost();
            }
        }
    }
}