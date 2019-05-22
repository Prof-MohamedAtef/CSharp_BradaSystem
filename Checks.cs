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
    public partial class Checks : Form
    {
        BradaDataClassesDataContext Brada = new BradaDataClassesDataContext();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dtstatic = new DataTable();

        float total = 0;
        float add_val = 0;
        float disc_val = 0;
        float final_cost = 0;
        int dt_count = 1;
        public Checks(string str_Value,string str_hall)
        {
            InitializeComponent();
            Lbl_TBl_Number.Text = str_Value;
            Lbl_Hall_Name.Text = str_hall;
        }

        private void Checks_Load(object sender, EventArgs e)
        {
            Btn_Move_Accounting.Visible = false;
            txt_receipt_Date.Text = System.DateTime.Now.Date.ToString();
            var maxId = Brada.item_orders.Max(s => s.order_id);
            txt_receipt_Num.Text =( maxId + 1).ToString();
            dateTimePicker1.Visible = false;
            checkBox1.Visible = false;
            dataGridView3.Visible = false;
            Implement_Check_Query.Enabled = false;
            dataGridView2.Visible = false;

            //this.reportViewer1.RefreshReport();
            dt.Columns.Add("مسلسل", typeof(int));
          
            dt.Columns.Add("اسم الصنف", typeof(string));
            dt.Columns.Add("العدد", typeof(int));
            dt.Columns.Add("السعر", typeof(float));
            dt.Columns.Add("الإجمالى", typeof(float));
            //  this.reportViewer1.RefreshReport();
            dt2.Columns.Add("رقم الفاتورة", typeof(int));
            dt2.Columns.Add("التاريخ", typeof(string));
            dt2.Columns.Add("رقم الترابيزه", typeof(int));
            dt2.Columns.Add("القاعة", typeof(string));
            dt2.Columns.Add("% نسبه الخصم", typeof(float));
            dt2.Columns.Add("الضريبه المضافه", typeof(float));
            dt2.Columns.Add("تكلفه الفاتوره", typeof(float));
            dt2.Columns.Add("طريقه الدفع", typeof(string));
            dtstatic.Columns.Add("اسم الصنف", typeof(string));
            dtstatic.Columns.Add("العدد", typeof(int));
            dtstatic.Columns.Add("السعر", typeof(float));
            dtstatic.Columns.Add("الإجمالى", typeof(float));
            
            dt3.Columns.Add("اسم الصنف", typeof(string));
            dt3.Columns.Add("العدد", typeof(int));
            dt3.Columns.Add("السعر", typeof(int));
            dt3.Columns.Add("الاجمالى", typeof(float));

            ////////to view Halls in Comboobox

            var places = Brada.Tbl_Casheir_names.Select(s => new { ID = s.ID , name=s.Casheir}).ToList();
            foreach (var item in places)
            {
                Combo_Casheir_Place.Items.Add(item.name);
            }
            Combo_Casheir_Place.ValueMember = "ID";
            Combo_Casheir_Place.DisplayMember = "Place";

            if (txt_receipt_Num.Text == "" && txt_receipt_Date.Text == "")
            {
                txt_receipt_Date.Text = Convert.ToString(DateTime.Now);
                var maxid = Brada.Tbl_Orders.Max(s => s.order_id);
                txt_receipt_Num.Text = (maxid + 1).ToString();
            }


            //this.reportViewer1.RefreshReport();
        }
        Menu m = new Menu();
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }
        private bool ValueIsValid(string text_value)
        {
            // Do not allow spaces.
            if (text_value.Contains(' ')) return false;
            // Allow a blank value.
            if (text_value.Length == 0) return true;
            // If the text doesn't end in a digit, add a digit
            // to see if it is a valid prefix of a float.

            if (!char.IsDigit(text_value, text_value.Length - 1))
                text_value += "0";
            // See if the text parses.
            float test_value;
            return float.TryParse(text_value, out test_value);

        }
        

        private void txt_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txt_value.Text != "" && Lbl_Total_Cost_Result.Text != "")
                {
                    txt_Check_remaining.Clear();
                    var taxvalll = txt_value.Text;

                    var total_costt = total;
                    if (txt_value.Text != "" && Combo__tax_Discount.SelectedIndex == 1)
                    {
                        add_val = float.Parse(taxvalll);
                        total_costt = (total_costt * float.Parse(taxvalll)) / 100;
                        total += total_costt;
                        //label2.Text = total.ToString();
                        txt_Check_remaining.Text = total.ToString();
            //            txt_value.Text = "";


                    }
                    else if (txt_value.Text != "" && Combo__tax_Discount.SelectedIndex == 0)
                    {
                        disc_val = float.Parse(taxvalll);
                        total_costt = (total_costt * float.Parse(taxvalll)) / 100;
                        total -= total_costt;
                        txt_Check_remaining.Text = total.ToString();

                        //label2.Text = total.ToString();
              //          txt_value.Text = "";
                    }


                }
                else MessageBox.Show("تاكد من ادخال اصناف للفاتوره");    
            
              
            }
            
        }

        private void Add_Checks_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            total = 0;
            i = 0;
            dt3.Clear();
            dt.Clear();
            dt2.Clear();
            //dtstatic.Clear();
            //dataGridView1.DataSource = dt2;
            //dataGridView1.Rows.Clear();
            txt_Check_remaining.Text = "";
            txt_receipt_Date.Enabled = false;
            LBL_Packu_Price.Text = "";
            //txt_receipt_Num.Enabled = false;
            Lbl_TBl_Number.Enabled = false;
            checkBox1.Enabled = false;
            Combo_Casheir_Place.Enabled = false;
            Combo_Payment_method.Enabled = false;
            //Combo_Casheir_Place.Enabled = false;
            dateTimePicker1.Enabled = false;
            Btn_Show_tables.Enabled = true;
            Btn_Stock.Text = "ترصيد";
            Btn_Move_Accounting.Text = "ترحيل للحسابات";
            Btn_Addition_Confirm.Text = "تأكيد";
            Combo__tax_Discount.ResetText();
            Combo_Casheir_Place.ResetText();
            Lbl_Hall_Name.Text = "";
            Combo_Payment_method.ResetText();
            //txt_receipt_Num.Text = "";
            //txt_receipt_Date.Text = "";
            Lbl_TBl_Number.Text = "";
            txt_Add_Item.Text = "";
            txt_Add_Quantity.Text = "";
           // label10.Text = "";
            //Txt_Price.Text = "";
            Lbl_Total_Cost_Result.Text = "";
          //  label2.Text = "";
            txt_value.Text = "";
            Combo__tax_Discount.ResetText();
            txt_receipt_Date.Text = System.DateTime.Now.ToShortDateString();
            MessageBox.Show("Choose Table Number immediately\n إختر رقم الترابيزة أولا");
        }

        public bool if_orderid_exist(int x)
        {
            try
            {
                var all_order_id = Brada.Tbl_Orders.Select(s => s.order_id).ToList();
                foreach (var item in all_order_id)
                {
                    if (item == x)
                    {
                        return true;
                    }
                    else return false;
                }
                return true;

            }
            catch (Exception) { return false; }
           
        }

        private void Btn_Stock_Click(object sender, EventArgs e)
        {
            var o_id = int.Parse(txt_receipt_Num.Text);
            if (Btn_Stock.Text=="ترصيد")
            {
                
               

                if( txt_receipt_Num.Text != "" && Lbl_Hall_Name.Text != "" && Lbl_TBl_Number.Text != "" && Combo_Payment_method.Text != "" && Combo_Casheir_Place.Text != ""&&txt_value.Text!=""&&Lbl_Total_Cost_Result.Text!=""&&txt_Check_remaining.Text!="")
                {
                    if (dataGridView1.RowCount !=0)
                    {
                        
                        for (int i = 0; i < dataGridView1.RowCount ; i++)
                        {
                            DataGridViewRow row = dataGridView1.Rows[i];
                            var cel0 = row.Cells[0].Value.ToString();
                            var cel1 = row.Cells[1].Value.ToString();//
                            var cel2 = row.Cells[2].Value.ToString();//
                            var cel3 = row.Cells[3].Value.ToString();
                            var item_id = Brada.Tbl_Casheir_Sales.Where(s => s.Item_Name == cel0).Select(s => s.ID).SingleOrDefault();
                            var or_maxid = Brada.Tbl_Orders.Max(s => s.ID);

                            Brada.ins_order(o_id, item_id, int.Parse(cel2), int.Parse(cel3));
                            Brada.SubmitChanges();
                            
                        }
                        var item_order_max = Brada.item_orders.Max(s => s.ID);
                        var item_order_id = item_order_max + 1;
                        var table_num = int.Parse(Lbl_TBl_Number.Text);
                        var p_name = Lbl_Hall_Name.Text;
                        var qa3aname = Brada.TablePlaces.Where(s => s.Tableplace1 == p_name).Select(s => s.ID).SingleOrDefault();
                        var table_id = Brada.TBL_Numbers.Where(s => s.TBLPlace_ID == qa3aname && s.Numbers == table_num).Select(s => s.TBL_ID).SingleOrDefault();
                        var zz = System.DateTime.Now;
                        if (Combo_Payment_method.SelectedIndex == 0)
                        {
                            Brada.ins_item_order(item_order_id, 6, o_id, total, zz, table_id, add_val, disc_val, final_cost, "كاش");
                            Brada.SubmitChanges();
                        }
                        else if (Combo_Payment_method.SelectedIndex == 1)
                        {
                            Brada.ins_item_order(item_order_id, 6, o_id, total, zz, table_id, add_val, disc_val, final_cost, "اجل");
                            Brada.SubmitChanges();
                        }
                        Btn_Stock.Text = "إلغاء الترصيد";
                    }
                    else
                    {
                        MessageBox.Show("تأكد من ادخال اصناف ");
                    }
                }
                else
                {
                    MessageBox.Show(" تاكد من اختيار القاعه ورقم الترابيزه وطريقه السداد و الكاشير و الأصناف المحدد و من ثم التكلفة النهائية ");
                }
            }
            else MessageBox.Show("تم انشاء الفاتوره بالفعل");
            //----------
            //try
            //{
            //txt_Add_Item.Text != "" && txt_Store_value.Text != "" && txt_Add_Quantity.Text != "" && Txt_Price.Text != "" && Lbl_Total_Cost_Result.Text != "" && txt_value.Text != "" && txt_Check_remaining.Text != "" && Combo__tax_Discount.Text != ""
            //checkBox1.Checked == true &&
            ////-------------------
            //Tbl_Order O = new Tbl_Order {ID=4, item_id=int.Parse(cel0),order_id=p_id,quantity=int.Parse(cel2),price=int.Parse(cel3)};
            // var o_id = int.Parse(txt_receipt_Num.Text);//order id
            //----------------------
            //----
            ////////////to store final cost
            //float add_val = 0;
            //float disc_val = 0;
            //float final_cost = 0;
            //var io_maxid = Brada.item_order.Max(s=>s.ID);//item_order id
            //var taxval = txt_added_value.Text;
            //var disccount = txt_disccount.Text;
            //var p_id = Brada.TablePlaces.Where(s => s.ID == Combo_Hall.SelectedIndex).Select(s => s.ID).SingleOrDefault();
            //--
            ////////////----------------------------------
            //MessageBox.Show("Check all of { Item name, Preferred Quantity, Price, Total Cost, discount or taxe added, and Final Cost} which may be left blank \n تحقق من إسم و سعر و كمية الصنف و القيمة الإجمالية و النهائية بعد الخصم أو الضريبة ");
            ///////-----------------------------
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("System is Busy, Please wait a moment ! \n السيستم مشغول ، فضلا إنتظر قليلا !");
            //}
                
                //Btn_Move_Accounting.Visible = true;
                //try
                //{
                //    if (Btn_Stock.Text == "إلغاء الترصيد" && Btn_Move_Accounting.Text == "إلغاء الترحيل")
                //    {
                //        Btn_Stock.Text = "ترصيد";
                //    }
                //}
                //catch (Exception)
                //{
                    
                //    throw;
                //}    
            
            
        }


        public bool search_daily(string search_item)
        {
            var allnames = Brada.Tbl_Casheir_Sales.Select(s => s.Item_Name).ToList();
            foreach (var item in allnames)
            {
                if (item == search_item)
                {
                    return true;

                }
            }
            return false;
        }

        private void txt_Add_Item_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            var allitems = Brada.Tbl_Casheir_Sales.Select(s => s.Item_Name).ToList();
            foreach (var item in allitems)
            {
                MyCollection.Add(item);
            }

            txt_Add_Item.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Add_Item.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            txt_Add_Item.AutoCompleteCustomSource = DataCollection;

            try
            {
                if (!search_daily(txt_Add_Item.SelectedText))
                {
                    for (int i = 0; i <= txt_Add_Item.Text.Length; i++)
                    {
                        var details = Brada.Tbl_Casheir_Sales.Where(s => s.Item_Name == txt_Add_Item.Text).Select(s => new { ID = s.ID, Name = s.Item_Name, packuprice = s.Item_Price }).SingleOrDefault();

                        txt_Add_Item.Text = details.Name.ToString();
                        LBL_Packu_Price.Text = details.packuprice.ToString();

                        //label10.Enabled = false;
                        //label10.Text = details.Quanti.ToString();
                    }
                }
            }
            catch (Exception)
            {
            //    if (txt_Add_Item.Text == "")
            //    {
            //        MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");
            //    }
            }
            
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Table_Choose t = new Table_Choose();
            t.Show();
        }
        
        
        float cost;

        private void Implement_Check_Query_Click(object sender, EventArgs e)
        {
                        dt2.Clear();
            //try
            //{
                if (checkBox1.Checked==true)
                {
                    
                //    dataGridView1.Rows.Clear();
                    //var current = int.Parse(txt_receipt_Num.Text);
                    var dd = dateTimePicker1.Value;
                    //try
                    //{ هنا انتى عاوزه تجيبى الحاجات دى او الاعمدة دى من الجدول ده 
                    //select items using date - رقم الاوردر ، التاريخ ، رقم الترابيزة ، قيمة الخصم ، قيمة الضريبة ، التكلفة الإجمالى ، و النهائية ، و طريقة الدفع 
                    var prev = Brada.item_orders.Where(s => s.date.Value.Date == dd.Date).Select(s => new{s.order_id,s.date,s.TBL_Num,s.discount_val,s.Tax_val,s.total_cost,s.final_cost,s.payment }).ToList();

                    foreach (var item in prev)
                    
                    { 
                        var tableNum = Brada.TBL_Numbers.Where(s => s.TBL_ID == item.TBL_Num).Select(s => new { s.Numbers, s.TBLPlace_ID }).SingleOrDefault();
                        var orderID = item.order_id;
                        var d = item.date.ToString();
                        var table_num = tableNum.Numbers;
                        var place_name = Brada.TablePlaces.Where(s => s.ID == tableNum.TBLPlace_ID).Select(s => s.Tableplace1).SingleOrDefault();
                        var discount_val = item.discount_val;
                        var add_val = item.Tax_val;
                        if (item.final_cost != 0)
                        {
                            // لو كان فيه قيمه غير ال 0 ياخد الموجود فى ال
                            cost = float.Parse(item.final_cost.ToString());
                        }
                        else
                            cost = float.Parse(item.total_cost.ToString());
                        var pay_method = item.payment;
                        dataGridView1.Visible = false;
                        dataGridView3.Visible = true;
                        dt2.Rows.Add(orderID, d, table_num, place_name, discount_val, add_val, cost, pay_method);
                        dataGridView3.DataSource = dt2;
                        foreach (DataGridViewRow row in dataGridView3.Rows)
                        {
                            row.ReadOnly = true;
                        }
                    }    
                }
                else
                {
                    MessageBox.Show("Select Date checkbox at First !");
                }
                
////            }
////            catch (Exception)
////            {
////// Unknown Error                
////                throw;
////            }
            

                //}
                //catch (Exception)
                //{

                //    MessageBox.Show("لا يوجد شيكات سابقه");
                //}
             
        }

        private void Query_Checks_Click(object sender, EventArgs e)
        {
            Lbl_Hall_Name.Text = "";
            //MessageBox.Show("إختر التاريخ المناسب");
            Btn_Stock.Text = "ترصيد";
            Btn_Move_Accounting.Text = "ترحيل للحسابات";
            Btn_Addition_Confirm.Text = "تأكيد";
            Combo__tax_Discount.ResetText();
            Combo_Casheir_Place.ResetText();
            txt_receipt_Date.Enabled = true;
            dateTimePicker1.Visible = true;
            checkBox1.Visible = true;
            LBL_Packu_Price.Text = "";
            txt_receipt_Num.Enabled = true;
            Lbl_TBl_Number.Enabled = true;
            checkBox1.Enabled = true;
            Combo_Casheir_Place.Enabled = true;
            Combo_Payment_method.Enabled =true;
            //Combo_Casheir_Place.Enabled = false;
            dateTimePicker1.Enabled = true;
            Btn_Show_tables.Enabled = true;
            Combo_Payment_method.ResetText();
            txt_receipt_Num.Text = "";
            txt_receipt_Date.Text = "";
            Lbl_TBl_Number.Text = "";
            txt_Add_Item.Text = "";
            txt_Add_Quantity.Text = "";
            //label10.Text = "";
            
            dt.Clear();
            dt2.Clear();
            dt3.Clear();
            Lbl_Total_Cost_Result.Text = "";
           // label2.Text = "";
            txt_value.Text = "";
            Combo__tax_Discount.ResetText();
            LBL_Packu_Price.Text = "";
        }
        
        private void txt_Add_Quantity_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.Enabled = true;
            
            //dt.Clear();
            //dtstatic.Clear();
            //try
            //{
            //    if (txt_Add_Quantity.Text != "" && txt_Add_Item.Text != "")
            //    {
            //        var vv = txt_Add_Item.Text;
            //        var details = Brada.Tbl_Daily_operations.Where(s => s.Item_Name == txt_Add_Item.Text).Select(s => new { ID = s.ID, Name = s.Item_Name, packuprice = s.Packu_Price, Quanti = s.Quantity_Number }).SingleOrDefault();
            //        var quantity_grid = int.Parse(txt_Add_Quantity.Text);
            //        var packu_price = details.packuprice;
            //        var totalcost = quantity_grid * packu_price;
            //        dt.Rows.Add( details.Name, quantity_grid, packu_price, totalcost);
            //        dataGridView1.DataSource = dt;
            //        //dtstatic.Rows.Add(details.Name, quantity_grid, packu_price, totalcost);
            //        //dataGridView3.DataSource = dtstatic;
            //        Txt_Price.Text = totalcost.ToString();
                    

            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Fill Blank\n إملأ الفراغات");
            //}
        }

        
        
        int i = 0;
        private void txt_Add_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Add_Quantity.Focus();
            }
        }

        private void Txt_Price_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            //dataGridView3.Enabled = true;
        }

        

        private void Txt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var rows_count = dataGridView1.RowCount;
                do
                {
                    if (i != rows_count)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        //var x = row.Index;
                        float p = float.Parse( row.Cells[3].Value.ToString());
                        total += p;
                        i++;
                    }
                } while (i < rows_count);
                Lbl_Total_Cost_Result.Text = total.ToString()+" L.E";
                txt_Add_Item.Text = "";
                txt_Add_Quantity.Text = "";
                //label10.Text = "";
                LBL_Packu_Price.Text = "";
                
                txt_Add_Item.Focus();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
        int curRow ;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            curRow = dataGridView1.CurrentRow.Index;
            DataGridViewRow row = dataGridView1.Rows[curRow];
            var cel0 = row.Cells[0].Value.ToString();
            txt_Add_Item.Text = row.Cells[1].Value.ToString();
            txt_Add_Quantity.Text = row.Cells[2].Value.ToString();
            LBL_Packu_Price.Text = row.Cells[3].Value.ToString();
            


        }

        private void btn_Check_Previous_Click(object sender, EventArgs e)
        {
            MessageBox.Show(curRow.ToString());
            dt3.Clear();
            try
            {
                if (dataGridView3.CurrentRow.Index != -1)
                {
                    curRow = dataGridView3.CurrentRow.Index;
                    //MessageBox.Show(curRow.ToString());
                    try
                    {
                        DataGridViewRow row = dataGridView3.Rows[curRow - 1];
                        var cel0 = int.Parse(row.Cells[0].Value.ToString());
                        var cel1 = row.Cells[1].Value.ToString();

                        var details_order = Brada.Tbl_Orders.Where(s => s.order_id == cel0).Select(s => new { s.item_id, s.quantity, s.price }).ToList();
                        foreach (var item in details_order)
                        {
                            
                            var item_name = Brada.Tbl_Casheir_Sales.Where(s => s.ID == item.item_id).Select(s => s.Item_Name).SingleOrDefault();
                            var count = item.quantity;
                            var egmaly = item.price * count;
                            dt3.Rows.Add(item_name, count, item.price, egmaly);
                            dataGridView2.DataSource = dt3;
                        }

                    }
                    catch (Exception) { MessageBox.Show(" لا يوجد فواتير لعرضها"); }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
              //  MessageBox.Show("Choose date first, then check your orders\nإختر التاريخ أولا ثم إستعلم عن شيكاتك ");
            }
            
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(curRow.ToString());
            dt3.Clear();
           // MessageBox.Show(curRow.ToString());
            if (dataGridView3.CurrentRow.Index != -1)
            {
                //prev_row = dataGridView1.CurrentRow.Index+1;
                //MessageBox.Show(curRow.ToString());
                try
                {
                    DataGridViewRow row = dataGridView3.Rows[curRow + 1];
                    var cel0 = int.Parse(row.Cells[0].Value.ToString());
                    var cel1 = row.Cells[1].Value.ToString();

                    var details_order = Brada.Tbl_Orders.Where(s => s.order_id == cel0).Select(s => new { s.item_id, s.quantity, s.price }).ToList();
                    foreach (var item in details_order)
                    {
                        var item_name = Brada.Tbl_Casheir_Sales.Where(s => s.ID == item.item_id).Select(s => s.Item_Name).SingleOrDefault();
                        var count = item.quantity;
                        var egmaly = item.price * count;
                        dt3.Rows.Add(item_name, count, item.price, egmaly);
                        dataGridView2.DataSource = dt3;
                    }
                }catch(Exception){   MessageBox.Show(" لا يوجد فواتير لعرضها");}
            }
          

        }
        int ii;
        private void button2_Click(object sender, EventArgs e)
        {
            dt3.Clear();
            if (dataGridView3.RowCount > 0)
            {
                //prev_row = dataGridView1.CurrentRow.Index + 1;
                //MessageBox.Show(curRow.ToString());
                ii = 0;
                DataGridViewRow row = dataGridView3.Rows[ii];
                var cel0 = int.Parse(row.Cells[0].Value.ToString());
                var cel1 = row.Cells[1].Value.ToString();

                var details_order = Brada.Tbl_Orders.Where(s => s.order_id == cel0).Select(s => new { s.item_id, s.quantity, s.price }).ToList();
                foreach (var item in details_order)
                {
                    //    dt2.Columns.Add("كود الصنف", typeof(int));
                    //    dt2.Columns.Add("اسم الصنف", typeof(string));
                    //    dt2.Columns.Add("العدد", typeof(int));
                    var item_name = Brada.Tbl_Casheir_Sales.Where(s => s.ID == item.item_id).Select(s => s.Item_Name).SingleOrDefault();
                    var count = item.quantity;
                    var egmaly = item.price * count;
                    dt3.Rows.Add(item_name, count, item.price, egmaly);
                    dataGridView2.DataSource = dt3;
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt3.Clear();
            ii = dataGridView3.RowCount-1;
            DataGridViewRow row = dataGridView3.Rows[ii];
            var cel0 = int.Parse(row.Cells[0].Value.ToString());
            var cel1 = row.Cells[1].Value.ToString();
            
            var details_order = Brada.Tbl_Orders.Where(s => s.order_id == cel0).Select(s => new { s.item_id, s.quantity, s.price }).ToList();
            foreach (var item in details_order)
            {

                var item_name = Brada.Tbl_Casheir_Sales.Where(s => s.ID == item.item_id).Select(s => s.Item_Name).SingleOrDefault();
                var count = item.quantity;
                var egmaly = item.price * count;
                dt3.Rows.Add(item_name, count, item.price, egmaly);
                dataGridView2.DataSource = dt3;
            }
        }
         private bool ifexist_item(string x)
        {
            //for (int i = 0; i < dataGridView1.RowCount-1; i++)

            try
            {
                //curRow = dataGridView1.CurrentRow.Index;
                //DataGridViewRow row = dataGridView1.Rows[curRow];
                //var curitem = row[1].ToString();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (row.Cells[1].Value.ToString() == x)
                    {

                        return true;
                    }

                }
                return false;
            }

        //}  //TextBox1.Text = row["ImagePath"].ToString();


            catch (Exception)
            {
                return false;
            }




        }

        public float egmaly_check()
        {
            var rows_count = dataGridView1.RowCount;

            do
            {
               // total = 0;
               // i = 0;
                if (i != rows_count)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    var x = row.Index;
                    var p = row.Cells[4].Value.ToString();
                    total += int.Parse(p);
                    i++;
                }


            } while (i < rows_count);

            return total;
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
                if (!ifexist_item(txt_Add_Item.Text))
                {
                    if (txt_Add_Quantity.Text != "")
                    {
                        try
                        {

                            var x = txt_Add_Item.Text;
                            var count = int.Parse(txt_Add_Quantity.Text);

                            var itemdetails = Brada.Tbl_Casheir_Sales.Where(s => s.Item_Name == x).Select(s => new { s.ID, s.Item_Name, s.Item_Price }).SingleOrDefault();
                            var pa_price = itemdetails.Item_Price.ToString();
                            var price = count * int.Parse(pa_price);
                            var unit_price = itemdetails.Item_Price;
                            dt3.Rows.Add(itemdetails.Item_Name, count, float.Parse(unit_price.ToString()), float.Parse(price.ToString()));
                            dataGridView2.DataSource = dt3;


                            txt_Add_Item.Text = txt_Add_Quantity.Text = LBL_Packu_Price.Text = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("تأكد من اسم الصنف");
                            txt_Add_Item.Text = txt_Add_Quantity.Text = LBL_Packu_Price.Text = "";
                        }
                    }

                    total=0;
                    i=0;
                    egmaly_check();
                    Lbl_Total_Cost_Result.Text = total.ToString();
                }
                //else
                //{
                //    MessageBox.Show("الصنف موجود بالفعل يمكنك التعديل بالضغط على تعديل صنف ");
                //    //txt_Add_Item.Text = "";
                //    //txt_Add_Quantity.Text = "";
                //    //----------------------------------------

                //}

           //------------------------ }
            //else txt_Add_Quantity_TextChanged(null, null);
        

            //---------------------------------------------

            //panel1.Visible = true;
            //if (textBox2.Text != "")
            //{
            //    var x = textBox1.Text;
            //    //var count = int.Parse(textBox2.Text);

            //    var details = Brada.Tbl_Daily_operations.Where(s => s.Item_Name == x).Select(s => new { ID = s.ID, Name = s.Item_Name, packuprice = s.Packu_Price, Quanti = s.Quantity_Number }).SingleOrDefault();
            //    var quantity_grid = int.Parse(textBox2.Text);
            //    var packu_price = details.packuprice;
            //    var totalcost = quantity_grid * packu_price;
            //    dt.Rows.Add(details.Name, quantity_grid, packu_price, totalcost);
            //    dataGridView1.DataSource = dt;

            //    textBox3.Text = packu_price.ToString();
            //    textBox3.Text = textBox1.Text = textBox2.Text = "";

            //    //panel1.Visible = false;
            //}
            
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult_delitem = MessageBox.Show("هل تريد حذف هذا الصنف ؟", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult_delitem == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.RowCount != 0 )
                    {
                        dt.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                        dataGridView1.DataSource = dt;

                        
                        total = 0;
                        i = 0;
                        egmaly_check();
                        Lbl_Total_Cost_Result.Text = total.ToString();
                    }
                    else if (dataGridView2.RowCount != 0)
                    {
                        dt3.Rows.RemoveAt(dataGridView2.CurrentCell.RowIndex);
                        dataGridView2.DataSource = dt3;
                    }
                    else { MessageBox.Show("لايوجد اصناف"); }
                }
                catch (Exception)
                {

                    MessageBox.Show("ممسحش ^_^");
                }
            }
            else if (dialogResult_delitem==DialogResult.No)
            {
                //continue
            }

            
        }

       

        private void txt_Add_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == (char)13)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.ReadOnly = true;

                }

                //----------------




                if (!ifexist_item(txt_Add_Item.Text))
                {
                    if (txt_Add_Quantity.Text != "")
                    {
                        try
                        {
                            
                            var x = txt_Add_Item.Text;
                            var count = int.Parse(txt_Add_Quantity.Text);

                            var itemdetails = Brada.Tbl_Casheir_Sales.Where(s => s.Item_Name == x).Select(s => new { s.ID, s.Item_Name, s.Item_Price }).SingleOrDefault();
                            var pa_price = itemdetails.Item_Price.ToString();
                            var price = count * int.Parse(pa_price);
                            var unit_price = itemdetails.Item_Price;
                            dt.Rows.Add( dt_count,itemdetails.Item_Name, count,float.Parse(unit_price.ToString()), float.Parse(price.ToString()));
                            dataGridView1.DataSource = dt;

                            dt_count += 1;
                            txt_Add_Item.Text = txt_Add_Quantity.Text = LBL_Packu_Price.Text = "";
                        }
                        catch (Exception) { MessageBox.Show("تأكد من اسم الصنف");
                        txt_Add_Item.Text = txt_Add_Quantity.Text = LBL_Packu_Price.Text= "";
                        }
                    }




                    //var rows_count = dataGridView1.RowCount;

                    //do
                    //{

                    //    if (i != rows_count)
                    //    {
                    //        DataGridViewRow row = dataGridView1.Rows[i];
                    //        var x = row.Index;
                    //        var p = row.Cells[3].Value.ToString();
                    //        total += int.Parse(p);
                    //        i++;
                    //    }


                    //} while (i < rows_count);
                    egmaly_check();
                    Lbl_Total_Cost_Result.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("الصنف موجود بالفعل يمكنك التعديل بالضغط على تعديل صنف ");
                    //txt_Add_Item.Text = "";
                    //txt_Add_Quantity.Text = "";
                    //----------------------------------------
                    
                }
}
            
            //else txt_Add_Quantity_TextChanged(null, null);
        

        }
        

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.RowCount != 0)
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد التعديل فى الصنف ؟", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        var x = item["اسم الصنف"];
                        if (item["اسم الصنف"].ToString() ==txt_Add_Item.Text)
                        {
                            int curR =int.Parse( item["مسلسل"].ToString());
                            var xx = txt_Add_Item.Text;

                            DataGridViewRow row = dataGridView1.Rows[curR-1];
                            var countt = int.Parse(txt_Add_Quantity.Text);


                            var itemdetailss = Brada.Tbl_Casheir_Sales.Where(s => s.Item_Name == xx).Select(s => new { s.ID, s.Item_Name, s.Item_Price }).SingleOrDefault();
                            var pa_pricee = itemdetailss.Item_Price.ToString();
                            var price = countt * int.Parse(pa_pricee);


                            //if (!ifexist_item(txt_Add_Item.Text))
                            //{
                            //    row.Cells[1].Value = txt_Add_Quantity.Text;
                            row.Cells[2].Value = txt_Add_Quantity.Text;
                                row.Cells[3].Value = pa_pricee;

                                row.Cells[4].Value = price.ToString();
                                dataGridView1.DataSource = dt;
                            //}
                            //else MessageBox.Show("الصنف مكرر لا يمكنك تعديل الاسم ");

                            txt_Add_Item.Text = txt_Add_Quantity.Text = "";
                        }
                    } 
                   

                   

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                total = 0;
                i = 0;
                egmaly_check();
                Lbl_Total_Cost_Result.Text = total.ToString();
            }
            else { MessageBox.Show("لايوجد اصناف"); }
        }

        private void Combo__tax_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Implement_Check_Query.Enabled = true;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dt3.Clear();
                //dataGridView2.Rows.Clear();
                var indexx = dataGridView3.CurrentRow.Index;
                if (dataGridView3.CurrentRow.Index != -1)
                {
                    curRow = dataGridView3.CurrentRow.Index;
                    //MessageBox.Show(curRow.ToString());

                    DataGridViewRow row = dataGridView3.Rows[curRow];
                    var cel0 = row.Cells[0].Value.ToString();
                    var cel1 = row.Cells[1].Value.ToString();
                    // var item_id = Brada.Tbl_Casheir_Sales.Where(s => s.Item_Name == cel0).Select(s => s.ID).SingleOrDefault();
                    
                    var details_order = Brada.Tbl_Orders.Where(s => s.order_id == int.Parse(cel0)).Select(s => new { s.item_id, s.quantity, s.price }).ToList();
                    foreach (var item in details_order)
                    {
                        var item_name = Brada.Tbl_Casheir_Sales.Where(s => s.ID == item.item_id).Select(s => s.Item_Name).SingleOrDefault();
                        var count = item.quantity;
                        var egmaly = item.price * count;
                        dataGridView2.Visible = true;
                        dt3.Rows.Add(item_name, count, item.price, egmaly);
                        dataGridView2.DataSource = dt3;

                    }
                    foreach (DataGridViewRow roww in dataGridView2.Rows)
                    {
                        roww.ReadOnly = true;

                    }

                }
            }
            catch (Exception) { }


        }

        private void Btn_Move_Accounting_Click(object sender, EventArgs e)
        {
            if (Btn_Move_Accounting.Text=="إلغاء الترحيل")
            {
                Btn_Move_Accounting.Text = "ترحيل للحسابات";
                Btn_Stock.Text = "إلغاء الترصيد";
            }
            else if (Btn_Move_Accounting.Text == "ترحيل للحسابات")
            {
                Btn_Move_Accounting.Text = "إلغاء الترحيل";
            }
        }

        

        

        

        

    
      
        }
        


        
    }   

