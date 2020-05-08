using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace UserHelper.WPF
{
    class GPupdate
    {
        public void UpdateGroupPolicy()
        {
            FileInfo execFile = new FileInfo("gpupdate.exe");
            Process proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.FileName = execFile.Name;
            proc.StartInfo.Arguments = "/force";
            MessageBox.Show("Начинаем обновление политик");
            proc.Start();
            //Wait for GPUpdate to finish
            while (!proc.HasExited)
            {
                Thread.Sleep(100);
            }
            MessageBox.Show("Обновление политик успешно завершено");
        }
    }
}
