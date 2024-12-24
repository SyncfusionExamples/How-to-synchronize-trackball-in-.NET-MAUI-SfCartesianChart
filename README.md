# How to synchronize trackball in .NET MAUI SfCartesianChart

In this article, we described how to synchronize the trackball in multiple SfCartesian charts. 

The [Trackball](https://help.syncfusion.com/maui/cartesian-charts/trackball) feature in [Syncfusion MAUI Cartesian Chart](https://help.syncfusion.com/maui/cartesian-charts/getting-started) is an interactive functionality that allows users to track and display data points on a chart as they hover over on different areas of the chart. It provides real-time feedback by showing a marker or tooltip with relevant data, such as the value of a specific point on the chart. This enhances the user experience by providing detailed information about specific data points.

**Importance of Synchronizing Trackball:**

•	**Consistency**: Ensures that all charts display data for the same point in time or category, making comparisons easier.
•	**Interactivity**: Enhances the user experience by allowing synchronized interactions across multiple charts.


**Steps to achieve Synchronized Trackball in .NET MAUI SfCartesianChart**

**Step 1: Set Up Multiple Charts**
Determine the number of charts you need to create to effectively visualize your data. Initialize a grid with the desired number of rows and columns.
Let’s configure the Syncfusion .NET MAUI SfCartesian Chart using this [getting started documentation](https://help.syncfusion.com/maui/cartesian-charts/getting-started) in each grid cells. Assign a unique x: Name to each of the charts. Refer to the following code example to create multiple charts in your application.

 
 ```xml
<Grid>
     <!-- Define 3 rows for the grid layout -->
     <Grid.RowDefinitions>
          <RowDefinition Height="*"/>
          <RowDefinition Height="*"/>
          <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <!--chart 1 -->

    <chart:SfCartesianChart Grid.Row="0" x:Name="firstChart"> 
        <chart:SfCartesianChart.XAxes>
            <chart:DateTimeAxis/>
        </chart:SfCartesianChart.XAxes>

        <chart:SfCartesianChart.YAxes>
            <chart:NumericalAxis/>
        </chart:SfCartesianChart.YAxes>

        <chart:SplineSeries ItemsSource="{Binding DataCollection1}" XBindingPath="Date" YBindingPath="Value"/>
    </chart:SfCartesianChart>

    <!--chart 2 -->

    <chart:SfCartesianChart Grid.Row="1" x:Name="secondChart">
        <chart:SfCartesianChart.XAxes>
            <chart:DateTimeAxis/>
        </chart:SfCartesianChart.XAxes>

        <chart:SfCartesianChart.YAxes>
            <chart:NumericalAxis/>
        </chart:SfCartesianChart.YAxes>

        <chart:StepLineSeries ItemsSource="{Binding DataCollection2}" XBindingPath="Date" YBindingPath="Value"/>
    </chart:SfCartesianChart>

    <!--chart 3 -->

    <chart:SfCartesianChart Grid.Row="2" x:Name="thirdChart">
        <chart:SfCartesianChart.XAxes>
            <chart:DateTimeAxis/>
        </chart:SfCartesianChart.XAxes>

        <chart:SfCartesianChart.YAxes>
            <chart:NumericalAxis/>
        </chart:SfCartesianChart.YAxes>

        <chart:StepLineSeries ItemsSource="{Binding DataCollection3}" XBindingPath="Date" YBindingPath="Value"/>
    </chart:SfCartesianChart>
</Grid> 
 ```


**Step 2: Initialize TrackballBehavior**
Initialize TrackballBehavior for each chart and specify a unique x: Name for each of the [ChartTrackballBehavior](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartTrackballBehavior.html?tabs=tabid-3). Refer to the following code to initialize TrackballBehavior.

 
 ```xml
<chart:SfCartesianChart Grid.Row="0" x:Name="firstChart"> 
        <chart:SfCartesianChart.TrackballBehavior>
               <chart:ChartTrackballBehavior x:Name="trackBall1" >       
        <chart:SfCartesianChart.TrackballBehavior> 
</chart:SfCartesianChart> 
 ```
Similarly, you have to mention for other charts also.

**Step 3: Handle the TrackballCreated events**
Handling the TrackballCreated events is crucial for synchronizing the trackball across multiple SfCartesianChart controls
[TrackballCreated Event](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_TrackballCreated): This event is triggered when the trackball is created or updated. By handling this event, you can synchronize the trackball position across multiple charts.
In your XAML, ensure that the TrackballCreated event is wired up for each chart.
 
 ```xml
<chart:SfCartesianChart Grid.Row="0" x:Name="firstChart" TrackballCreated="firstChart_TrackballCreated">
   . 
   .
   .
</chart:SfCartesianChart> 
 ```


Similarly, you have to specify event for other charts also.
 In your code-behind file (e.g., MainPage.xaml.cs), implement the event handlers to synchronize the trackball positions.

 ```csharp
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
 ```

In the above code, we have used the [ValueToPoint(ChartAxis axis, double value)](https://help.syncfusion.com/maui/cartesian-charts/transform-axis-value-to-pixel-value-and-vice-versa) method to convert the data point value to the screen point, and the ToOADate method is used to convert the DateTime value to a double value here. Then we have to specify those points in the ChartTrackballBehavior class show method to show synchronized trackball for all charts.

The following demo illustrates multiple charts in .NET MAUI with synchronized trackball, showing how the trackball positions move together across all charts when interacting with any one chart, following the implemented synchronization steps.

**Output:**
 
 ![ trackball synchronization](https://support.syncfusion.com/kb/agent/attachment/article/18647/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjM0MzQyIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.SlnHed6aMQ8riGFUC2tKxYKLejojSUzYboX56xNEgxA)
