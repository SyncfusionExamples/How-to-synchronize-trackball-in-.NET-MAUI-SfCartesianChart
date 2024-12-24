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

        // first chart
        private void firstChart_TrackballCreated(object sender, TrackballEventArgs e)
        {
            var pointsInfo = e.TrackballPointsInfo;
            if (pointsInfo.Count > 0)
            {
                var item = (DataModel)pointsInfo[0].DataItem;

                // Convert chart point to screen point
                float xPoint = firstChart.ValueToPoint(firstChart.XAxes[0], item.Date.ToOADate());
                float yPoint = firstChart.ValueToPoint(firstChart.YAxes[0], item.Value);

                // Show the trackball markers on chart 2 and 3 at the calculated screen positions
                trackBall2.Show(xPoint, yPoint);
                trackBall3.Show(xPoint, yPoint);
            }
        }

        // second chart
        private void secondChart_TrackballCreated(object sender, TrackballEventArgs e)
        {
            var pointsInfo = e.TrackballPointsInfo;
            if (pointsInfo.Count > 0)
            {
                var item = (DataModel)pointsInfo[0].DataItem;

                // Convert chart point to screen point
                float xPoint = secondChart.ValueToPoint(secondChart.XAxes[0], item.Date.ToOADate());
                float yPoint = secondChart.ValueToPoint(secondChart.YAxes[0], item.Value);

                // Show the trackball markers on chart 1 and 3 at the calculated screen positions
                trackBall1.Show(xPoint, yPoint);
                trackBall3.Show(xPoint, yPoint);
            }
        }

        // third chart
        private void thirdChart_TrackballCreated(object sender, TrackballEventArgs e)
        {
            var pointsInfo = e.TrackballPointsInfo;
            if (pointsInfo.Count > 0)
            {
                var item = (DataModel)pointsInfo[0].DataItem;

                // Convert chart point to screen point
                float xPoint = thirdChart.ValueToPoint(thirdChart.XAxes[0], item.Date.ToOADate());
                float yPoint = thirdChart.ValueToPoint(thirdChart.YAxes[0], item.Value);

                // Show the trackball markers on chart 1 and 2 at the calculated screen positions
                trackBall1.Show(xPoint, yPoint);
                trackBall2.Show(xPoint, yPoint);
            }
        }
    }
}