using DataAccessLayer;

using DataACesslayer;

using IReprosastory;

namespace ReprestoryServess
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly ApplicationDBcontext _context;

        public UnitOfWork(ApplicationDBcontext context , DepartmentService departmentService,MailingService mailingService, LookupService lookupService)
        {
            _departmentService = departmentService;
                        _context = context;
            _mailingService = mailingService;
            Ilookup = lookupService;
        }

        private bool disposed = false;

        public IDepartmentService _departmentService { get; }
        public IMailingService _mailingService { get; }
        public Ilookup Ilookup { get; }

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
