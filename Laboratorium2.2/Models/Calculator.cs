namespace Laboratorium2._2.Models
{
    public enum Operators
    {
        Add, Mul, Sub, Div
    }

    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public string Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return "+";
                    case Operators.Mul:
                        return "*";
                    case Operators.Sub:
                        return "-";
                    case Operators.Div:
                        return "/";
                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate()
        {
            if (IsValid())
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return (double)(X + Y);
                    case Operators.Mul:
                        return (double)(X * Y);
                    case Operators.Sub:
                        return (double)(X - Y);
                    case Operators.Div:
                        if (Y != 0)
                        {
                            return (double)(X / Y);
                        }
                        else
                        {
                            throw new DivideByZeroException("Division by zero is not allowed.");
                        }
                    default:
                        throw new InvalidOperationException("Invalid operator.");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid input. Please enter valid numbers and operator.");
            }
        }
    }
}
