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
    public partial class Items : Form
    {
        BradaDataClassesDataContext brada = new BradaDataClassesDataContext();
        public Items()
        {
            InitializeComponent();
        }

        private void Btn_Add_Item_Click(object sender, EventArgs e)
        {

            TBL_Receive receive = new TBL_Receive();
            Tbl_Item Item = new Tbl_Item();
            if (txt_receive_date.Text == "" && txt_receive_num.Text == "")
            {
                txt_receive_date.Text = Convert.ToString(DateTime.Now);
                var maxid = brada.TBL_Receives.Max(s => s.recieve_num);
                txt_receive_num.Text = (maxid + 1).ToString();

            }
            txt_Packu_Cost.Clear();
            txt_Code_Item.Clear();
            txt_Item_Name.Clear();
            txt_Quantity_Int_Store.Visible = false;
            txt_Quantity_Number.Clear();
            txt_Peices_Num.Clear();
            txt_Validation_date.Clear();
            txt_TotalCost.Clear();
            Btn_Impleme_Update.Visible = false;
            Btn_Delete_Confirm.Visible = false;
            Btn_Add_Item_Confirm.Visible = true;
            Btn_Add_Item_Confirm.Text = "تأكيد الإضافة";

            Combo_Hall_Name.Visible = false;
            label4.Visible = false;
            
            label8.Visible = false;
            
            Btn_Decrease_Shlal.Visible = false;
            Btn_Increase_Shlal.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            
            txt_money_val.Visible = false;
            txt_Store_Packu.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            txt_Search_Store.Visible = false;
            txt_Packu_Store_Cost.Visible = false;
        }
        public bool search(string search_item)
        {
            var allnames = brada.Tbl_Items.Select(s => s.Item_Name).ToList();
            foreach (var item in allnames)
            {
                if (item == search_item)
                {
                    return true;
                    //continue;
                }
            }
            return false;
        }

        private void Btn_Add_Item_Confirm_Click(object sender, EventArgs e)
        {
            TBL_Receive receive = new TBL_Receive();
            Tbl_Item Item = new Tbl_Item();
            if (txt_receive_date.Text != "" && txt_receive_num.Text != "")
            {
                if (!search(txt_Item_Name.Text))
                {
                    if (txt_Item_Name.Text != "" && txt_Quantity_Number.Text != ""&& txt_Packu_Cost.Text != "" && txt_Validation_date.Text != "" && txt_TotalCost.Text != "")
                    {
                        if (txt_Item_Name.Text != "Empty !!" && txt_Quantity_Number.Text != "Empty !!" && txt_Packu_Cost.Text != "Empty !!" && txt_Validation_date.Text != "Empty !!" && txt_TotalCost.Text != "Empty !!")
                        {
                            receive.recieve_num = int.Parse(txt_receive_num.Text);
                            receive.recieve_Date = DateTime.Parse(txt_receive_date.Text);
                            var newnam = txt_Item_Name.Text;
                            var Quantity_num = int.Parse(txt_Quantity_Number.Text);
                            int Quantity_Num=Convert.ToInt32(Quantity_num);
                            var Peices_num = int.Parse(txt_Peices_Num.Text);
                            int Peices_Num = Convert.ToInt32(Peices_num);
                            var Price = float.Parse(txt_Packu_Cost.Text);
                            float price = Price; 
                            var date = DateTime.Parse(txt_Validation_date.Text);
                            int Quantity_Int = Quantity_Num / Peices_Num;
                            int Quantit_Int_Price =Convert.ToInt32(price *  Peices_Num);
                            var Quantity_int =Quantity_Int;
                            var total_cost = float.Parse(txt_TotalCost.Text);
                            brada.TBL_Receives.InsertOnSubmit(receive);
                            brada.insert_tbl_Item2(newnam, Quantity_num, Price, Peices_num, Quantity_Int, date, total_cost, Quantit_Int_Price);
                            brada.SubmitChanges();
                            Btn_Add_Item_Confirm.Text = "تم الإضافة";

                            //string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy" };
                            //foreach (var date in formats)
                            //{
                            //    if (txt_Validation_date.Text == date)
                            //    {
                                    
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Use MM/dd/yyyy formatting for date");
                            //    }
                            //}


                            //Item.ValidationDate = DateTime.Parse(txt_Validation_date.Text);
                            //string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy" };
                            //string formats = "MM/dd/yyyy 00:00:00.000";
                            ////foreach (var date in formats)
                            ////{
                            //if (txt_Validation_date.Text == formats)
                            //{
                            //    Item.ValidationDate = DateTime.Parse(txt_Validation_date.Text);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Use MM/dd/yyyy formatting for date");
                            //}
                            //}
                            ////--------
                            //if (DateTime.TryParseExact(txt_Validation_date.Text, "MM/dd/yyyy", null, DateTimeStyles.None, out Test) == true)
                            //{
                            //}
                            //----
                            //DateTime dDate;
                            //if (DateTime.TryParse(txt_Validation_date.Text,out dDate) )
                            //{
                            //    String.Format("{0:d/MM/yyyy}", dDate); 
                            //}

                        }
                        else
                        {
                            MessageBox.Show("برجاء املأ الخانات");
                        }

                    }
                    else
                    {
                        MessageBox.Show("برجاء املأ الخانات");
                    }
                    brada.SubmitChanges();
                    //txt_Item_Name.Text = txt_Quantity_Cost.Text = txt_Quantity_Integer.Text = txt_Quantity_Number.Text = txt_TotalCost.Text = txt_Validation_date.Text = "";
                }
                else
                {
                    MessageBox.Show("الاسم مكرر");
                }
            }
            else
            {
                MessageBox.Show("Press Add Item,إضغط إضافة صنف");
            }


            //else
            //{
            //    MessageBox.Show("Press Add Item,إضغط إضافة صنف");
            //}
            //-------------
            //-------------
            //if (txt_receive_date.Text!=""&&txt_receive_num.Text!="")
            //{
            //    if (txt_Item_Name.Text != "" && txt_Cost.Text != "" && txt_Quantity_Integer.Text != "" && txt_Quantity_Number.Text != "" && txt_TotalCost.Text != "" && txt_Validation_date.Text != "" && txt_receive_date.Text != "" && txt_receive_num.Text != "")
            //    {
            //        receive.recieve_num = int.Parse(txt_receive_num.Text);
            //        receive.recieve_Date = DateTime.Parse(txt_receive_date.Text);
            //        Item.Item_Name = txt_Item_Name.Text;
            //        Item.CostPrice = float.Parse(txt_Cost.Text);
            //        Item.QuantityInteger = int.Parse(txt_Quantity_Integer.Text);
            //        Item.QuantityNumber = int.Parse(txt_Quantity_Number.Text);
            //        Item.ValidationDate = DateTime.Parse(txt_Validation_date.Text);
            //        Item.TotalCost = float.Parse(txt_TotalCost.Text);

            //        brada.TBL_Receives.InsertOnSubmit(receive);
            //        brada.TblItems.InsertOnSubmit(Item);
            //        brada.SubmitChanges();
            //        Btn_Add_Item_Confirm.Text = "تم الإضافة";
            //    }   
            //}

            label12.Visible = false;
            label13.Visible = false;
            
            txt_money_val.Visible = false;
            txt_Store_Packu.Visible = false;
            
            label8.Visible = false;
            
            Btn_Decrease_Shlal.Visible = false;
            Btn_Increase_Shlal.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            txt_Search_Store.Visible = false;
            txt_Packu_Store_Cost.Visible = false;    
        }

        private void Btn_Delete_Item_Click(object sender, EventArgs e)
        {
            // محتاج الكود لكل صنف يتكريت تلقائى و يتربط بكل صنف عند البحث
            txt_receive_num.Clear();
            txt_receive_date.Clear();
            txt_Code_Item.Clear();
            txt_Item_Name.Clear();
            txt_Packu_Cost.Clear();
            txt_Peices_Num.Clear();
            txt_Quantity_Number.Clear();
            txt_Validation_date.Clear();
            txt_TotalCost.Clear();

            Combo_Hall_Name.Visible = false;

            
            Btn_Delete_Confirm.Visible = true;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Impleme_Update.Visible = false;
            Btn_Delete_Confirm.Text = "تأكيد الحذف";

            Combo_Hall_Name.Visible = false;

            txt_Search_Store.Visible = false;
            txt_Store_Packu.Visible = false;
            txt_Packu_Store_Cost.Visible = false;
            txt_Quantity_Int_Store.Visible = false;
            txt_money_val.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            label4.Visible = false;
        }

        private void Btn_Delete_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Item_Name.Text != "" && txt_Quantity_Number.Text != "" && txt_TotalCost.Text != "" && txt_Validation_date.Text != "")
            {
                var selectedid = brada.Tbl_Items.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => s.ID).SingleOrDefault();
                //var newname = txt_Item_Name.Text;
                //var newquantitynumber = int.Parse(txt_Quantity_Number.Text);
                
                //var newvalidationdate = DateTime.Parse(txt_Validation_date.Text);
                //var newtotalCost = float.Parse(txt_TotalCost.Text);
                    brada.del(selectedid);
                brada.SubmitChanges();
                Btn_Delete_Confirm.Text = "تم الحذف";
            }
            else
            {
                MessageBox.Show("Press Delete Item,إضغط حذف صنف");
            }
            txt_Search_Store.Visible = true;
            txt_Store_Packu.Visible = true;
            txt_Packu_Store_Cost.Visible = true;
            txt_Quantity_Int_Store.Visible = true;
            txt_money_val.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label15.Visible = true;
            label17.Visible = true;
            label4.Visible = true;
        }

        private void Btn_Edit_Item_Click(object sender, EventArgs e)
        {
            Btn_Impleme_Update.Text = "تنفيذ التعديل";
            Btn_Impleme_Update.Visible = true;
            Btn_Delete_Confirm.Visible = true;
            txt_receive_date.Clear();
            txt_receive_num.Clear();
            txt_Code_Item.Clear();
            txt_Item_Name.Clear();
            txt_Packu_Cost.Clear();
            txt_Peices_Num.Clear();
            txt_Quantity_Number.Clear();
            
            txt_Validation_date.Clear();
            txt_TotalCost.Clear();
            Btn_Delete_Confirm.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;

            Combo_Hall_Name.Visible = false;

            txt_Search_Store.Visible = false;
            txt_Store_Packu.Visible = false;
            txt_Packu_Store_Cost.Visible = false;
            txt_Quantity_Int_Store.Visible = false;
            txt_money_val.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            label4.Visible = false;
            
        }

        private void Btn_Impleme_Update_Click(object sender, EventArgs e)
        {

            if (txt_Item_Name.Text != "" && txt_Quantity_Number.Text != "" && txt_TotalCost.Text != "" && txt_Validation_date.Text != "")
            {
                var selectedid = brada.Tbl_Items.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => s.ID).SingleOrDefault();
                var newname = txt_Item_Name.Text;
                var newquantitynumber = int.Parse(txt_Quantity_Number.Text);
                var newPacku_Price = float.Parse(txt_Packu_Cost.Text);
                var newPeices_num=int.Parse(txt_Peices_Num.Text);
                int Quantity_Num=int.Parse(txt_Quantity_Number.Text);
                int Peices_Num=int.Parse(txt_Peices_Num.Text);
                int Quantity_Int = Quantity_Num / Peices_Num;
                var newQuantity_Int=Quantity_Int;
                var Peices_num = int.Parse(txt_Peices_Num.Text);
                var Price = float.Parse(txt_Packu_Cost.Text);
                int Quantit_Int_Price =Convert.ToInt32(Price *  Peices_Num);
                var newvalidationdate = DateTime.Parse(txt_Validation_date.Text);
                var newtotalCost = float.Parse(txt_TotalCost.Text);
                brada.update_Tbl_Item3(selectedid, newname, newquantitynumber, newPacku_Price, newPeices_num, newQuantity_Int, Quantit_Int_Price, newvalidationdate, newtotalCost);
                brada.SubmitChanges();
                Btn_Impleme_Update.Text = "تم التعديل";
            }
            else
            {
                MessageBox.Show("Press Edit Item,إضغط تعديل صنف");
            }
            txt_Search_Store.Visible = true;
            txt_Store_Packu.Visible = true;
            txt_Packu_Store_Cost.Visible = true;
            txt_Quantity_Int_Store.Visible = true;
            txt_money_val.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label15.Visible = true;
            label17.Visible = true;
            label4.Visible = true;
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void txt_Item_Name_TextChanged(object sender, EventArgs e)
        {
            Tbl_Item Item = new Tbl_Item();
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
                var details = brada.Tbl_Items.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => new { ID = s.ID, Name = s.Item_Name,  Quantity2 = s.Quantity_Num, Packuprice = s.Packu_Price,PeicesNum=s.Peices_Number, ValidDate = s.Validation_Date, totcost = s.TotalCost }).SingleOrDefault();
                txt_Code_Item.Text = details.ID.ToString();
                txt_Quantity_Number.Text = details.Quantity2.ToString();
                txt_Peices_Num.Text = details.PeicesNum.ToString();
                txt_Packu_Cost.Text = details.Packuprice.ToString();
                txt_Validation_date.Text = details.ValidDate.ToShortDateString();
                txt_TotalCost.Text = details.totcost.ToString();
            }
            catch (Exception)
            {
                if (txt_Item_Name.Text=="")
                {
                    MessageBox.Show("Retry Typing Item's Name Correctly\nأعد كتابة إسم الصنف بطريقة صحيحة");    
                }    
            }
        }

        

        private void txt_Quantity_Number_TextChanged(object sender, EventArgs e)
        {
            //if (txt_Quantity_Number.Text == "")
            //{
            //    txt_Quantity_Number.Text = "00";
            //}
        }

        private void txt_Packu_Cost_TextChanged(object sender, EventArgs e)
        {
            //if (txt_Packu_Cost.Text == "")
            //{
            //    txt_Packu_Cost.Text = "0.00";
            //}
            if (txt_Packu_Cost.Text!="")
            {
                float Quantity_Num = float.Parse(txt_Quantity_Number.Text);
                float Packu_Cost = float.Parse(txt_Packu_Cost.Text);
                float Totalcost = Quantity_Num * Packu_Cost;
                txt_TotalCost.Text = Totalcost.ToString();    
            }
            else
            {

            }
            
        }

        private void txt_TotalCost_TextChanged(object sender, EventArgs e)
        {
            if (txt_TotalCost.Text == "")
            {
                txt_TotalCost.Text = "0.00";
            }
        }

        private void txt_Search_Store_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            var x_text = brada.Tbl_Items.Select(s => s.Item_Name).ToList();

            foreach (var item in x_text)
            {
                MyCollection.Add(item);
            }

            txt_Search_Store.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Search_Store.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = (MyCollection);
            txt_Search_Store.AutoCompleteCustomSource = DataCollection;
            try
            {
                var details = brada.Tbl_Items.Where(s => s.Item_Name == txt_Search_Store.Text).Select(s => new { ID = s.ID, Name = s.Item_Name, Quantity2 = s.Quantity_Num, Quan_Int=s.Quantity_Integer, packuprice = s.Packu_Price }).SingleOrDefault();
                txt_Search_Store.Text = details.Name.ToString();
                
                txt_Store_Packu.Text = details.Quantity2.ToString();
                txt_Packu_Store_Cost.Text = details.packuprice.ToString();
                txt_Quantity_Int_Store.Text = details.Quan_Int.ToString();
                int packucost = Convert.ToInt32(txt_Packu_Store_Cost.Text);
                
                int packunum = Convert.ToInt32(txt_Store_Packu.Text);
                int multiplication_result = packucost  * packunum;
                txt_money_val.Text = multiplication_result.ToString();

            }
            catch (Exception)
            {

                txt_Quantity_Number.Text = txt_Validation_date.Text = txt_TotalCost.Text = "Empty !!";
            }
        }

        private void Btn_Add_Table_Click(object sender, EventArgs e)
        {
            //Btn_Shlal.Visible = true;
            //Btn_Sea.Visible = true;
            //Btn_Restaurant.Visible = true;
            //Btn_Coffee.Visible = true;
            label8.Visible = true;
            Combo_Hall_Name.Visible = true;
        }

        private void Btn_Delete_Table_Click(object sender, EventArgs e)
        {
            //Btn_Increase_Shlal.Visible = false;
            //Btn_Decrease_Shlal.Visible = true;
            //Combo_Hall_Name.ResetText();
            Combo_Hall_Name.Visible = true;
            label8.Visible = true;
        }

        private void Btn_Save_Add_Delete_Table_Click(object sender, EventArgs e)
        {
            Btn_Add_Item.Visible = true;
            Btn_Delete_Item.Visible = true;
            Btn_Add_Item_Confirm.Visible = true; ;
            Btn_Edit_Item.Visible = true;
            Btn_Back.Visible = true;
            Btn_Add_Table.Visible = true;
            
            Btn_Increase_Shlal.Visible = false;
            Btn_Decrease_Shlal.Visible = false;
            Shlal_click_increase = 0;
            label18.Text = "";
            Combo_Hall_Name.SelectedIndex = 0;
            //Coffee_Click_increase = 0;
            //Restaurant_Click_increase = 0;
            //Sea_click_increase = 0;
            ////---------------
            //Shlal_click_decrease = 0;
            //Coffee_Click_decrease = 0;
            //Restaurant_Click_decrease = 0;
            //Sea_click_decrease = 0;
        }
        //TblShlal shlal = new TblShlal();
        //TBLSea Sea = new TBLSea();
        //TBLRestaurant Restaurant = new TBLRestaurant();
        //TBLCoffee Coffee = new TBLCoffee();
        private void Btn_Increase_Tbl_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Combo_Hall_Name.Text == "")
            //    {
            //        MessageBox.Show("إختر القاعة المناسبة ... ");
            //    }
            //    else if (Combo_Hall_Name.Text == "الشلال")
            //    {
            //        var maxid = brada.TblShlals.Max(s => s.TBLNumber);
            //        shlal.TBLNumber = maxid + 1;
            //        brada.TblShlals.InsertOnSubmit(shlal);
            //        brada.SubmitChanges();
            //        Shlal_click_increase++;
            //        MessageBox.Show("go to save [ Add " + Shlal_click_increase.ToString() + " Tables ]");
            //        var tbl_num = brada.TblShlals.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالشلال";
            //    }
            //    else if (Combo_Hall_Name.Text == "البحر")
            //    {
            //        var maxid2 = brada.TBLSeas.Max(s => s.TBLNumber);
            //        Sea.TBLNumber = maxid2 + 1;
            //        brada.TBLSeas.InsertOnSubmit(Sea);
            //        brada.SubmitChanges();
            //        Sea_click_increase++;
            //        MessageBox.Show("go to save [ Add " + Sea_click_increase.ToString() + " Tables ]");
            //        var tbl_num = brada.TBLSeas.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالبحر";
            //    }
            //    else if (Combo_Hall_Name.Text == "المطعم")
            //    {
            //        var maxid3 = brada.TBLRestaurants.Max(s => s.TBLNumber);
            //        Restaurant.TBLNumber = maxid3 + 1;
            //        brada.TBLRestaurants.InsertOnSubmit(Restaurant);
            //        brada.SubmitChanges();
            //        Restaurant_Click_increase++;
            //        MessageBox.Show("go to save [ Add " + Restaurant_Click_increase.ToString() + " Tables ]");
            //        var tbl_num = brada.TBLRestaurants.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالمطعم";
            //    }
            //    else if (Combo_Hall_Name.Text == "الكافيه")
            //    {
            //        var maxid4 = brada.TBLCoffees.Max(s => s.TBLNumber);
            //        Coffee.TBLNumber = maxid4 + 1;
            //        brada.TBLCoffees.InsertOnSubmit(Coffee);
            //        brada.SubmitChanges();
            //        Coffee_Click_increase++;
            //        MessageBox.Show("go to save [ Add " + Coffee_Click_increase.ToString() + " Tables ]");
            //        var tbl_num = brada.TBLCoffees.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالكافيه";
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Cann't Insert");

            //}
            //--------------------------------
            try
            {

                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.Numbers);
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                brada.ins_tbl_num(maxid + 1, maxtblid + 1, tbnum + 1, Combo_Hall_Name.SelectedIndex + 1);
                //add_tables();
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;
                
                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;



            }
            catch (Exception)
            {
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                if (Combo_Hall_Name.SelectedIndex == 3)
                {
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 25, Combo_Hall_Name.SelectedIndex + 1);
                }
                else
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 1, Combo_Hall_Name.SelectedIndex + 1);

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;

            }
            //----------------------------
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            

        }
        //private void add_tables()
        //{
        //    if (Combo_Hall_Name.SelectedText=="شلال")
        //    {
        //        Shlal_click_increase++;
        //        MessageBox.Show("go to save [ Add " + Shlal_click_increase.ToString() + " Tables ]");
        //        var tbl_num = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == 2).Select(s => s.Numbers).ToList();
        //        listBox1.DataSource = tbl_num;
        //        label18.Text = "ترابيزات متاحة بالشلال";    
        //    }
            
        //}
        int Shlal_click_increase;
        //int Sea_click_increase;
        //int Restaurant_Click_increase;
        //int Coffee_Click_increase;
        //int Shlal_click_decrease;
        //int Sea_click_decrease;
        //int Restaurant_Click_decrease;
        //int Coffee_Click_decrease;
        private void Btn_Decrease_Tbl_Click(object sender, EventArgs e)
        {
            // محتاج طرح ثابت من قاعدة البيانات

            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            
            /////
            //try
            //{
            //    if (Combo_Hall_Name.Text == "")
            //    {
            //        MessageBox.Show("إختر القاعة المناسبة ... ");
            //    }

            //    else if (Combo_Hall_Name.Text == "الشلال")
            //    {
            //        var maxid5 = brada.TblShlals.Max(s => s.ID);
            //        brada.delinShlal(maxid5);
            //        brada.SubmitChanges();
            //        Shlal_click_decrease++;
            //        MessageBox.Show("go to save [ Delete " + Shlal_click_decrease.ToString() + " Tables ]");
            //        var tbl_num = brada.TblShlals.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالشلال";
            //    }
            //    else if (Combo_Hall_Name.Text == "البحر")
            //    {
            //        var maxid6 = brada.TBLSeas.Max(s => s.ID);
            //        brada.delinSea(maxid6);
            //        brada.SubmitChanges();
            //        Sea_click_decrease++;
            //        MessageBox.Show("go to save [ Delete " + Sea_click_decrease.ToString() + " Tables ]");
            //        var tbl_num = brada.TBLSeas.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالبحر";
            //    }
            //    else if (Combo_Hall_Name.Text == "المطعم")
            //    {
            //        var maxid7 = brada.TBLRestaurants.Max(s => s.ID);
            //        brada.delinRestaurant(maxid7);
            //        brada.SubmitChanges();
            //        Restaurant_Click_decrease++;
            //        MessageBox.Show("go to save [ Delete " + Restaurant_Click_decrease.ToString() + " Tables ]");
            //        var tbl_num = brada.TBLRestaurants.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالمطعم";
            //    }
            //    else if (Combo_Hall_Name.Text == "الكافيه")
            //    {
            //        var maxid8 = brada.TBLCoffees.Max(s => s.ID);
            //        brada.delinCoffee(maxid8);
            //        brada.SubmitChanges();
            //        Coffee_Click_decrease++;
            //        MessageBox.Show("go to save [ Delete " + Coffee_Click_decrease.ToString() + " Tables ]");
            //        var tbl_num = brada.TBLCoffees.Select(s => s.TBLNumber).ToList();
            //        listBox1.DataSource = tbl_num;
            //        label18.Text = "ترابيزات متاحة بالكافيه";
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Cann't Insert");
            //}


            //////
            try
            {
                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex+1).Max(s => s.TBL_ID);
                brada.del_tbl_num(tbnum);
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;
                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;


            }
            catch (Exception)
            {


                MessageBox.Show("الترابيزات خلصت ^_^");
            }
        }

        private void Items_Load(object sender, EventArgs e)
        {
            //Combo_Hall_Name.SelectedIndex = 0;
            // TODO: This line of code loads data into the 'bradaDataSet.TablePlace' table. You can move, or remove it, as needed.
            this.tablePlaceTableAdapter.Fill(this.bradaDataSet.TablePlace);
            //// TODO: This line of code loads data into the 'bradaDataSet1.TblItem' table. You can move, or remove it, as needed.
            //this.tblItemTableAdapter.Fill(this.bradaDataSet1.TblItem);
            //// TODO: This line of code loads data into the 'bradaDataSet.TablePlace' table. You can move, or remove it, as needed.
            //this.tablePlaceTableAdapter.Fill(this.bradaDataSet.TablePlace);
            
            //if (txt_Quantity_Number.Text == "")
            //{
            //    txt_Quantity_Number.Text = "00";
            //}
            
            //if (txt_TotalCost.Text == "")
            //{
            //    txt_TotalCost.Text = "0.00";
            //}
            //if (txt_Packu_Cost.Text == "")
            //{
            //    txt_Packu_Cost.Text = "0.00";
            //}

            var table_nameee = brada.TablePlaces.Select(s => new { Id = s.ID, Name = s.Tableplace1 }).ToList();

            foreach (var item in table_nameee)
            {
                Combo_Hall_Name.Items.Add(item);
            }

            Combo_Hall_Name.ValueMember = "Id";
            Combo_Hall_Name.DisplayMember = "Name";

            try
            {
                var details = brada.Tbl_Items.Where(s => s.Item_Name == txt_Item_Name.Text).Select(s => new { Name = s.Item_Name, Quantity2 = s.Quantity_Num, totcost = s.TotalCost }).SingleOrDefault();

                txt_Quantity_Number.Text = details.Quantity2.ToString();
                txt_TotalCost.Text = details.totcost.ToString();
            }
            catch (Exception)
            {

             //   txt_Quantity_Number.Text = txt_Validation_date.Text = txt_TotalCost.Text = txt_Packu_Cost.Text = "Empty !!";
            }
            Btn_Increase_Shlal.Visible = false;
            Btn_Decrease_Shlal.Visible = false;
            Btn_Increase_Sea.Visible = false;
            Btn_Decrease_Sea.Visible = false;
            Btn_Increase_Restaurant.Visible = false;
            Btn_Decrease_Restaurant.Visible = false;
            Btn_Increase_Coffee.Visible = false;
            Btn_Decrease_Coffee.Visible = false;
            Btn_Shlal.Visible = false;
            Btn_Sea.Visible = false;
            Btn_Restaurant.Visible = false;
            Btn_Coffee.Visible = false;
            label8.Visible = false;
            Combo_Hall_Name.Visible = false;
        }

        private void btn_Store_Visibility_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            txt_receive_date.Clear();
            txt_receive_num.Clear();
            label12.Visible = true;
            label13.Visible = true;
            txt_money_val.Visible = true;
            txt_Store_Packu.Visible = true;
            txt_Quantity_Int_Store.Visible = true;
            txt_Packu_Cost.Clear();
            txt_Quantity_Number.Clear();
            txt_Peices_Num.Clear();
            txt_Validation_date.Clear();
            txt_TotalCost.Clear();
            txt_Item_Name.Clear();
            label15.Visible = true;
            label17.Visible = true;
            txt_Search_Store.Visible = true;
            txt_Packu_Store_Cost.Visible = true;    
        }

        

        private void Combo_Hall_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (Combo_Hall_Name.SelectedIndex==1)
            {
                Btn_Shlal.Visible = true;
                Btn_Sea.Visible = false;
                Btn_Restaurant.Visible = false;
                Btn_Coffee.Visible = false;
                Btn_Increase_Shlal.Visible = false;
                Btn_Decrease_Shlal.Visible = false;
                Btn_Increase_Sea.Visible = false;
                Btn_Decrease_Sea.Visible = false;
                Btn_Increase_Restaurant.Visible = false;
                Btn_Decrease_Restaurant.Visible = false;
                Btn_Increase_Coffee.Visible = false;
                Btn_Decrease_Coffee.Visible = false;
            }
            else if (Combo_Hall_Name.SelectedIndex==2)
            {
                Btn_Sea.Visible = true;
                Btn_Shlal.Visible = false;
                Btn_Restaurant.Visible = false;
                Btn_Coffee.Visible = false;
                Btn_Increase_Shlal.Visible = false;
                Btn_Decrease_Shlal.Visible = false;
                Btn_Increase_Sea.Visible = false;
                Btn_Decrease_Sea.Visible = false;
                Btn_Increase_Restaurant.Visible = false;
                Btn_Decrease_Restaurant.Visible = false;
                Btn_Increase_Coffee.Visible = false;
                Btn_Decrease_Coffee.Visible = false;
            }
            else if (Combo_Hall_Name.SelectedIndex == 3)
            {
                Btn_Restaurant.Visible = true;
                Btn_Sea.Visible = false;
                Btn_Shlal.Visible = false;
                Btn_Coffee.Visible = false;
                Btn_Increase_Shlal.Visible = false;
                Btn_Decrease_Shlal.Visible = false;
                Btn_Increase_Sea.Visible = false;
                Btn_Decrease_Sea.Visible = false;
                Btn_Increase_Restaurant.Visible = false;
                Btn_Decrease_Restaurant.Visible = false;
                Btn_Increase_Coffee.Visible = false;
                Btn_Decrease_Coffee.Visible = false;
            }
            else if (Combo_Hall_Name.SelectedIndex == 4)
            {
                Btn_Coffee.Visible = true;
                Btn_Restaurant.Visible = false;
                Btn_Sea.Visible = false;
                Btn_Shlal.Visible = false;
                Btn_Increase_Shlal.Visible = false;
                Btn_Decrease_Shlal.Visible = false;
                Btn_Increase_Sea.Visible = false;
                Btn_Decrease_Sea.Visible = false;
                Btn_Increase_Restaurant.Visible = false;
                Btn_Decrease_Restaurant.Visible = false;
                Btn_Increase_Coffee.Visible = false;
                Btn_Decrease_Coffee.Visible = false;
            }
            try
            {
                if (Combo_Hall_Name.SelectedIndex!=0)
                {
                    var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                    listBox1.DataSource = alltables;
                    var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                    label18.Text = "ترابيزات متاحه ب" + placename;    
                }
                else if (Combo_Hall_Name.SelectedIndex==0)
                {
                    label18.Text = "";
                }
                
            }
            catch (Exception)
            {}
        }

        private void Btn_Shlal_Click(object sender, EventArgs e)
        {
            Btn_Increase_Shlal.Visible = true;
            Btn_Decrease_Shlal.Visible = true;
        }

        private void Btn_Sea_Click(object sender, EventArgs e)
        {
            Btn_Increase_Sea.Visible = true;
            Btn_Decrease_Sea.Visible = true;
        }

        private void Btn_Restaurant_Click(object sender, EventArgs e)
        {
            Btn_Increase_Restaurant.Visible = true;
            Btn_Decrease_Restaurant.Visible = true;
        }

        private void Btn_Coffee_Click(object sender, EventArgs e)
        {
            Btn_Increase_Coffee.Visible = true;
            Btn_Decrease_Coffee.Visible = true;
        }

        private void Btn_Increase_Restaurant_Click(object sender, EventArgs e)
        {
            try
            {

                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.Numbers);
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                brada.ins_tbl_num(maxid + 1, maxtblid + 1, tbnum + 1, Combo_Hall_Name.SelectedIndex + 1);
                //add_tables();
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;



            }
            catch (Exception)
            {
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                if (Combo_Hall_Name.SelectedIndex == 3)
                {
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 25, Combo_Hall_Name.SelectedIndex + 1);
                }
                else
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 1, Combo_Hall_Name.SelectedIndex + 1);

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;

            }
            //----------------------------
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            
        }

        private void Btn_Increase_Sea_Click(object sender, EventArgs e)
        {
            try
            {

                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.Numbers);
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                brada.ins_tbl_num(maxid + 1, maxtblid + 1, tbnum + 1, Combo_Hall_Name.SelectedIndex + 1);
                //add_tables();
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;



            }
            catch (Exception)
            {
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                if (Combo_Hall_Name.SelectedIndex == 3)
                {
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 25, Combo_Hall_Name.SelectedIndex + 1);
                }
                else
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 1, Combo_Hall_Name.SelectedIndex + 1);

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;

            }
            //----------------------------
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            
        }

        private void Btn_Increase_Coffee_Click(object sender, EventArgs e)
        {
            try
            {

                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.Numbers);
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                brada.ins_tbl_num(maxid + 1, maxtblid + 1, tbnum + 1, Combo_Hall_Name.SelectedIndex + 1);
                //add_tables();
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;



            }
            catch (Exception)
            {
                var maxid = brada.TBL_Numbers.Max(s => s.ID);
                var maxtblid = brada.TBL_Numbers.Max(s => s.TBL_ID);
                if (Combo_Hall_Name.SelectedIndex == 3)
                {
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 25, Combo_Hall_Name.SelectedIndex + 1);
                }
                else
                    brada.ins_tbl_num(maxid + 1, maxtblid + 1, 1, Combo_Hall_Name.SelectedIndex + 1);

                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;

            }
            //----------------------------
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            
        }

        private void Btn_Decrease_Restaurant_Click(object sender, EventArgs e)
        {
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            
            
            try
            {
                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.TBL_ID);
                brada.del_tbl_num(tbnum);
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;
                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;


            }
            catch (Exception)
            {


                MessageBox.Show("الترابيزات خلصت ^_^");
            }
        }

        private void Btn_Decrease_Sea_Click(object sender, EventArgs e)
        {
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            

            try
            {
                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.TBL_ID);
                brada.del_tbl_num(tbnum);
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;
                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;


            }
            catch (Exception)
            {


                MessageBox.Show("الترابيزات خلصت ^_^");
            }
        }

        private void Btn_Decrease_Coffee_Click(object sender, EventArgs e)
        {
            Btn_Add_Item.Visible = false;
            Btn_Delete_Item.Visible = false;
            Btn_Add_Item_Confirm.Visible = false;
            Btn_Edit_Item.Visible = false;
            Btn_Back.Visible = false;
            Btn_Add_Table.Visible = false;
            

            try
            {
                var tbnum = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Max(s => s.TBL_ID);
                brada.del_tbl_num(tbnum);
                var alltables = brada.TBL_Numbers.Where(s => s.TBLPlace_ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Numbers).ToList();
                listBox1.DataSource = alltables;
                var placename = brada.TablePlaces.Where(s => s.ID == Combo_Hall_Name.SelectedIndex + 1).Select(s => s.Tableplace1).SingleOrDefault();
                label18.Text = "ترابيزات متاحه ب" + placename;


            }
            catch (Exception)
            {


                MessageBox.Show("الترابيزات خلصت ^_^");
            }
        }

       

        
        

        

        

        

        
    }
}
