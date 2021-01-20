﻿using System;
using AutoMapper;
using EventsExpress.Mapping;
using EventsExpress.Test.MapperTests.BaseMapperTestInitializer;
using NUnit.Framework;

namespace EventsExpress.Test.MapperTests
{
    [TestFixture]
    internal class AttitudeMapperProfileTests : MapperTestInitializer<AttitudeMapperProfile>
    {
        [OneTimeSetUp]
        protected virtual void Init()
        {
            Initialize();
        }

        [Test]
        public void AttitudeMapperProfile_Should_HaveValidConfig()
        {
            Configuration.AssertConfigurationIsValid();
        }
    }
}
