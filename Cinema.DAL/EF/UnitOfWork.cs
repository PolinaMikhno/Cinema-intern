using System;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.DAL.EF
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext _databaseContext;

        private IRepository<Film> _films;
        private IRepository<Theater> _theaters;
        private IRepository<Session> _sessions;

        

        public UnitOfWork()
        {
            _databaseContext = new DatabaseContext();
            _films = new Repository<Film>(_databaseContext);
            _theaters = new Repository<Theater>(_databaseContext);
            _sessions = new Repository<Session>(_databaseContext);
        }


        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _databaseContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose();
        }
    }
}