using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class UserRepository
    {
        private const string FilePath = "../../../Resources/Data/users.csv";

        private readonly Serializer<User> _serializer;
        private static UserRepository instance = null;
        private List<User> _users;
        public static UserRepository GetInstace()
        {
            if (instance == null)
            {
                instance = new UserRepository();
            }
            return instance;
        }

        public UserRepository()
        {
            _serializer = new Serializer<User>();
            _users = _serializer.FromCSV(FilePath);
        }

        public User GetByUsername(string username)
        {
            _users = _serializer.FromCSV(FilePath);
            return _users.FirstOrDefault(u => u.Username == username);
        }


        public List<User> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public User GetById(int id)
        {
            _users = GetAll();
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
