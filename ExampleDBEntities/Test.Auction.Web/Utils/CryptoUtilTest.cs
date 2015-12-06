using Auction.Web.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Auction.Web.Utils
{
    [TestClass]
    public class CryptoUtilTest
    {
        private const string Password = "123";
        private readonly CryproUtil _cryptoUtil;

        public CryptoUtilTest()
        {
            _cryptoUtil = new CryproUtil();
        }

        [TestMethod]
        public void StringToSameHashedStringShouldReturnSuccess()
        {
            Assert.IsTrue(_cryptoUtil.EqualsTo(Password, _cryptoUtil.HashText(Password), _cryptoUtil.Salt));
        }

        [TestMethod]
        public void StringToAcotherHashedStringShouldReturnError()
        {
            Assert.IsFalse(_cryptoUtil.EqualsTo(Password, _cryptoUtil.HashText("456"), _cryptoUtil.Salt));
        }
    }
}
