using System.IO;
using MasterMind;
using MasterMind.data;
using NUnit.Framework;
namespace TestProjectMasterMind
{
    public class Test
    {
        [Test]
        public void LoseTest()
        {
            Assert.IsFalse(UtilitiesMm.WinOrLose(1));
        }
        
        [Test]
        public void WinTest()
        {
            Assert.IsTrue(UtilitiesMm.WinOrLose(4));
        }
        
        [Test]
        public void NewStringSecretLenghtTest()
        {
            Assert.AreEqual(4, UtilitiesMm.NewStringSecret().Length);
        }
        
        [Test]
        public void NewStringSecretCharsTest()
        {
            var secret = UtilitiesMm.NewStringSecret();
            Assert.IsTrue(secret.Contains("A") || secret.Contains("B") || secret.Contains("C") || secret.Contains("D") || secret.Contains("E") || secret.Contains("F"));
        }
        
        [Test]
        public void CheckRightPositionTest()
        {
            var adivinado = "";
            var rightPosition = UtilitiesMm.CheckRightPosition("ABCD", "ADAA", 0,ref adivinado);
            Assert.AreEqual(1, rightPosition);
        }
        
        [Test]
        public void CheckWrongPositionTest()
        {
            var adivinado = "";
            var wrongPosition = UtilitiesMm.CheckWrongPosition("ABCD", "ADAA", 0, adivinado);
            Assert.AreEqual(3, wrongPosition);
        }
        
        [Test]
        public void UpdateFileRankingTest()
        {
            FilesAndDirectorysMm.SetDirectoryMyDocs();
            FilesAndDirectorysMm.UpdateFileRanking("name1", 10);
        }
        
        [Test]
        public void CreateFileJsonTest()
        {
            FilesAndDirectorysMm.SetDirectoryMyDocs();
            FilesAndDirectorysMm.CreateFileJson("ranking.json");
            Assert.IsTrue(File.Exists("ranking.json"));
        }
    }
}