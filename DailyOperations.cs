using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Brada3
{
    public partial class DailyOperations : Form
    {
        BradaDataClassesDataContext brada = new BradaDataClassesDataContext();

        DataTable dt = new DataTable();
        public DailyOperations()
        {
            InitializeComponent();
        }

        private void DailyOperations_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            txt_Delete_item.Visible = false;
            label14.Visible = false;
            //label3.Text = "Dear, Note :\n This Form only used to Insert ITems which is used daily !\nعزيزى العميل ، إحذر من إدراج أصناف ك الجديدة هنا و إلا سيتسبب ذلك فى خراب السيستم";
            //AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            //var x_text = brada.Tbl_Items.Select(s => new { Name = s.Item_Name, ID = s.ID }).ToList();

            //foreach (var item in x_text)
            //{
            //    Combo_Item_name.Items.Add(item);
            //}
            //Combo_Item_name.ValueMember = "ID";
            //Combo_Item_name.DisplayMember = "Name";



            //Combo_Item_name.AutoCompleteMode = AutoCompleteMode.Suggest;
            //Combo_Item_name.AutoCompleteSource = AutoCompleteSource.ListItems;
            //AutoCompleteStringCollection DataCollection = (MyCollection);
            //Combo_Item_name.AutoCompleteCustomSource = DataCollection;

            dt.Columns.Add("اسم الصنف", typeof(string));
            dt.Columns.Add("العدد", typeof(int));
            dt.Columns.Add("السعر", typeof(float));
            dt.Columns.Add("الاجمالى", typeof(float));

            /////////////////////////////

            //txt_Quantity_Number.Enabled = false;

            
           


            
        }
        
        private void Btn_Add_Item_Click(object sender, EventArgs e)
        {
            dt.Clear();
            Tbl_Daily_operation Daily_op = new Tbl_Daily_operation();
            if (txt_Import_date.Text == "" || txt_receipt_num.Text == "")
            {
                txt_Import_date.Text = Convert.ToString(DateTime.Now);
                
                var maxid = brada.Tbl_Daily_operations.Max(s => s.receipt_Code);
                txt_receipt_num.Text = (maxid + 1).ToString();
            }
            groupBox4.Visible = false;
            groupBox3.Visible = false;
            txt_Packu_Cost.Clear();
            txt_Item_Name.Clear();
            txt_Quantity_Number.Clear();
            Lbl_TotalCost.Text = "";
            Btn_Impleme_Update.Visible = false;
            Btn_Delete_Confirm.Visible = false;
            Btn_Add_Item_Confirm.Visible = true;
            Btn_Add_Item_Confirm.Text = "تأكيد الإضافة";
            groupBox6.Visible = true;
            label13.Text = "";
        }
        public bool search_ITems(string search_item)
        {
            var allnames = brada.Tbl_Items.Select(s => s.Item_Name).ToList();
            foreach (var item in allnames)
            {
                if (item == search_item)
                {
                    return true;

                }
            }
            return false;
        }
        public bool search_daily(string search_item)
        {
            var allnames = brada.Tbl_Daily_operations.Select(s => s.Item_Name).ToList();
            foreach (var item in allnames)
            {
                if (item == search_item)
                {
                    return true;

                }
            }
            return false;
        }
        private void Btn_Add_Item_Confirm_Click(object sender, EventArgs e)
        {
            Tbl_Item Item = new Tbl_Item();
            Tbl_Daily_operation DailyOperat = new Tbl_Daily_operation();
            Tbl_Import Import = new Tbl_Import();
            if (txt_Import_date.Text != "" && txt_receipt_num.Text != "")
            {
                if (search_ITems(txt_Item_Name.Text))
                {
                    if (search_daily(txt_Item_Name.Text))//Update
                    {
                        MessageBox.Show("Refused");
                        txt_Item_Name.Text = txt_Quantity_Number.Text = Lbl_TotalCost.Text = txt_Packu_Cost.Text = "";
                    }
                    else//Insert
                    {
                        if (txt_Item_Name.Text != "" && txt_Quantity_Number.Text != "" && txt_Packu_Cost.Text != "" && Lbl_TotalCost.Text != "")
                        {
                            var date = Convert.ToDateTime(txt_Import_date.Text);
                            var receipt_num = Convert.ToInt32(txt_receipt_num.Text);
                            //--------------- Replace Subtracted values from Tbl_ITem Table---
                            var details = brada.Tbl_Items.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => new { ID = s.ID, Quantity__Item_Num = s.Quantity_Num }).SingleOrDefault();
                            int item_Code = details.ID;
                            int Quantity_tbl_Item_Num = details.Quantity__Item_Num;
                            int Quantity_Subtracted_DailyOPeration = Convert.ToInt32(txt_Quantity_Number.Text);
                            int Tbl_Item_Result_after_Subtract = Quantity_tbl_Item_Num - Quantity_Subtracted_DailyOPeration;
                            var ID = details.ID;
                            brada.Subtract_Update_Tbl_Item_Daily(ID, Tbl_Item_Result_after_Subtract);

                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                DataGridViewRow row = dataGridView1.Rows[i];
                                var cel0 = row.Cells[0].Value.ToString();
                                var cel1 = row.Cells[1].Value.ToString();
                                var cel2 = row.Cells[2].Value.ToString();
                                var cel3 = row.Cells[3].Value.ToString();
                                //Insert values Directly from Gridview
                                //i=====>max+1 hالمفروض 
                                brada.insert_Daily_Operation(i,item_Code, cel0, int.Parse(cel1), float.Parse(cel2), float.Parse(cel3), date, receipt_num);
                                brada.SubmitChanges();
                            }
                            label13.Text = "";
                            Btn_Add_Item_Confirm.Text = "تم الإضافة";
                            txt_receipt_num.Clear();

                        }
                        else
                        {
                            MessageBox.Show("برجاء املأ الخانات");
                        }
                        brada.SubmitChanges();
                        txt_Item_Name.Text = txt_Quantity_Number.Text = Lbl_TotalCost.Text = txt_Packu_Cost.Text = "";
                    }
                }
                else
                {

                    MessageBox.Show(" إلغى هذا ! سيؤدى ذلك لخراب السيستم على إيدك يا مفترى ");
                }

            }
            else
            {
                MessageBox.Show("Press Add Item,إضغط إضافة صنف");
            }

        }

        
        

        private void txt_Quantity_Number_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            try
            {
                if (txt_Item_Name.Text != "" && txt_Packu_Cost.Text != "")
                {
                    
                    
                    var name = txt_Item_Name.Text;
                    float Quantity_Number = float.Parse(txt_Quantity_Number.Text);
                    float Packu_Cost = float.Parse(txt_Packu_Cost.Text);
                    float Total_receipt = Packu_Cost * Quantity_Number;
                    Lbl_TotalCost.Text = Convert.ToString(Total_receipt);
                    dt.Rows.Add(name, Quantity_Number, Packu_Cost, Total_receipt);
                    dataGridView1.DataSource = dt;
                    Lbl_TotalCost.Text = Total_receipt.ToString();
                    //txt_Quantity_Number.Enabled = false;
                }
            }
            catch (Exception)
            {

                if (txt_Item_Name.Text == "")
                {
                    txt_Item_Name.Text = txt_Packu_Cost.Text = "";
                }
            }
        }

        private void Btn_Edit_Item_Click(object sender, EventArgs e)
        {
            dt.Clear();
            txt_ItemName_Edit.Clear();
            txt_QuantityNum_Edit.Clear();
            txt_Packu_Price_Edit.Clear();
            Lbl_TotalCost_Edit.Text = "";
            groupBox4.Visible = false;
            groupBox3.Visible = true;
            groupBox6.Visible = false;
            txt_Packu_Cost.Clear();
            txt_Item_Name.Clear();
            txt_Quantity_Number.Clear();
            Lbl_TotalCost.Text = "";
            Btn_Impleme_Update.Visible = true;
            Btn_Delete_Confirm.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Add_Item_Confirm.Text = "تنفيذ التعديل";

        }
        Menu m = new Menu();
        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }

        private void txt_TotalCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Item_Name.Text != "")
                {
                    var name = txt_Item_Name.Text;
                    float Quantity_Number = float.Parse(txt_Quantity_Number.Text);
                    float Packu_Cost = float.Parse(txt_Packu_Cost.Text);
                    float Total_Cost = float.Parse(Lbl_TotalCost.Text);
                    dt.Rows.Add(name, int.Parse(txt_Quantity_Number.Text), Packu_Cost, Total_Cost);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {

                if (txt_Item_Name.Text == "")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void txt_Packu_Cost_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            //txt_Quantity_Number.Enabled = true;
            try
            {
                if (txt_Quantity_Number.Text != "" && txt_Item_Name.Text != "" && txt_Packu_Cost.Text != "")
                {
                    var name = txt_Item_Name.Text;
                    float Quantity_Number = float.Parse(txt_Quantity_Number.Text);
                    float Packu_Cost = float.Parse(txt_Packu_Cost.Text);
                    float Total_receipt = Packu_Cost * Quantity_Number;
                    Lbl_TotalCost.Text = Convert.ToString(Total_receipt);
                    dt.Rows.Add(name, int.Parse(txt_Quantity_Number.Text), Packu_Cost, Total_receipt);
                    dataGridView1.DataSource = dt;
                    //txt_Quantity_Number.Text = "";
                    //txt_Quantity_Number.Enabled = false;
                }
            }
            catch (Exception)
            {

                if (txt_Item_Name.Text == "")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
                }
            }
        }

        private void txt_Item_Name_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            var x_text = brada.Tbl_Items.Select(s => s.Item_Name).ToList();

            foreach (var item in x_text)
            {
                MyCollection.Add(item);
            }

            txt_Item_Name.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Item_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            txt_Item_Name.AutoCompleteCustomSource = DataCollection;
            try
            {
                if (!search_ITems(txt_Item_Name.SelectedText))
                {
                    for (int i = 0; i <= txt_Item_Name.Text.Length; i++)
                    {
                        var details = brada.Tbl_Items.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => new { ID = s.ID, Name = s.Item_Name, packuprice = s.Packu_Price, Quantity_tbl_Item_Num = s.Quantity_Num }).SingleOrDefault();
                        txt_Item_Name.Text = details.Name.ToString();
                        txt_Packu_Cost.Text = details.packuprice.ToString();
                        int Quantity_tbl_Item_Num = details.Quantity_tbl_Item_Num;
                        label13.Text = Quantity_tbl_Item_Num.ToString();
                    }
                }
            }
            catch (Exception)
            {
                if (txt_Item_Name.Text == "")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
                }
            }
        }

        private void Btn_Impleme_Update_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Impleme_Update_Click_1(object sender, EventArgs e)
        {
            if (txt_ItemName_Edit.Text != "" && txt_QuantityNum_Edit.Text != "" &&txt_Packu_Price_Edit.Text!="")
            {
                //var Daily = brada.Tbl_Daily_operations.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => new { Quantity_tbl_Daily_Num = s.Quantity_Number }).SingleOrDefault();
                //int Daily_Quantity = Daily.Quantity_tbl_Daily_Num;
                ////int Update_Result = int.Parse(cel1) + Daily_Quantity;
                //var Quantity_Daily_updated = int.Parse(cel1) + Daily_Quantity;
                ////Update Proc
                //brada.update_Addition_Tbl_Daily(ID, cel0, Quantity_Daily_updated, float.Parse(cel2), float.Parse(cel3), date, receipt_num);
                
                
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    var cel0 = row.Cells[0].Value.ToString();
                    var cel1 = row.Cells[1].Value.ToString();
                    var cel2 = row.Cells[2].Value.ToString();
                    var cel3 = row.Cells[3].Value.ToString();
                    var selectedid = brada.Tbl_Daily_operations.Where(s => s.Item_Name == txt_ItemName_Edit.Text).Select(s => s.ID).SingleOrDefault();
                    var newname = txt_ItemName_Edit.Text;
                    ////
                    float Lbl_Edit_Exist1 = float.Parse(Lbl_Edit_Exist.Text);
                    float Quantity_Number = float.Parse(txt_QuantityNum_Edit.Text);
                    float Packu_Cost = float.Parse(txt_Packu_Price_Edit.Text);
                    float Total_receipt2 = Packu_Cost * Quantity_Number;
                    Lbl_TotalCost_Edit.Text = Convert.ToString(Total_receipt2);

                    float Added_Quantity_Num = Lbl_Edit_Exist1 + Quantity_Number;
                    string str_Added_Quantity_Num = Added_Quantity_Num.ToString();
                    float Changed_Value_after_Added = Added_Quantity_Num * Packu_Cost;
                    string str_Changed_Value_after_Added = Changed_Value_after_Added.ToString();
                    brada.update_Tbl_Daily(selectedid, newname,Convert.ToInt32(Added_Quantity_Num), Packu_Cost,Convert.ToDouble(str_Added_Quantity_Num));

                    var details = brada.Tbl_Items.Where(s => s.Item_Name == txt_ItemName_Edit.Text).Select(s => new { ID = s.ID, Quantity__Item_Num = s.Quantity_Num }).SingleOrDefault();
                    int item_Code = details.ID;
                    int Quantity_tbl_Item_Num = details.Quantity__Item_Num;
                    int Quantity_Subtracted_DailyOPeration = Convert.ToInt32(txt_QuantityNum_Edit.Text);
                    int Tbl_Item_Result_after_Subtract = Quantity_tbl_Item_Num - Quantity_Subtracted_DailyOPeration;
                    var ID = details.ID;
                    brada.Subtract_Update_Tbl_Item_Daily(ID, Tbl_Item_Result_after_Subtract);
                }
                
                brada.SubmitChanges();
                Btn_Impleme_Update.Text = "تم التعديل";
            }
            else
            {
                MessageBox.Show("Press Edit Item,إضغط تعديل صنف");
            }
        }

        private void Btn_Delete_Item_Click(object sender, EventArgs e)
        {
            Btn_Delete_Confirm.Text = "تأكيد الحذف";
            label14.Visible=true;
            txt_Delete_item.Visible = true;
            txt_Delete_item.Clear();
            groupBox3.Visible = false;
            groupBox6.Visible = false;
            groupBox4.Visible = true;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Impleme_Update.Visible = false;
            Btn_Delete_Confirm.Visible = true;

        }

        private void Btn_Delete_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Delete_item.Text != "" )
            {
                var selectedid = brada.Tbl_Daily_operations.Where(s => s.Item_Name == txt_Delete_item.Text).Select(s => s.ID).SingleOrDefault();
                brada.delin_Daily_OPeration(selectedid);
                brada.SubmitChanges();
                Btn_Delete_Confirm.Text = "تم الحذف";
            }
            else
            {
                MessageBox.Show("Press Delete Item,إضغط حذف صنف");
            }
        }

        private void txt_ItemName_Edit_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            var x_text = brada.Tbl_Daily_operations.Select(s => s.Item_Name).ToList();
            foreach (var item in x_text)
            {
                MyCollection.Add(item);
            }
            txt_ItemName_Edit.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_ItemName_Edit.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            txt_ItemName_Edit.AutoCompleteCustomSource = DataCollection;
            try
            {
                if (search_daily(txt_ItemName_Edit.Text))
                {
                    for (int i = 0; i <= txt_ItemName_Edit.Text.Length; i++)
                    {
                        var details = brada.Tbl_Daily_operations.Where(s => s.Item_Name == txt_ItemName_Edit.Text).Select(s => new { ID = s.ID, packuprice = s.Packu_Price, s.Quantity_Number, totCost = s.Total_Cost }).SingleOrDefault();
                        Lbl_Edit_Exist.Text = details.Quantity_Number.ToString();
                        txt_Packu_Price_Edit.Text = details.packuprice.ToString();
                        Lbl_TotalCost_Edit.Text = details.totCost.ToString();
                        var details2 = brada.Tbl_Items.Where(s => s.Item_Name == txt_ItemName_Edit.Text).Select(s => new { ID = s.ID, Quantity_Available_TBLITems= s.Quantity_Num}).SingleOrDefault();
                        Lbl_Edit_Available.Text = details2.Quantity_Available_TBLITems.ToString();
                    }
                }    
            }
            catch (Exception)
            {
                if (txt_Item_Name.Text == "")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
                }
            }
        }

        private void txt_QuantityNum_Edit_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            try
            {
                if (txt_ItemName_Edit.Text != "" && txt_Packu_Price_Edit.Text != "")
                {
                    var name = txt_ItemName_Edit.Text;
                    float Lbl_Edit_Exist1 = float.Parse(Lbl_Edit_Exist.Text);

                    float Quantity_Number = float.Parse(txt_QuantityNum_Edit.Text);
                    float Packu_Cost = float.Parse(txt_Packu_Price_Edit.Text);
                    float Total_receipt2 = Packu_Cost * Quantity_Number;
                    Lbl_TotalCost_Edit.Text = Convert.ToString(Total_receipt2);

                    float Added_Quantity_Num = Lbl_Edit_Exist1 + Quantity_Number;
                    string str_Added_Quantity_Num = Added_Quantity_Num.ToString();
                    float Changed_Value_after_Added = Added_Quantity_Num * Packu_Cost;
                    
                    dt.Rows.Add(name, int.Parse(str_Added_Quantity_Num), Packu_Cost, Changed_Value_after_Added);
                    dataGridView1.DataSource = dt;
                        
                    //txt_Quantity_Number.Enabled = false;
                }
            }
            catch (Exception)
            {

                if (txt_Item_Name.Text == "")
                {
                    txt_Item_Name.Text = txt_Packu_Cost.Text = "";
                }
            }
            
        }

        private void txt_Packu_Price_Edit_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            //txt_Quantity_Number.Enabled = true;
            try
            {
                if (txt_QuantityNum_Edit.Text != "" && txt_ItemName_Edit.Text != "" && txt_Packu_Price_Edit.Text != "")
                {
                    var name = txt_ItemName_Edit.Text;
                    float Quantity_Number = float.Parse(txt_QuantityNum_Edit.Text);
                    float Packu_Cost = float.Parse(txt_Packu_Price_Edit.Text);
                    float Total_receipt = Packu_Cost * Quantity_Number;
                    Lbl_TotalCost_Edit.Text = Convert.ToString(Total_receipt);
                    dt.Rows.Add(name, int.Parse(txt_QuantityNum_Edit.Text), Packu_Cost, Total_receipt);
                    dataGridView1.DataSource = dt;
                    
                }
            }
            catch (Exception)
            {

                if (txt_Item_Name.Text == "")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
                }
            }
        }

        private void txt_Delete_item_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (search_daily(txt_Delete_item.Text))
                //{
                //    for (int i = 0; i <= txt_Delete_item.Text.Length; i++)
                //    {
                //        var details = brada.Tbl_Daily_operations.Where(s => s.Item_Name == txt_Delete_item.Text).Select(s => new { ID = s.ID, packuprice = s.Packu_Price, s.Quantity_Number, totCost = s.Total_Cost }).SingleOrDefault();
                //        txt_QuantityNum_Edit.Text = details.Quantity_Number.ToString();
                //        txt_Packu_Price_Edit.Text = details.packuprice.ToString();
                //        Lbl_TotalCost_Edit.Text = details.totCost.ToString();
                //    }
                //}
                dt.Clear();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                var x_text = brada.Tbl_Daily_operations.Select(s => s.Item_Name).ToList();
                foreach (var item in x_text)
                {
                    MyCollection.Add(item);
                }
                txt_Delete_item.AutoCompleteMode = AutoCompleteMode.Suggest;
                txt_Delete_item.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = (MyCollection);
                txt_Delete_item.AutoCompleteCustomSource = DataCollection;
            }
            catch (Exception)
            {
                if (txt_Item_Name.Text == "")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
                }
            }
        }
    }
}
