using Amazon.CDK;

namespace ServerlessDataProcessPipeline
{
	static class Program
	{
		public static void Main(string[] args)
		{
			var app = new App();
			_ = new ServerlessDataProcessPipelineStack(app, "ServerlessDataProcessPipelineStack", new StackProps());
			app.Synth();
		}
	}
}