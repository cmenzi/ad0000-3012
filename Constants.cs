namespace MyNamespace
{
    using System.Text.RegularExpressions;

    internal class Constants
    {
        public static readonly Regex UnhashedNameIdRegex = new Regex(@"^[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}_[a-zA-z0-9_\-\.]+_.+$", RegexOptions.Compiled);
    }
}
