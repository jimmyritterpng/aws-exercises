# Challenge: Serverless Data Processing Pipeline
### Objective: Create a serverless data processing pipeline that triggers a Lambda function upon file uploads to an S3 bucket. This Lambda function should perform a simple data transformation task (e.g., converting the file content to uppercase) and store the result in another S3 bucket.

#### Task Breakdown:

1. Set Up Two S3 Buckets:
- Input Bucket: For users to upload files.
- Output Bucket: To store the processed files.

2. Create a Lambda Function:

- This function should be triggered when a new file is uploaded to the Input Bucket.
- It reads the file, transforms the content (e.g., convert text to uppercase), and writes the transformed content to the Output Bucket.
- Use C# for the Lambda function code. 

3. Implement IAM Roles:
- Ensure the Lambda function has the necessary permissions to read from the Input Bucket and write to the Output Bucket.

4. Use AWS CDK for Deployment:
- Write a CDK script in C# to create the S3 buckets, the Lambda function, and the necessary IAM roles and policies.
- Ensure all resources are tagged properly for easy identification.
5. Logging and Monitoring:
- Implement basic logging for the Lambda function to record the processing of files.
- (Optional) Set up a simple CloudWatch dashboard or alarms to monitor the Lambda function’s execution and performance.

#### Constraints:
- Cost Management: Use the AWS Free Tier where possible. Be mindful of the number of executions, data transfer, and storage used to stay within the free tier limits.
- Security: Ensure the buckets are not publicly accessible.
- Idempotency: The CDK script should be idempotent, meaning running it multiple times should not create additional resources if they already exist.

#### Deliverables:
- The C# .NET CDK code for deploying the architecture.
- The Lambda function code in C#.
- Documentation or comments in the code explaining your approach and any assumptions.

#### Testing:
- Manually upload a text file to the Input Bucket.
- Verify that the Lambda function processes the file and stores the result in the Output Bucket.
- Check the logs for any errors or confirmation of successful execution.