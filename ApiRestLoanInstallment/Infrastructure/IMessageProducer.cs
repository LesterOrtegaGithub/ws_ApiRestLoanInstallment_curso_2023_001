namespace ApiRestLoanInstallment.Infrastructure
{
    public interface IMessageProducer
    {
        void Produce(string message);
    }
}
