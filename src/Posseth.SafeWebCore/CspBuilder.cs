// Michel Posseth 2024/06/22 YYYY/MM/DD
using System.Security.Cryptography;
namespace Posseth.SafeWebCore
{
    public class CspBuilder
    {
        private readonly Dictionary<string, List<string>> _directives = [];
        public string Nonce { get; init; } = GetNonce();
        private static string GetNonce()
        {
            using var rng = RandomNumberGenerator.Create();
            var nonceBytes = new byte[16]; // 128 bits
            rng.GetBytes(nonceBytes);
            return Convert.ToBase64String(nonceBytes);
        }
        public CspBuilder AddDirective(string directive, string policy)
        {
            if (!_directives.TryGetValue(directive, out List<string>? value))
            {
                value = [];
                _directives[directive] = value;
            }

            if (policy.Contains("{nonce}"))
            {
                policy = policy.Replace("{nonce}", $"'nonce-{Nonce}'");
            }

            value.Add(policy);
            return this;
        }
        public override string ToString()
        {
            return string.Join("; ", _directives.Select(d => $"{d.Key} {string.Join(" ", d.Value)}").ToArray());
        }
    }
}