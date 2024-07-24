using DataAccessLayer;

using DataACesslayer;

using IReprosastory;

namespace ReprestoryServess
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly ApplicationDBcontext _context;

        public UnitOfWork(ApplicationDBcontext context , DepartmentService departmentService,MailingService mailingService)
        {
            _departmentService = departmentService;
                        _context = context;
            _mailingService = mailingService;
        }

        private bool disposed = false;

        public IDepartmentService _departmentService { get; }
        public IMailingService _mailingService { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        // Implement the finalizer to release unmanaged resources
        ~UnitOfWork()
        {
            Dispose(false);
        }
 


    }

}
