using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi.Models
{
	////startup without context
	public class Setting
	{
		public string ConnectionString { get; set; }

		public string Database { get; set; }
	}
}
