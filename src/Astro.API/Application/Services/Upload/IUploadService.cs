using System.Threading.Tasks;
using Astro.API.Application.Request.Post;

namespace Astro.API.Application.Services.Upload
{
    public interface IUploadService
    {
        Task UploadToBlobAsync(FileUploadRequestModel request);
    }
}
