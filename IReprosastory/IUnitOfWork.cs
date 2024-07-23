namespace IReprosastory
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentService _departmentService { get; }



    }
}
