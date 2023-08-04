using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAL
{
    public sealed class BookDataAccess
    {
        public static BookInventoryEntity _dbContext;
        public static readonly object _lock = new object();

        private BookDataAccess() { }

        public static BookInventoryEntity GetInstance()
        {
            if (_dbContext == null)
            {
                lock (_lock)
                {
                    if (_dbContext == null)
                    {
                        _dbContext = new BookInventoryEntity();
                        return _dbContext;
                    }
                }
            }
            return _dbContext;
        }
    }
}
