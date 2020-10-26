namespace Astro.Application.Upload.Commands.Dtos
{
    public class UploadBlobDto
    {
        public int StatusCode { get; set; }

        public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;

        public string FileName { get; set; }

    }
}
