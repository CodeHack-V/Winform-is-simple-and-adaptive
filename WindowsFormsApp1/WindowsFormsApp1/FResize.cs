using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Windows.Forms.Control;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class FormInitSize
    {
        public static double Width = 0.00;
        public static double Height = 0.00;
    }
    public class ControlsSize
    {
        public string Name;
        public double Width;
        public double Top;
        public double Height;
        public double Left;
    }
    class ResizeMain
    {
        public static Form1 form1 = null;
        public static List<ControlsSize> controlsSizes = new List<ControlsSize>();
        public static void SizeInit()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                if (form1 != null)
                {
                    if (controlsSizes.Count == 0)
                    {
                        foreach (Control control in form1.Controls)
                        {
                            ControlsSize controlsSize = new ControlsSize();
                            controlsSize.Name = control.Name;
                            controlsSize.Width = control.Width;
                            controlsSize.Height = control.Height;
                            controlsSize.Top = control.Top;
                            controlsSize.Left = control.Left;
                            controlsSizes.Add(controlsSize);
                        }
                    }
                    else
                    {
                        controlsSizes.ForEach(CT =>
                            {
                                Control[] CurrentControl = form1.Controls.Find(CT.Name, true);
                                if (CurrentControl.Length >= 1)
                                {
                                    foreach (Control control in CurrentControl)
                                    {
                                        control.Invoke(new Action(() =>
                                        {
                                            control.Width = Convert.ToInt32(CT.Width / FormInitSize.Width * form1.Width);
                                            control.Height = Convert.ToInt32(CT.Height / FormInitSize.Height * form1.Height);
                                            control.Top = Convert.ToInt32(CT.Top / FormInitSize.Height * form1.Height);
                                            control.Left = Convert.ToInt32(CT.Left / FormInitSize.Width * form1.Width);
                                        }));
                                    }
                                }
                            });
                    }
                }
            }).Start();

        }
    }
}
