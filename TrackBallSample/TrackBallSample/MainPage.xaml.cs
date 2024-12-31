using Syncfusion.Maui.Charts;
using TrackBallSample.Model;

namespace TrackBallSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void HandleTrackballCreated(object sender, TrackballEventArgs e, SfCartesianChart primaryChart, ChartTrackballBehavior trackBall1, ChartTrackballBehavior trackBall2)
        {
            var pointsInfo = e.TrackballPointsInfo;
            if (pointsInfo.Count > 0)
            {
                var item = (DataModel)pointsInfo[0].DataItem;

                // Convert chart point to screen point
                float xPoint = primaryChart.ValueToPoint(primaryChart.XAxes[0], item.Date.ToOADate());
                float yPoint = primaryChart.ValueToPoint(primaryChart.YAxes[0], item.Value);

                // Show the trackball markers on the other charts
                trackBall1.Show(xPoint, yPoint);
                trackBall2.Show(xPoint, yPoint);
            }
        }

        private void firstChart_TrackballCreated(object sender, TrackballEventArgs e)
        {
            HandleTrackballCreated(sender, e, firstChart, trackBall2, trackBall3);
        }

        private void secondChart_TrackballCreated(object sender, TrackballEventArgs e)
        {
            HandleTrackballCreated(sender, e, secondChart, trackBall1, trackBall3);
        }

        private void thirdChart_TrackballCreated(object sender, TrackballEventArgs e)
        {
            HandleTrackballCreated(sender, e, thirdChart, trackBall1, trackBall2);
        }
    }
}