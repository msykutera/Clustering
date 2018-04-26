using FluentAssertions;
using Xunit;

namespace Clustering.Tests
{
    public class ClusteringTests
    {
        private IClusteringService _clusteringService;

        public ClusteringTests()
        {
            _clusteringService = new KMeansClusteringService();
        }

        [Fact]
        public void ClusteringTest1()
        {
            var input = new double[][]
            {
                new double[] { 14, 2, 3 },
                new double[] { 11, 2, 3 },
                new double[] { 18, 22, 3 },
                new double[] { 41, 2, 32 },
                new double[] { 13, 2, 4 },
                new double[] { 11, 24, 43 },
                new double[] { 13, 2, 31 },
                new double[] { 51, 52, 43 },
                new double[] { 7, 2, 3 },
                new double[] { 11, 21, 31 },
                new double[] { 41, 22, 83 },
                new double[] { 21, 25, 3 },
                new double[] { 1, 72, 34 },
                new double[] { 1, 5, 3 },
                new double[] { 1, 12, 3 },
            };
            _clusteringService.Learn(input, 2);

            var testSet = new double[][]
            {
                new double[] { 1, 2, 3 },
                new double[] { 11, 21, 13 },
                new double[] { 48, 52, 33 },
                new double[] { 11, 2, 13 },
            };
            var result = _clusteringService.Decide(testSet);

            result.Should().HaveCount(4);

            var first = result[0];
            var third = result[2];
            first.Should().NotBe(third);
        }
    }
}
