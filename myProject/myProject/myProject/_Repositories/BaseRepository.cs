using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject._Repositories
{
    public abstract class BaseRepository
    {
        protected string connectionString;

        protected BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
