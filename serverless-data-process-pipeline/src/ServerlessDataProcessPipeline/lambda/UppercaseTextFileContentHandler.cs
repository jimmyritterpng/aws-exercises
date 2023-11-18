using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.S3Events;

namespace ServerlessDataProcessPipeline
{
	public class UppercaseTextFileContent
	{
		public async Task UppercaseTextFileContentHandler(S3Event s3Event, ILambdaContext context)
		{
			foreach (var record in s3Event.Records)
			{
				var bucketName = record.S3.Bucket.Name;
				var s3FileKey = record.S3.Object.Key;

				
				
				await Task.CompletedTask;
			}
		}
	}
}