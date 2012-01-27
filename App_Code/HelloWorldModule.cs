using System;
using System.Collections.Generic;
using System.Web;
using Nancy;
using Simple.Data;

/// <summary>
/// Summary description for HelloWorldModule
/// </summary>
public class HelloWorldModule : NancyModule
{	
	public HelloWorldModule()
	{
		Get["/"] = parameters => {
			return "Hello, Intermark!";
		};
		
		Get["/test"] = parameters => {
			return "This is the Test route";
		};

	}
}
