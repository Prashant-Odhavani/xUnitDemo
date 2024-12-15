using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitDemo.Api.Models;

namespace xUnitDemo.UnitTests.Fixtures
{
    public static class FanFixture
    {
        public static List<Fan> GetFans()
        {
            return new List<Fan>()
            {
                new Fan()
                {
                    Email = "testUser1@yopmail.com",
                    Id = 1,
                    Name = "TestUser1",
                },
                new Fan()
                {
                    Email = "testUser2@yopmail.com",
                    Id = 2,
                    Name = "TestUser2",
                }
            };
        }
    }
}
