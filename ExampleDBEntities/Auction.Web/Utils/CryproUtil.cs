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

        public bool EqualsTo(string plainText, string hashedText, string salt)
        {
            return Pbkdf2.Compute(plainText, salt).Equals(hashedText);
        }

        public string Salt { get { return Pbkdf2.Salt; }
        }

    }
}