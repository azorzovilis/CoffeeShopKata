namespace CoffeeShop.Core.Extensions
{
    using System.Text;

    public static class StringExtensions
    {
        public static string Indent(this string originalString, int indentLevel = 4)
        {
            var indentedString = new StringBuilder();
            indentedString.Append("".PadLeft(indentLevel));
            indentedString.Append(originalString);
            return indentedString.ToString();
        }
    }
}