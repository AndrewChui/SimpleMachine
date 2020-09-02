using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

/// <summary>
/// 一个简单的机器代码的模拟
/// 出自《计算机科学概论》第12版附录C
/// “Computer Science： An overview, 12th Edition, Appendix C
/// </summary>
namespace MiniPai
{
    public partial class MiniPaiForm : Form
    {
        public MiniPaiForm()
        {
            InitializeComponent();
        }

        private readonly Color regularForeColor = Color.Black;
        private readonly Color changeForeColor = Color.Red;

        private Machine machine = new Machine();
        private BindingSource regBindingSource = new BindingSource();
        private BindingSource memBindingSource = new BindingSource();
        private void MiniPaiForm_Load(object sender, EventArgs e)
        {
            SetupRegDataGridView();
            pcAddresstextBox.Text = machine.PCAddress.ToString();
        }

        private void SetupRegDataGridView()
        {
            regBindingSource.DataSource = machine.regList;
            regDataGridView.DataSource = regBindingSource;

            regDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            regDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            regDataGridView.ColumnHeadersDefaultCellStyle.Font =
            new Font(regDataGridView.Font, FontStyle.Bold);
            regDataGridView.Name = "regDataGridView";


            regDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            regDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            regDataGridView.GridColor = Color.Black;
            regDataGridView.RowHeadersVisible = false;

            regDataGridView.SelectionMode =
                  DataGridViewSelectionMode.FullRowSelect;
            regDataGridView.MultiSelect = false;
            regDataGridView.Columns[0].DefaultCellStyle.Format = "X2";
            regDataGridView.Columns[1].DefaultCellStyle.Format = "X2";
            
            memBindingSource.DataSource = machine.memList;
            memDataGridView.DataSource = memBindingSource;
            memDataGridView.RowHeadersVisible = false;
            memDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            memDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            memDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            memDataGridView.MultiSelect = false;
            memDataGridView.Columns[0].DefaultCellStyle.Format = "X2";
            memDataGridView.Columns[1].DefaultCellStyle.Format = "X2";
            memDataGridView.Columns[0].ReadOnly = true;

        }

        private void regClear_Click(object sender, EventArgs e)
        {
            if (regNumberTextBox.Text != "")
            {
                var num = Convert.ToInt32(regNumberTextBox.Text);
                if (num >= 0 && num < Machine.RegNumber)
                {
                    machine.regList[num].Value = 0;
                    DataGridViewRow dataGridViewRow = regDataGridView.Rows[num];
                    dataGridViewRow.DefaultCellStyle.ForeColor = regularForeColor;
                    regBindingSource.ResetItem(num);
                }

            }
        }

        private void regSetValue_Click(object sender, EventArgs e)
        {
            if (regNumberTextBox.Text != "" && regValueTextbox.Text != "")
            {
                var num = Convert.ToInt32(regNumberTextBox.Text);
                if (num >= 0 && num < Machine.RegNumber)
                {
                    machine.regList[num].Value = Convert.ToByte(regValueTextbox.Text);
                    DataGridViewRow dataGridViewRow = regDataGridView.Rows[machine.RegChangeNumber];
                    dataGridViewRow.DefaultCellStyle.ForeColor = regularForeColor;
                    dataGridViewRow = regDataGridView.Rows[num];
                    dataGridViewRow.DefaultCellStyle.ForeColor = changeForeColor;
                    machine.RegChangeNumber = num;
                    regBindingSource.ResetItem(num);

                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void memDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex==1 && e.RowIndex>=0 && e.RowIndex <= 255)
            {
                byte result;
                if(!byte.TryParse(e.FormattedValue.ToString(), NumberStyles.HexNumber,
                    null as IFormatProvider,out result))
                {
                    memDataGridView.Rows[e.RowIndex].ErrorText = "请输入16进制数据00-FF";
                    e.Cancel = true;
                }
                
            }

          
        }

        private void memDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && e.RowIndex <= 255)
            {
                memDataGridView.Rows[e.RowIndex].ErrorText = "";
            }
        }

