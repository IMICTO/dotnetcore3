namespace Framework.Domain.ApplicationServices
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
