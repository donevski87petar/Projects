using BOSSCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOSSCompanyAPI.Repository.IRepository
{
    public interface ISockRepository
    {
        ICollection<Sock> GetSocks();
        Sock GetSock(int sockId);
        bool CreateSock(Sock sock);
        bool UpdateSock(Sock sock);
        bool DeleteSock(Sock sock);
        bool Save();
    }
}
