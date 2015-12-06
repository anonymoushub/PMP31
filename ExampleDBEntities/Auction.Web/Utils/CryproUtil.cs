using SimpleCrypto;

namespace Auction.Web.Utils
{
    public class CryproUtil
    {
        public PBKDF2 Pbkdf2 { get; private set; }

        public CryproUtil()
        {
            Pbkdf2 = new PBKDF2();
        }

        public string HashText(string plainText)
        {
            return Pbkdf2.Compute(plainText);
        }

        public bool EqualsTo(string plainText, string hashedText)
        {
            return Pbkdf2.Compute(plainText, Pbkdf2.Salt).Equals(hashedText);
        }


    }
}