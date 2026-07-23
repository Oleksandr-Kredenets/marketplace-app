namespace MarketPlace.Application.Interfaces;
public interface IImageStorage
{
    public Task<string> GetImageUrlAsync(string imageName);
    public void UploadImageSync(string imageObjectName, Stream imageStream);
    public void DeleteImageSync(string imageObjectName);
}