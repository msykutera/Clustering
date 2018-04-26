using Accord.MachineLearning;
using System;

namespace Clustering
{
    public class KMeansClusteringService : IClusteringService
    {
        public KMeansClusterCollection _clusters { get; private set; }

        public void Learn(double[][] observations, int amountOfClusters)
        {
            var kmeans = new KMeans(amountOfClusters);
            _clusters = kmeans.Learn(observations);
        }

        public int[] Decide(double[][] observations)
        {
            if (_clusters == null) throw new Exception("Clustering has to learn before it can decide");

            var result = _clusters.Decide(observations);
            return result;
        }
    }
}