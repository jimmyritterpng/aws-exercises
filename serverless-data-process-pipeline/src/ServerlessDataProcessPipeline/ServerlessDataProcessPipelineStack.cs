using Amazon.CDK;
using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Notifications;

namespace ServerlessDataProcessPipeline
{
	public class ServerlessDataProcessPipelineStack : Stack
	{
		internal ServerlessDataProcessPipelineStack(Construct scope, string id, IStackProps props = null) : base(scope,
			id, props)
		{
			var inputBucket = CreateS3Bucket(this, "serverlessdataprocesspipeline-inputbucket");
			_ = CreateS3Bucket(this, "serverlessdataprocesspipeline-outputbucket");

			CreateLambdaFunction(this, inputBucket);
		}

		private Bucket CreateS3Bucket(Construct scope, string bucketName)
		{
			// Create an S3 bucket
			var bucket = new Bucket(this, bucketName, new BucketProps
			{
				BucketName = bucketName,
				RemovalPolicy = RemovalPolicy.DESTROY,
				AutoDeleteObjects = true,
				BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
			});

			// Give access only to account owner
			bucket.GrantRead(new AccountRootPrincipal());

			return bucket;
		}

		private void CreateLambdaFunction(Construct scope, Bucket bucket)
		{
			// create lambda that uses C# as runtime
			var function = new Function(this, "serverlessdataprocesspipeline-lambda", new FunctionProps
			{
				FunctionName = "serverlessdataprocesspipeline-lambda",
				Runtime = Runtime.DOTNET_6,
				Code = Code.FromAsset("lambda"),
				Handler =
					"ServerlessDataProcessPipeline::" +
					"ServerlessDataProcessPipeline.UppercaseTextFileContent::" +
					"UppercaseTextFileContentHandler",
				MemorySize = 256,
				Timeout = Duration.Seconds(30),
				Environment = new System.Collections.Generic.Dictionary<string, string>
				{
					{ "INPUT_BUCKET", bucket.BucketName }
				}
			});

			bucket.GrantRead(function);

			// Add S3 trigger
			bucket.AddEventNotification(EventType.OBJECT_CREATED, new LambdaDestination(function),
				new NotificationKeyFilter { Prefix = "", Suffix = ".txt" });
			// grant lambda access to S3 bucket
		}
	}
}