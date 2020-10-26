using FluentValidation;

namespace Astro.Application.Upload.Commands.UploadBlob
{
    public class UploadBlobValidator : AbstractValidator<UploadBlobCommand>
    {
        public UploadBlobValidator()
        {
            RuleFor(x => x.FormFiles).NotEmpty().WithMessage("Must upload atleast 1 file.");
        }
    }
}
