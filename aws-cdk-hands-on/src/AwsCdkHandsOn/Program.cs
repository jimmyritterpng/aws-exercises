using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwsCdkHandsOn
{
	sealed class Program
	{
		public static void Main(string[] args)
		{
			var app = new App();
			new AwsCdkHandsOnStack(app, $"cdkhandson-jimmy-{Stages.Dev}", Stages.Dev, new StackProps());
			new AwsCdkHandsOnStack(app, $"cdkhandson-jimmy-{Stages.Qa}", Stages.Qa, new StackProps());
			app.Synth();
		}
	}

	public static class Stages
	{
		public static string Dev => "Dev";
		public static string Qa => "QA";
	}
}