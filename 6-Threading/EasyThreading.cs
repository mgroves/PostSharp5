using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using Message = PostSharp.Extensibility.Message;

namespace Threading
{
    public partial class EasyThreading : Form
    {
        public EasyThreading()
        {
            InitializeComponent();

            BackgroundMessages();
            BackgroundMessages();
            BackgroundMessages();
            BackgroundMessages();
            BackgroundMessages();

            button1.Click+=new EventHandler(button_Click);
            button2.Click+=new EventHandler(button_Click);
            button3.Click+=new EventHandler(button_Click);
        }

        [WorkerThread]
        private void BackgroundMessages()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            while(true)
            {
                var sleepyTime = rand.Next(100, 1000);
                Thread.Sleep(sleepyTime);
                WriteMessageToListView("slept for " + sleepyTime + "ms");
            }
        }

        [UiThread]
        private void WriteMessageToListView(string message)
        {
            listBox1.Items.Add(message);
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.Text = DateTime.Now.TimeOfDay.ToString();
        }
    }

    [Serializable]
    public class WorkerThread : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            ThreadPool.QueueUserWorkItem(d => args.Invoke(args.Arguments));
        }
    } 
    
    [Serializable]
    public class UiThread : MethodInterceptionAspect
    {
        public override bool CompileTimeValidate(MethodBase method)
        {
            if (!typeof(Form).IsAssignableFrom(method.DeclaringType))
            {
                Message.Write(SeverityType.Error, "003", "UiThread can only be used on methods in a Form class in {0}.{1}", method.DeclaringType.BaseType, method.Name);
                return false;
            }
            return true;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var dispatcher = (Form) args.Instance;
            if (!dispatcher.InvokeRequired)
            {
                args.Proceed();
            }
            else
            {
                dispatcher.Invoke(new Action(args.Proceed));
            }
        }
    }
}
