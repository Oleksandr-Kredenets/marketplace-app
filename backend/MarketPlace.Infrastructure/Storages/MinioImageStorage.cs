using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using MarketPlace.Application.Interfaces;
using MarketPlace.Infrastructure.Options;
namespace MarketPlace.Infrastructure.Storages;
public class MinioImageStorage : IImageStorage
{
    private readonly MinioImageStorageOptions _options;
    private IMinioClient minioClient;

    public MinioImageStorage(IOptions<MinioImageStorageOptions> options)
    {
        _options = options.Value;
        minioClient = new MinioClient()
                         .WithEndpoint(_options.Endpoint)
                         .WithCredentials(_options.AccessKey, _options.SecretKey)
                         .WithSSL(false)
                         .Build();
    }

    public async Task<string> GetImageUrlAsync(string imageName)
    {
        var args = new PresignedGetObjectArgs()
                       .WithBucket(_options.BucketName)
                       .WithObject(imageName)
                       .WithExpiry(60 * 60);
        return await minioClient.PresignedGetObjectAsync(args).ConfigureAwait(false);
    }
    public async void UploadImageSync(string imageObjectName, Stream imageStream)
    {
        PutObjectArgs putObjectArgs = new PutObjectArgs()
                                          .WithBucket(_options.BucketName)
                                          .WithObject(imageObjectName)
                                          .WithStreamData(imageStream)
                                          .WithObjectSize(imageStream.Length);
        
        await minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
    }

    public async void DeleteImageSync(string imageObjectName)
    {
        RemoveObjectArgs removeObjectArgs = new RemoveObjectArgs()
                                               .WithBucket(_options.BucketName)
                                               .WithObject(imageObjectName);
        await minioClient.RemoveObjectAsync(removeObjectArgs).ConfigureAwait(false);
    }
}