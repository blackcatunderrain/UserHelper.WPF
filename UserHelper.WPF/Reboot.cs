using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserHelper.WPF
{
    class Reboot
    {
        public void RebootPC ()
        {
            var message = "Точно перезагрузить Ваш ПК?";
            var message1 = "Повторный запрос";
            var caption = "Перезагрузка";
            var buttons = MessageBoxButton.YesNo;

            var result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var result1 = MessageBox.Show(message1, caption, buttons, MessageBoxImage.Question);
                if (result1 == MessageBoxResult.Yes)
                {
                    FileInfo execFile = new FileInfo("shutdown.exe");
                    Process proc = new Process();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.FileName = execFile.Name;
                    proc.StartInfo.Arguments = "/r /t 10";
                    MessageBox.Show("Компьютер будет перезагружен через 10 секунд");
                    proc.Start();
                }
            }
        }
    }
}
