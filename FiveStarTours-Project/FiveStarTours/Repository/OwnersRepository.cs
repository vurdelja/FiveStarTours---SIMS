using FiveStarTours.Model;
using FiveStarTours.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveStarTours.Repository
{
    public class OwnersRepository
    {
        private const string FilePath = "../../../Resources/Data/owners.csv";

        private readonly Serializer<Owner> _serializerOwner;

        private List<Owner> _owners;

        public OwnersRepository()
        {
            _serializerOwner = new Serializer<Owner>();
            _owners = _serializerOwner.FromCSV(FilePath);
        }

        public List<Owner> GetAll()
        {
            return _serializerOwner.FromCSV(FilePath);
        }

        public Owner Save(Owner owner)
        {
            owner.Id = NextId();
            _owners = _serializerOwner.FromCSV(FilePath);
            _owners.Add(owner);
            _serializerOwner.ToCSV(FilePath, _owners);
            return owner;
        }

        public int NextId()
        {
            _owners = _serializerOwner.FromCSV(FilePath);
            if (_owners.Count < 1)
            {
                return 1;
            }
            return _owners.Max(t => t.Id) + 1;
        }

        public Owner GetById(int id)
        {
            _owners = GetAll();
            foreach (Owner owner in _owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }
            return null;
        }
    }
}

