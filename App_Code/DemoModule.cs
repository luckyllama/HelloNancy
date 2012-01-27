using System;
using System.Collections.Generic;
using System.Web;
using Nancy;
using Simple.Data;

public class DemoModule : NancyModule {	
	public DemoModule() {

		Get["/"] = parameters => {
			return "Hello, Intermark!";
		};
		
		Get["/test"] = parameters => {
			return "This is the Test route";
		};

	}
}
