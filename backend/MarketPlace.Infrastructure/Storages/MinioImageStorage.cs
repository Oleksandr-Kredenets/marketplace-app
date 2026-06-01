using System.Threading.Tasks;
using MarketPlace.Infrastructure.Interfaces;
using MarketPlace.Infrastructure.Collections;
using Minio;
using Minio.DataModel.Args;
namespace MarketPlace.Infrastructure.Storages;
public class MinioImageStorage : IImageStorage
{
    private string endpoint;
    private string bucketName;
    private IMinioClient minioClient;

    public MinioImageStorage()
    {
        endpoint = "localhost:9000";
        bucketName = "product-images";
        minioClient = new MinioClient()
                         .WithEndpoint(endpoint)
                         .WithCredentials("admin", "sqgl5j399jk9")
                         .WithSSL(false)
                         .Build();
    }

    public async Task<string> GetImageUrlAsync(string imageName)
    {
        var args = new PresignedGetObjectArgs()
                       .WithBucket(bucketName)
                       .WithObject(imageName)
                       .WithExpiry(60 * 60);
        return await minioClient.PresignedGetObjectAsync(args).ConfigureAwait(false);
    }
    public async void UploadImageSync(string imageObjectName, Stream imageStream)
    {
        //if (!FileTypes.Types.Contains(type)) return;
        PutObjectArgs putObjectArgs = new PutObjectArgs()
                                          .WithBucket(bucketName)
                                          .WithObject(imageObjectName)
                                          .WithStreamData(imageStream)
                                          .WithObjectSize(imageStream.Length);
                                          //.WithContentType(type);
        
        await minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
    }

    public async void DeleteImageSync(string imageObjectName)
    {
        RemoveObjectArgs removeObjectArgs = new RemoveObjectArgs()
                                               .WithBucket(bucketName)
                                               .WithObject(imageObjectName);
        await minioClient.RemoveObjectAsync(removeObjectArgs).ConfigureAwait(false);
    }
}