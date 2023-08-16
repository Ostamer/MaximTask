using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WebApplication3.Controllers;

namespace WebApplication3.Tests
{
	[TestFixture]
	public class StringControllerTests
	{
		private StringController _stringController;

		[SetUp]
		public void Setup()
		{
			var configuration = new ConfigurationBuilder()
				.AddInMemoryCollection(new Dictionary<string, string>
				{
								{ "Settings:Limit", "10" },
								{ "RemoteApiUrl", "https://api.rand.by/v1/integer/?count=1&min=1&max=" },
								{ "BlacklistWords:0", "word" },
								{ "BlacklistWords:1", "worde" }
				})
				.Build();
			_stringController = new StringController(configuration);
		}

		[Test]
		public void TestProcessString_ValidInput()
		{
			var result = _stringController.ProcessString("abc");
			Assert.IsInstanceOf<OkObjectResult>(result);
		}

		[Test]
		public void TestProcessString_BlacklistedInput()
		{
			var result = _stringController.ProcessString("word");
			Assert.IsInstanceOf<BadRequestObjectResult>(result);
		}

		[Test]
		public void TestProcessString_InvalidInput1()
		{
			var result = _stringController.ProcessString("bfchcf3");
			Assert.IsInstanceOf<BadRequestObjectResult>(result);        
		}
		[Test]
		public void TestProcessString_InvalidInput2()
		{
			var result = _stringController.ProcessString("bFchcf");
			Assert.IsInstanceOf<BadRequestObjectResult>(result);
		}
	}
}