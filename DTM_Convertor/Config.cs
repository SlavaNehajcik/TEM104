using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace DTM_Convertor
{
    public partial class Config : Form
    {

        List<Channel> _channels = new List<Channel>();
        TreeNodeCollection _nodes;
        TreeNode[] _channelsNodes;
        //List<IDevice> _devices = new List<IDevice>();
        
        
        public Config()
        {
            InitializeComponent();
            prepareTableChannels(_channels);
        }

        private void InitData()
        {
            //TreeNode nodeChannel = new TreeNode()
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            //_channelsNodes[0] = new TreeNode("Empty");
            //TreeNode _tnChn = new TreeNode("Channels", _channelsNodes);
            //_nodes.Add(_tnChn);
        }

        private void prepareTableChannels(List<Channel> list)
        {
            
            dataGridView_Channels.Rows.Clear();

            int i = 0;
            foreach (Channel ch in list)
            {
                dataGridView_Channels.Rows.Add();
                dataGridView_Channels.Rows[i].Cells[0].Value = ch.Name;
                i++;               
            }            
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //throw new NotImplementedException();
            //TreeView tw = sender as TreeView;
            Console.WriteLine(sender.ToString());
            
            
        }        

        private void label1_MouseHover(object sender, EventArgs e)
        {
            IWin32Window iw = sender as IWin32Window;
            toolTip1.Show("Наименование канала", iw);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Channel ch = new Channel();

                ch.Name = textBox_Name.Text;

                ch.TimeOut = Convert.ToInt32(textBox_TimeOut.Text);
                ch.TimeLine = Convert.ToInt32(textBox_TimeLine.Text);
                ch.TimeSend = Convert.ToInt32(textBox_TimeSend.Text);

                ch.PortName = textBox_COM.Text;
                ch.BaudeRate = Convert.ToInt32(textBox_BaudeRate.Text);

                if (radioButtonDataBits7.Checked)
                    ch.DataBits = 7;
                else if (radioButtonDataBits8.Checked)
                    ch.DataBits = 8;

                if (radioButtonStopBit1.Checked)
                    ch.StopBits = StopBits.One;
                if (radioButtonStopBit2.Checked)
                    ch.StopBits = StopBits.Two;

                if (radioButtonParityEven.Checked)
                    ch.Parity = Parity.Even;
                else if (radioButtonParityNone.Checked)
                    ch.Parity = Parity.None;
                else if (radioButtonParityOdd.Checked)
                    ch.Parity = Parity.Odd;

                _channels.Add(ch);

                //обновление дерева настроек
                UpdateTreeViewer("Channels:", treeView1, _channels);
                prepareTableChannels(_channels);
                
                MessageBox.Show("Канал добавлен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Канал не добавлен. " + ex.Message);
            }
            finally
            {
                button_Add.Visible = false;
                tabControl_Config.Visible = false;
            }            
                     
        }        

        private void UpdateTreeViewer(string hideTitle, TreeView parent, List<Channel> list)
        {
            Console.WriteLine("list.Count = {0}", list.Count);
            TreeNode[] child = new TreeNode[list.Count];
            
            parent.Nodes.Clear();
            Console.WriteLine("child.Length = {0}", child.Length);
            
            int i = 0;

            foreach (Channel ch in list)
            {
                TreeNode tn = new TreeNode(ch.Name);
                tn.ContextMenuStrip = contextMenuStrip1;
                Console.WriteLine("i = {0}",i);
                child[i] = tn;
                Console.WriteLine("child[i] = {0}", child[i]);
                i++;
                
                //child[i].Nodes.Add(tn);               
            }
            
            //Console
            //parent.Nodes.Add(hideTitle);
            
            parent.Name = hideTitle;
            parent.Nodes.AddRange(child);            
            //parent.Add(new TreeNode("Channels", child));
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Канал добавлен.");
            //открытие окна для добавления канала
            tabControl_Config.Visible = true;
            button_Add.Visible = true;
            tabControl_Config.SelectedTab = tabPage1;
            tabPage2.Hide();
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            tabControl_Config.Visible = true;
            button_Add.Visible = true;
            tabControl_Config.SelectedTab = tabPage2;
            tabPage1.Hide();
        }

        private void dataGridView_Channels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("{0}", sender);                        
            if (dataGridView_Channels.CurrentCell != null)
            {
                Console.WriteLine("{0}", dataGridView_Channels.CurrentCell.Value);               
            }           
        }
        
    }
}
