﻿using BA.MultiMVC.Framework.Core;
using NUnit.Framework;
using BA.MultiMVC.Framework.Caching;

namespace BA.MultiMVC.Framework.IntegrationTests.Caching
{
    [TestFixture]
    public class DefaultCacheServiceTest
    {
        const string Key = "Key";
        const string Expected = "Expected object";
        const string TenantName = "DefaultTenant";
        private const string LanguageCode = "fr";

        [Test]
        public void Add_WithSameContext_ObjectInCacheShouldBeRetrieved()
        {
            //Arrange
            var subject = AddToCache(Key, Expected);

            //Act
            var result = subject.GetObject(Key);

            //Assert
            Assert.AreEqual(Expected, result);

        }

        [Test]
        public void Add_WithDifferentTenant_ObjectInCacheShouldNotBeRetrieved()
        {
            //Arrange
            var subject = AddToCache(Key, Expected);

            //Act
            subject.Context = new TenantContext("DifferentTenant", LanguageCode);
            var result = subject.GetObject(Key);
            
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Add_WithDifferentLanguage_ObjectInCacheShouldNotBeRetrieved()
        {
            //Arrange
            var subject = AddToCache(Key, Expected);

            //Act
            subject.Context = new TenantContext(TenantName, "nl");
            var result = subject.GetObject(Key);

            //Assert
            Assert.IsNull(result);
        }

        private static DefaultCacheService AddToCache(string key, string expected)
        {
            var subject = new DefaultCacheService { Context = new TenantContext(TenantName, LanguageCode) };
            subject.Add(key, expected);
            return subject;
        }
    }
}
