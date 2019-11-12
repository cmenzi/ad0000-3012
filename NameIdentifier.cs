namespace MyNamespace
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    public static class NameIdentifier
    {
        public static string Calculate(Guid agentId, string deviceId, string name)
        {
            return Calculate($"{agentId}_{deviceId}_{name}");
        }

        public static string Calculate(string unhashedNameId)
        {
            if (string.IsNullOrWhiteSpace(unhashedNameId))
            {
                throw new ArgumentNullException(nameof(unhashedNameId), $"{nameof(unhashedNameId)} must not be null, empty or whitespace.");
            }

            if (!Constants.UnhashedNameIdRegex.IsMatch(unhashedNameId))
            {
                throw new ArgumentException($"{nameof(unhashedNameId)} does not match '{Constants.UnhashedNameIdRegex}'.", nameof(unhashedNameId));
            }

            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(unhashedNameId);
                byte[] crypto = sha.ComputeHash(textData);

                var nameId = new StringBuilder();
                foreach (byte hash in crypto)
                {
                    nameId.Append(hash.ToString("x2", CultureInfo.InvariantCulture));
                }

                return nameId.ToString();
            }
        }
    }
}
