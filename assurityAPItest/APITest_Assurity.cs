using System;
using AssurityAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace assurityapitest
{
    [TestClass]
    public class APITest_Assurity
    {
        public Category Category { get; set; }

        public APITest_Assurity()
        {
            Category = AssurityAPI.AssurityApiService.GetCategory();
        }

        [TestMethod]
        public void CheckCategoryExist()
        {
            Assert.IsNotNull(Category);
        }

        [TestMethod]
        public void CheckName()
        {
            Assert.AreEqual(Category?.Name, "Badges");
        }

        [TestMethod]
        public void CheckCanListClassifieds()
        {
            Assert.IsTrue(Category?.CanListClassifieds == false);
        }

        [TestMethod]
        public void CheckCharitiesTagLine()
        {
            var charities = Category?.Charities?.ToList();
            var charity = charities?.FirstOrDefault(x => x.Description.Contains("Plunket") && x.Tagline.Contains("well child health services"));
            Assert.IsNotNull(charity);
        }
    }
}
