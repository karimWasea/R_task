namespace IReprosastory
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentService _departmentService { get; }
         IMailingService _mailingService { get; }

          Ilookup Ilookup { get; }

    }
}
