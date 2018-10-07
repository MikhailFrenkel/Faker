using System;
using System.Reflection;
using Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Faker.Test
{
    [TestClass]
    public class FakerTest
    {
        //TODO: вложенность 3+ рекурсия
        private const string Dll_1 = "../../../../Plugins/Plugins/CustomRandom1/bin/Debug/netstandard2.0/CustomRandom1.dll";
        private TestModel _testModel;

        [TestInitialize]
        public void Init()
        {
            IRandom rnd = GetCustomRandom(Dll_1);
            FakerLibrary.Faker faker = new FakerLibrary.Faker(rnd);
            _testModel = faker.Create<TestModel>();
        }

        [TestMethod]
        public void NotNull()
        {
            _testModel.Should().NotBeNull();
        }

        [TestMethod]
        public void Int32IsSet()
        {
            _testModel.Id.Should().BeInRange(Int32.MinValue, Int32.MaxValue);
        }

        [TestMethod]
        public void Int64IsSet()
        {
            _testModel.Number.Should().BeInRange(Int64.MinValue, Int64.MaxValue);
        }

        [TestMethod]
        public void StringIsSet()
        {
            _testModel.Name.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void ICollectionDateTimeNotNull()
        {
            _testModel.Dates.Should().NotBeNull().And.NotContainNulls();
        }

        [TestMethod]
        public void AnotherModelNotNull()
        {
            _testModel.AnotherModel.Should().NotBeNull();
        }

        [TestMethod]
        public void AnotherModelIsSetId()
        {
            _testModel.AnotherModel.Id.Should().BeInRange(Int32.MinValue, Int32.MaxValue);
        }

        [TestMethod]
        public void AnotherModelIsSetDateTime()
        {
            var unexpected = new DateTime();
            _testModel.AnotherModel.DateTime.Should().NotBe(unexpected);
        }

        [TestMethod]
        public void AnotherModelStringIsSet()
        {
            _testModel.AnotherModel.Name.Should().NotBeNullOrEmpty();
        }

        private IRandom GetCustomRandom(string pathDll)
        {
            var asm = Assembly.LoadFrom(pathDll);
            foreach (var type in asm.GetTypes())
            {
                if (type.GetInterface(typeof(IRandom).FullName) != null)
                {
                    return (IRandom)Activator.CreateInstance(type);
                }
            }

            return null;
        }
    }
}
