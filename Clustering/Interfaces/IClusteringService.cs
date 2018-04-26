namespace Clustering
{
    public interface IClusteringService
    {
        int[] Decide(double[][] observations);

        void Learn(double[][] observations, int amountOfClusters);
    }
}