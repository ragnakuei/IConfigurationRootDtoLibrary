using FluentAssertions;
using IConfigurationRootDtoLibrary;
using IConfigurationRootDtoLibraryTest.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace IConfigurationRootDtoLibraryTest
{
    public class IConfigurationRootDtoLibraryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OnePropertyString()
        {
            var target = new ConfigurationBuilder()
                        .AddJsonFile("onePropertyString.json", false, true)
                        .Build();

            var actual = target.Get<OnePropertyStringConfig>();

            var expected = new OnePropertyStringConfig
                           {
                               Option1 = "Value1",
                           };

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void OnePropertyInt()
        {
            var target = new ConfigurationBuilder()
                        .AddJsonFile("onePropertyInt.json", false, true)
                        .Build();

            var actual = target.Get<OnePropertyIntConfig>();

            var expected = new OnePropertyIntConfig
                           {
                               Option2 = 2,
                           };

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void OnePropertyNullInt()
        {
            var target = new ConfigurationBuilder()
                        .AddJsonFile("onePropertyNullInt.json", false, true)
                        .Build();

            var actual = target.Get<OnePropertyNullIntConfig>();

            var expected = new OnePropertyNullIntConfig
                           {
                               Option2 = null,
                           };

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void OnePropertyObject()
        {
            var target = new ConfigurationBuilder()
                        .AddJsonFile("onePropertyObject.json", false, true)
                        .Build();

            var actual = target.Get<OnePropertyObjectConfig>();

            var expected = new OnePropertyObjectConfig
                           {
                               A = new AOption
                                   {
                                       A1 = "AA"
                                   },
                           };

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void OnePropertyArray()
        {
            var target = new ConfigurationBuilder()
                        .AddJsonFile("onePropertyArray.json", false, true)
                        .Build();

            var actual = target.Get<OnePropertyArrayConfig>();

            var expected = new OnePropertyArrayConfig
                           {
                               B = new[]
                                   {
                                       new BOption
                                       {
                                           Name = "Gandalf",
                                           Age  = 1000,
                                       },
                                       new BOption
                                       {
                                           Name = "Harry",
                                           Age  = 17,
                                       },
                                   }
                           };

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void AllProperty()
        {
            var target = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", false, true)
                        .Build();

            var actual = target.Get<AppSettingsConfig>();

            var expected = new AppSettingsConfig()
                           {
                               Option1 = "Value1",
                               Option2 = 2,
                               A = new AOption
                                   {
                                       A1 = "AA"
                                   },
                               B = new[]
                                   {
                                       new BOption
                                       {
                                           Name = "Gandalf",
                                           Age  = 1000,
                                       },
                                       new BOption
                                       {
                                           Name = "Harry",
                                           Age  = 17,
                                       },
                                   }
                           };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
