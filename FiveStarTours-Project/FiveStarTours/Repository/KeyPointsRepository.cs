﻿// Modeled on CommentRepository from InitialProject

using System.Collections.Generic;
using System.Linq;
using FiveStarTours.Model;
using FiveStarTours.Serializer;

namespace FiveStarTours.Repository
{
    public class KeyPointsRepository
    {
        private const string FilePath = "../../../Resources/Data/keypoints.csv";

        private readonly Serializer<KeyPoints> _serializer;

        private List<KeyPoints> _keyPoints;

        public KeyPointsRepository()
        {
            _serializer = new Serializer<KeyPoints>();
            _keyPoints = _serializer.FromCSV(FilePath);
        }

        public List<KeyPoints> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public KeyPoints Save(KeyPoints keyPoint)
        {
            keyPoint.Id = NextId();
            _keyPoints = _serializer.FromCSV(FilePath);
            _keyPoints.Add(keyPoint);
            _serializer.ToCSV(FilePath, _keyPoints);
            return keyPoint;
        }

        public int NextId()
        {
            _keyPoints = _serializer.FromCSV(FilePath);
            if (_keyPoints.Count < 1)
            {
                return 1;
            }
            return _keyPoints.Max(kp => kp.Id) + 1;
        }
    }
}
