using System.Threading.Tasks;
using Astro.API.Application.Request.Post;
using Astro.API.Application.Response.Post;

namespace Astro.API.Application.Services.Upload
{
    public interface IUploadService
    {
        Task<UploadPostResult> UploadToBlobAsync(FileUploadRequestModel request);
    }
}
