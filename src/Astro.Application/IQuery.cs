using MediatR;

namespace Astro.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}