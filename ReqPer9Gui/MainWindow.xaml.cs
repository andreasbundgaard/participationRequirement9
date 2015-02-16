using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReqPar9;

namespace ReqPer9Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<HopRecipe> HR = new List<HopRecipe>();
        List<MaltRecipe> MR = new List<MaltRecipe>();
        DatabaseController DBCon = new DatabaseController();

        public MainWindow()
        {
            InitializeComponent();
            FillHopList();
            FillMaltList();
            FillYeastList();
        }

        public class Item<T>
        {
            public string Text { get; set; }
            public T Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void FillHopList()
        {
            List<Hop> listeHop = DatabaseController.GetHop();
            foreach (Hop h in listeHop)
            {
                var item = new Item<string>()
                {
                    Text = h.Name,
                    Value = h.RawMaterialID
                };

                HopList.Items.Add(item);
            }
        }

        private void FillMaltList()
        {
            List<Malt> listeMalt = DatabaseController.GetMalt();
            foreach (Malt m in listeMalt)
            {
                var item = new Item<string>()
                {
                    Text = m.Name,
                    Value = m.RawMaterialID
                };

                MaltList.Items.Add(item);
            }
        }

        private void FillYeastList()
        {
            List<Yeast> listeYeast = DatabaseController.GetYeast();
            foreach (Yeast y in listeYeast)
            {
                var item = new Item<string>()
                {
                    Text = y.Name,
                    Value = y.RawMaterialID
                };
                YeastList.Items.Add(item);
            }
        }

        private void HopList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HopQT.Focus();
        }

        private void MaltList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaltQT.Focus();
        }

        private void SubmitHopQT_click(object sender, RoutedEventArgs e)
        {
            if (HopList.SelectedItem == null)
            {
                MessageBox.Show("Intet valgt");
            }
            else
            {
                try
                {
                    int quantity = int.Parse(HopQT.Text);
                    int boilTime = int.Parse(HopBoilTime.Text);
                    string curItem = HopList.SelectedItem.ToString();
                    // Hop ID
                    var selectedHop = (Item<string>)HopList.SelectedItem;
                    var HopID = int.Parse(selectedHop.Value);

                    if (quantity <= 0)
                    {
                        MessageBox.Show("Ugyldigt tal. Angiv et helt tal større end 0.", "Antal");
                    }
                    else if (boilTime < 0)
                    {
                        MessageBox.Show("Ugyldigt tal. Angiv et helt tal større end 0.", "Antal");
                    }
                    else
                    {
                        HopListQT.Items.Add(quantity + " X " + curItem + "\n" + "Boiltime: " + boilTime + "\n");

                        HR.Add(new HopRecipe(HopID, quantity, boilTime));
                    }
                }
                catch
                {
                    MessageBox.Show("Ugyldigt input. Angiv et helt tal større end 0.", "Antal");
                }
                finally
                {
                    HopQT.Text = "";
                    HopQT.Focus();

                    HopBoilTime.Text = "";
                    HopBoilTime.Focus();
                }
            }
        }

        private void SubmitMaltQT_click(object sender, RoutedEventArgs e)
        {
            if (MaltList.SelectedItem == null)
            {
                MessageBox.Show("Intet valgt");
            }
            else
            {
                try
                {
                    int quantity = int.Parse(MaltQT.Text);
                    string curItem = MaltList.SelectedItem.ToString();
                    // Malt ID
                    var selectedMalt = (Item<string>)MaltList.SelectedItem;
                    var MaltID = int.Parse(selectedMalt.Value);

                    if (quantity <= 0)
                    {
                        MessageBox.Show("Ugyldigt tal. Angiv et helt tal større end 0.", "Antal");
                    }
                    else
                    {
                        MaltListQT.Items.Add(quantity + " X " + curItem + "\n");

                        MR.Add(new MaltRecipe(MaltID, quantity));
                    }
                }
                catch
                {
                    MessageBox.Show("Ugyldigt input. Angiv et helt tal større end 0.", "Antal");
                }
                finally
                {
                    MaltQT.Text = "";
                    MaltQT.Focus();
                }
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeName.Text;
            int efficiency = int.Parse(Efficiency.Text);
            int attnuation = int.Parse(Attnuation.Text);
            int finalGravity = int.Parse(FinalGravity.Text);
            int boilVolume = int.Parse(BoilVolume.Text);
            int contents = int.Parse(Contents.Text);
            int volume = int.Parse(Volume.Text);
            // Yeast ID
            var selectedYeast = (Item<string>)YeastList.SelectedItem;
            var YeastID = int.Parse(selectedYeast.Value);

            foreach (HopRecipe H in HR)
            {
                //string Hop = HopListQT.Items.ToString();
                int hopID = H.RawMaterialID;
                int quantity = H.Quantity;
                int boilTime = H.BoilTime;

                DBCon.CreateRecipeHop(hopID, quantity, boilTime);
            }

            foreach (MaltRecipe M in MR)
            {
                int MaltID = M.RawMaterialID;
                int quantity = M.Quantity;

                DBCon.CreateRecipeMalt(MaltID, quantity);
            }

           DBCon.CreateRecipe(recipeName, YeastID, efficiency, attnuation, finalGravity, boilVolume, contents, volume);

            //for (int i = 0; i < HopList.SelectedItems.Count; i++)
            //{
            //    string Hop = HopListQT.Items.ToString();
            //    // Hop ID
            //    var selectedHop = (Item<string>)HopListQT.Items;
            //    var HopID = int.Parse(selectedHop.Value);

            //    int quantity = int.Parse(HopQT.Text);
            //    int quantity = int.Parse(HopQT.Text);
            //    int boilTime = int.Parse(HopBoilTime.Text);

            //    MessageBox.Show("Navn: " + Hop + " QT: " + quantity + " BT: " + boilTime);
            //}
        }

        public void clearFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= clearFocus;
        }
    }
}