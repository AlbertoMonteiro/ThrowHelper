using System.IO;
using System.Reflection;
using NUnit.Framework;
using System.Linq;
using SharpTestsEx;

namespace ThrowHelper.Inject.Tests
{
    [TestFixture]
    public class ThrowHelperIIlInjectorTest
    {
        private string outputPath;

        [TestCase("TestMethod", 4)]
        [TestCase("TestMethod2", 8)]
        public void Must_Inject_Throw_IfArgumentNull_For_All_Parameters(string methodName, int additionalInstructions)
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            var path = myAssembly.CodeBase.Remove(0, 8);
            var fileInfo = new FileInfo(path);
            outputPath = string.Format("{0}/TempFile.dll", fileInfo.Directory.FullName);
            var ilInjector = new ThrowHelperIilInjector(path, outputPath);

            ilInjector.LoadAssemblyAndGetMethods();
            var instructions = ilInjector.methods.First(x => x.Name.Equals(methodName)).Body.Instructions.Count;
            ilInjector.Inject();

            var currentTotalInstructions = ilInjector.methods.First(x => x.Name.Equals(methodName)).Body.Instructions.Count;

            currentTotalInstructions.Should().Be.EqualTo(instructions + additionalInstructions);
        }

        [TestCase("TestMethod3", 4)]
        [TestCase("TestMethod4", 8)]
        public void Must_Inject_Throw_IfArgumentNull_For_Parameters_With_NotNullAttribute(string methodName, int additionalInstructions)
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            var path = myAssembly.CodeBase.Remove(0, 8);
            var fileInfo = new FileInfo(path);
            outputPath = string.Format("{0}/TempFile.dll", fileInfo.Directory.FullName);
            var ilInjector = new ThrowHelperIilInjector(path, outputPath);

            ilInjector.LoadAssemblyAndGetMethods();
            var instructions = ilInjector.methods.First(x => x.Name.Equals(methodName)).Body.Instructions.Count;
            ilInjector.Inject();

            var currentTotalInstructions = ilInjector.methods.First(x => x.Name.Equals(methodName)).Body.Instructions.Count;

            currentTotalInstructions.Should().Be.EqualTo(instructions + additionalInstructions);
        }

        [Test]
        public void Must_Save_File()
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            var path = myAssembly.CodeBase.Remove(0, 8);
            var fileInfo = new FileInfo(path);
            outputPath = string.Format("{0}/TempFile.dll", fileInfo.Directory.FullName);
            
            var ilInjector = new ThrowHelperIilInjector(path, outputPath);

            ilInjector.LoadAssemblyAndGetMethods();
            ilInjector.Inject();
            ilInjector.Save();

            File.Exists(outputPath).Should().Be.True();
        }

        [TearDown]
        public void DeletaArquivos()
        {
            if (!string.IsNullOrWhiteSpace(outputPath))
                File.Delete(outputPath);
        }
    }
}
