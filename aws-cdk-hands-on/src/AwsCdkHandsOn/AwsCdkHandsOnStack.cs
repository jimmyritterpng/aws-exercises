using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Constructs;

namespace AwsCdkHandsOn
{
	public class AwsCdkHandsOnStack : Stack
	{
		internal AwsCdkHandsOnStack(Construct scope, string id, string stage, IStackProps props = null) : base(scope,
			id, props)
		{
			_ = new Bucket(this, $"cdkhandson-jimmy-{stage}", new BucketProps
			{
				Cors = new ICorsRule[]
				{
					new CorsRule
					{
						AllowedMethods = new[] { HttpMethods.GET },
						AllowedOrigins = new[] { "my_random_website" },
						AllowedHeaders = new[] { "*" }
					}
				}
			});
		}
	}
}