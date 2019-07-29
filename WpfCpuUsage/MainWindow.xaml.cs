using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
//using Org.Mentalis.Utilities;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;
//using System.ComponentModel;

namespace WpfCpuUsage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool iscontinue = true;
        DispatcherTimer Timer99 = new DispatcherTimer();
        //Timer Timer99 = new Timer();
        
        public MainWindow()
        {
            InitializeComponent();

            Timer99.Tick += Timer99_Tick; // don't freeze the ui
            Timer99.Interval = new TimeSpan(0, 0, 0, 0, 1024);
            Timer99.IsEnabled = true;

            //populateCPUInfo();
        }


        private void populateCPUInfo()
        {
            try
            {

                /// Creating a New Thread 
                Thread thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        while (iscontinue)
                        {
                            var cpuload = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                            // RAM 
                            var ramload = new PerformanceCounter("Memory", "% Committed Bytes In Use", true);
                            float perfCounterValue = cpuload.NextValue();
                            float perfCounterValueRAM = ramload.NextValue();

                            //Thread has to sleep for at least 1 sec for accurate value.
                            System.Threading.Thread.Sleep(1000);

                            perfCounterValue = cpuload.NextValue();
                            perfCounterValueRAM = ramload.NextValue();



                            //populateCPU_TempInfo();

                            //To Update The UI Thread we have to Invoke  it. 
                            //this.Invoke(new System.Windows.Forms.MethodInvoker(delegate ()
                            //{
                                //int process = cpu.Query(); //Determines the current average CPU load.
                                int process = (int)perfCounterValue; // cpu.Query(); //Determines the current average CPU load.
                                int processRAM = (int)perfCounterValueRAM; // cpu.Query(); //Determines the current average CPU load.
                                                                           //progressBar1.Value = process;
                                                                           //progressBar2.Value = processRAM;
                                                                           //this.Text = "       CPU:  " + process.ToString() + "%" + "     RAM:  " + processRAM.ToString() + "%";
                            cpuPercent.Content = process.ToString();

                            ramPercent.Content = processRAM.ToString();

                            //}));

                            Thread.Sleep(450);//Thread sleep for 450 milliseconds 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "ERROR");
                    }

                }));

                thread.Priority = ThreadPriority.Highest;
                thread.IsBackground = true;
                thread.Start();//Start the Thread
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR");
                Console.WriteLine(ex);
            }

        }



        public PerformanceCounter myMemoryCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use", null);
        public PerformanceCounter myProcessorCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        public PerformanceCounter myDiskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        public Int32 diskC = 0;
        public Int32 cpuC = 0;
        public Int32 ramC = 0;
        public void Timer99_Tick(System.Object sender, System.EventArgs e)
        {
            cpuC = Convert.ToInt32(myProcessorCounter.NextValue());
            cpuPercent.Content = cpuC.ToString();

            ramC = Convert.ToInt32(myMemoryCounter.NextValue());
            ramPercent.Content = ramC.ToString();

            //diskC = Convert.ToInt32(myDiskCounter.NextValue());
            //textblock1.Text = diskC.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
            else if (e.ChangedButton == MouseButton.Right)
            {

            }
        }

        private void contextClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void contextOptions_Click(object sender, RoutedEventArgs e)
        {
            //MyOptions options = new MyOptions();
            //options.Show();
        }

        //Handler for asynchronous results
        //public class ObjectHandler
        //{
        //    private bool isCompleted = false;
        //    public string serviceString = "";
        //    private ManagementBaseObject returnObject;



        //    //Property allows accessing the result object in the main function
        //    public ManagementBaseObject ReturnObject
        //    {
        //        get
        //        {
        //            return returnObject;
        //        }
        //    }



        //    public void NewObject(object sender, ObjectReadyEventArgs obj)
        //    {

        //        //Console.WriteLine("Service : {0}, State = {1}", obj.NewObject["Name"], obj.NewObject["State"]);
        //        serviceString = string.Format("Service : {0}, State = {1}", obj.NewObject["Name"], obj.NewObject["State"]);
        //        returnObject = obj.NewObject;

        //    }

        //    public bool IsCompleted
        //    {
        //        get
        //        {
        //            return isCompleted;
        //        }
        //    }

        //    public void Reset()
        //    {
        //        isCompleted = false;
        //    }

        //    public void Done(object sender, CompletedEventArgs obj)
        //    {
        //        isCompleted = true;
        //    }
        //}




    }
}
