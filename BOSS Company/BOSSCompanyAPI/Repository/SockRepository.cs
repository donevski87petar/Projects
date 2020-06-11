using BOSSCompanyAPI.Data;
using BOSSCompanyAPI.Models;
using BOSSCompanyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOSSCompanyAPI.Repository
{
    public class SockRepository : ISockRepository
    {
        ApplicationDbContext _db;
        public SockRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateSock(Sock sock)
        {
            _db.Socks.Add(sock);
            return Save();
        }

        public bool DeleteSock(Sock sock)
        {
            _db.Socks.Remove(sock);
            return Save();
        }

        public Sock GetSock(int sockId)
        {
           return _db.Socks.FirstOrDefault(s => s.Id == sockId);
        }

        public ICollection<Sock> GetSocks()
        {
            return _db.Socks.ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateSock(Sock sock)
        {
            _db.Socks.Update(sock);
            return Save();
        }
    }
}
