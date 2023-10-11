namespace Laboratorium2.Models
{
    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? x { get; set; }
        public double? y { get; set; }

        public string stringOperator {
            get
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return "+";
                    case Operators.Sub:
                        return "-";
                    case Operators.Div:
                        return "/";
                    case Operators.Mul:
                        return "*";
                    default: return "xd";
                }
            }
            }  

        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.Add:
                    return (double)(x + y);
                case Operators.Sub:
                    return (double)(x - y);
                case Operators.Div:
                    return (double)(x / y);
                case Operators.Mul:
                    return (double)(x * y);
                default: return double.NaN;
            }
        }

        public bool IsValid()
        {
            return Operator != null && y != null && x != null;
        }
    }
}
    