using DataACesslayer;

using IReprosastory;

namespace ReprestoryServess
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly ApplicationDBcontext _context;

        public UnitOfWork(ApplicationDBcontext context , DepartmentService departmentService)
        {
            _departmentService = departmentService;
                        _context = context;
        }

        private bool disposed = false;

        public IDepartmentService _departmentService { get; }

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
