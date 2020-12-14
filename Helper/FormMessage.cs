using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHJD.UserManage.Helper
{
    public partial class FormMessage : Form
    {
        /// <summary>
        /// 私有任务管理器
        /// </summary>
        private static Task task;
        /// <summary>
        /// 采用定时关闭界面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="timeSpan"></param>
        public FormMessage(string message,long timeSpan=3)
        {
            if (task!=null)
            {
                return;
            }
            InitializeComponent();
            label1.Text = message;
            
            task = new TaskFactory().StartNew(() => {
                int i = 0;
                var endDateTime = DateTime.Now.AddSeconds(timeSpan);
                while (i<Int32.MaxValue) {
                    if (DateTime.Now> endDateTime)
                    {
                        try
                        {
                            //定时关闭界面
                            this.BeginInvoke(
                            new Action(delegate
                            {
                                this.Close();
                            })
                            );
                           
                            return;
                        }
                        catch (Exception ex){
                        }

                    }
                    ///500ms 检查一次
                    Thread.Sleep(500);
                    
                    ++i;
                }
                ///防止未关闭界面再次执行
                this.BeginInvoke(
                           new Action(delegate
                           {
                               this.Close();
                           })
                           );
                return;
            });
        }

        private void FormMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try {
                task = null;
            } catch { }
            
        }
    }
}
