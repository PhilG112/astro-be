using MediatR;

namespace Astro.Application
{
    public interface ICommand : IRequest
    {
    }

     public interface ICommand<out TResult> : IRequest<TResult>
     {
     }
}