        private void memDataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && e.RowIndex <= 255)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.Value = Convert.ToByte(e.Value.ToString(), 16);
                e.ParsingApplied = true;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (!machine.stopMachine) 
            {
                setPCButton.Enabled = false;
                regClear.Enabled = false;
                regSetValue.Enabled = false;
                memSetValueButton.Enabled = false;
                memClearButton.Enabled = false;
                machine.runInfo.preAddress = machine.PCAddress;
                machine.runInfo.addressNum = 0;
                machine.runInfo.instructionsAccout = 0;
                machine.runInfo.regmem = RunInfo.RegMem.REGISTER;
            }
            
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            if(!machine.stopMachine)
            {
                pcAddresstextBox.Text = machine.PCAddress.ToString();

                int preAddress = machine.runInfo.preAddress;
                DataGridViewRow dataGridViewRow = memDataGridView.Rows[preAddress];
                dataGridViewRow.DefaultCellStyle.ForeColor = regularForeColor;
                memBindingSource.ResetItem(preAddress);
                dataGridViewRow = memDataGridView.Rows[preAddress+1];
                dataGridViewRow.DefaultCellStyle.ForeColor = regularForeColor;
                memBindingSource.ResetItem(preAddress+1);

                dataGridViewRow = memDataGridView.Rows[machine.PCAddress];
                dataGridViewRow.DefaultCellStyle.ForeColor = changeForeColor;
                memBindingSource.ResetItem(machine.PCAddress);
                dataGridViewRow = memDataGridView.Rows[machine.PCAddress+1];
                dataGridViewRow.DefaultCellStyle.ForeColor = changeForeColor;
                memBindingSource.ResetItem(machine.PCAddress + 1);

                if(machine.runInfo.instructionsAccout>0)
                {
                    if(machine.runInfo.regmem == RunInfo.RegMem.MEMORY)
                    {
                        dataGridViewRow = memDataGridView.Rows[machine.runInfo.addressNum];
                        dataGridViewRow.DefaultCellStyle.ForeColor = regularForeColor;
                        memBindingSource.ResetItem(machine.runInfo.addressNum);
                    }
                    else
                    {
                        dataGridViewRow = regDataGridView.Rows[machine.runInfo.addressNum];
                        dataGridViewRow.DefaultCellStyle.ForeColor = regularForeColor;
                        regBindingSource.ResetItem(machine.runInfo.addressNum);
                    }
                }
                
                machine.GetInstructions();
                machine.ParseInstructions();
                machine.RunInstructions();

                if (machine.runInfo.instructionsAccout > 0)
                {
                    if (machine.runInfo.regmem == RunInfo.RegMem.MEMORY)
                    {
                        dataGridViewRow = memDataGridView.Rows[machine.runInfo.addressNum];
                        dataGridViewRow.DefaultCellStyle.ForeColor = changeForeColor;
                        memBindingSource.ResetItem(machine.runInfo.addressNum);
                    }
                    else
                    {
                        dataGridViewRow = regDataGridView.Rows[machine.runInfo.addressNum];
                        dataGridViewRow.DefaultCellStyle.ForeColor = changeForeColor;
                        regBindingSource.ResetItem(machine.runInfo.addressNum);
                    }
                }


            }
        }

        private void setPCButton_Click(object sender, EventArgs e)
        {
            if (pcTextBox.Text != "")
            {
                byte result;
                if (byte.TryParse(pcTextBox.Text, NumberStyles.HexNumber,
                    null as IFormatProvider, out result))
                {
                    machine.PCAddress = result;
                }
                else
                {
                    machine.PCAddress = 0;
                }
                pcAddresstextBox.Text = machine.PCAddress.ToString();
            }
        }
    }
}