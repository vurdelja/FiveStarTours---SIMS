using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FiveStarTours.Model;
using FiveStarTours.Serializer;
using FiveStarTours.View;


namespace FiveStarTours.Repository
{
    public class VisitorRepository
    {
        private const string FilePath = "../../../Resources/Data/visitors.csv";
        private readonly Serializer<Visitor> _serializerVisitor;

        private List<Visitor> _visitors;
        public VisitorRepository()
        {
            _serializerVisitor = new Serializer<Visitor>();
            _visitors = _serializerVisitor.FromCSV(FilePath);
        }

        public List<Visitor> GetAll()
        {
            return _serializerVisitor.FromCSV(FilePath);
        }

        public Visitor Save(Visitor visitor)
        {
            visitor.Id = NextId();
            _visitors = _serializerVisitor.FromCSV(FilePath);
            _visitors.Add(visitor);
            _serializerVisitor.ToCSV(FilePath, _visitors);
            return visitor;
        }

        public int NextId()
        {
            _visitors = _serializerVisitor.FromCSV(FilePath);
            if (_visitors.Count < 1)
            {
                return 1;
            }
            return _visitors.Max(t => t.Id) + 1;
        }

        public int ReservedSeats(Tour tour)
        {
            int reservedSeats = 0;
            List<Visitor> visitors = new List<Visitor>();
            visitors = GetAll();
            foreach (var visitor in _visitors)
            {
                foreach(var date in tour.Beginning)
                {
                    if(visitor.TourId == tour.Id && visitor.DateTime == date)
                    {
                        reservedSeats += visitor.MembersNumber;
                    }
                }
            }
            return reservedSeats;
        }
    }
}
   
