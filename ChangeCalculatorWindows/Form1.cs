using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeCalculatorWindows
{
    public partial class Form1 : Form
    {
        //variabel som håller koll på om inmatningen från användaren är korrekt gjord
        bool inputOk = false;
        int change; // växelsumman
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChangeCalculation_Click(object sender, EventArgs e)
        {
            //Deklaration av variabler
            //Klassen Denomination används för att skapa upp de valörer som ska användas av programmet.
            //Fördelen med att använda en klass är att man enkelt kan byta ut eller lägga till valörer
            //(t ex 200-lappar, 2-kronor)
            Denomination femhundra = new Denomination("femhundralapp", "femhundralappar", 500);
            Denomination hundra = new Denomination("hundralapp", "hundralappar", 100);
            Denomination femtio = new Denomination("femtiolapp", "femtiolappar", 50);
            Denomination tjugo = new Denomination("tjugolapp", "tjugolappar", 20);
            Denomination tio = new Denomination("tiokrona", "tiokronor", 10);
            Denomination fem = new Denomination("femkrona", "femkronor", 5);
            Denomination en = new Denomination("enkrona", "enkronor", 1);
            int denominatorCount;//håller antalet av den aktuella valören
            string countAndName; //antalet av och namnet (singular eller plural) för den aktuella valören
            //lägger till alla valörer i en array som jag senare kan loopa igenom istället för att behöva 
            //utföra samma moment för och en av valörerna
            Denomination[] denominationsArray = { femhundra, hundra, femtio, tjugo, tio, fem, en };
            
            //betalningen är utbruten i en egen metod som uppdaterar medlemsvariablerna inputOk och change
            //vilket ger bekräftelse på att inmatning från användaren har varit korrekt och vad växelsumman blev
            ReceivePayment();

            //om input är ok kan resultatet visas
            if (inputOk)
            {
                //om växelsumman är 0 behöver ingen växel betalas ut och och ingen ytterligare åtgärd behöver tas
                if (change == 0)
                {
                    lblOutput.Text = "Jämt belopp betalat, ingen växel behövs";
                    lblOutput.Visible = true;
                    //visar nollningsknappen om användaren vill göra en ny beräkning
                    btnClear.Visible = true;
                }
                else
                {
                    //börjar bygga den text som sedan ska visas i lblOutput. Lägger till en ny rad efter öppningsfrasen
                    string displayText = "Växel tillbaka:\n";

                    //loopar igenom arrayen av valörer för inte behöva upprepa återkommande utskrifter och uträkningar.
                    foreach (Denomination denomination in denominationsArray)
                    {
                        //räknar ut och returnerar antalet av den aktuella valören
                        denominatorCount = denomination.SetAndReturnCount(change);
                        //bara de valörer som har något värde behöver skrivas ut
                        if (denominatorCount > 0)
                        {
                            //hämtar antal och namn för aktuell valör
                            countAndName = denomination.GetCountAndName();

                            //lägger till antal och namn för valören i den aktuella variablen.
                            //avslutar med att lägga till en ny rad, för att nästa valör ska hamna på en egen rad i utskriften
                            displayText += countAndName + "\n";

                            //uppdaterar change med kvarvarande belopp
                            change %= denomination.Amount;
                        }
                    }
                    //uppdaterar och visar lblOutput där utskriften av antal och valörer görs
                    lblOutput.Text = displayText;
                    lblOutput.Visible = true;

                    //visar rensa-knappen. Så att användaren kan använda denna om en ny uträkning ska göras
                    btnClear.Visible = true;

                }
            }
        }

        private void tbxPrice_TextChanged(object sender, EventArgs e)
        {
            //om användaren börjar skriva i price- eller paid-fältet 
            //tas feltexten, ouput-texten och nollningsknappen bort
            HideLablesAndClear();
            
        }

        private void tbxPaid_TextChanged(object sender, EventArgs e)
        {
            //om användaren börjar skriva i price- eller paid-fältet 
            //gör feltexten, ouput-texten och nollningsknappen osynliga
            HideLablesAndClear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //när användaren klickar på nollningsknappen görs feltexten och outputtexten osynliga
            lblError.Visible = false;
            lblOutput.Visible = false;
            //price- och paidtextboxarna rensas
            tbxPrice.Text = "";
            tbxPaid.Text = "";
            //till slut görs nollningsknappen själv osynlig. 
            btnClear.Visible = false;
        }

        private void HideLablesAndClear()
        {
            //metod som används när användaren börjar skriva i paid- eller price-fältet
            //gör feltexten, outputtexten och nollningsknappen osynliga
            lblError.Visible = false;
            lblOutput.Visible = false;
            btnClear.Visible = false;
        }

        private void ReceivePayment()
        {
            //En metod som räknar ut växelbeloppet utfrån angivet pris och betalt belopp
            //samt kontrollerar så att användaren har gjort en korrekt inmatning och uppdaterar 
            //medlemsvariablerna inputOk och change

            //deklarerar variabler, sätter 0 som utgångsvärde för pris och betalt belopp
            //dessa riskerar annars att bli utan värde i o m att tilldelning sker i try-sats
            int price = 0, paid = 0;
            //price och paid får varsin bool-varible som ändras när ett godkänt svar getts av användaren.
            //om båda är ok ändas sedan inputOk till true som en bekräftelse på att värden har angetts. 
            bool priceOk = false, paidOk = false;

            try
            {
                //hämtar värdet i pricetextboxen
                price = Convert.ToInt32(tbxPrice.Text);
                //om konverteringen lyckas bekräftas att användaren godkänd inmatning av pris
                priceOk = true;
            }
            catch (FormatException)
            {
                //om fel datatyp har angivits hänvisas användaren uppdatera beloppet
                lblError.Text = "Beloppet måste anges som ett heltal.";
                //visar felmedelandet
                lblError.Visible = true;
                //visar nollningsmeddelandet
                btnClear.Visible = true;
                //sätter markören på textfältet som behöver uppdateras
                tbxPrice.Focus();
                //användaren behöver ändra på inmatningen. Metoden avslutas därför
                inputOk = false;
                return;
            }

            try
            {
                //hämtar värdet i pricetextboxen
                paid = Convert.ToInt32(tbxPaid.Text);
                //om konverteringen lyckas bekräftas att användaren godkänd inmatning av betalning
                paidOk = true;

            }
            catch (FormatException)
            {
                //om fel datatyp har angivits hänvisas användaren uppdatera beloppet
                lblError.Text = "Beloppet måste anges som ett heltal.";
                //visar felmedelandet
                lblError.Visible = true;
                //visar nollningsmeddelandet
                btnClear.Visible = true;
                //sätter markören på textfältet som behöver uppdateras
                tbxPaid.Focus();
                //användaren behöver ändra på inmatningen. Metoden avslutas därför
                inputOk = false;
                return;
            }
            //räknar ut växelsumman
            change = paid - price;

            if(change<0)
            {
                //om betalningen understiger priset behöver användaren justera sin inmatning
                lblError.Text = "Betalningen understiger priset.Ange nytt belopp";
                //visar felmedelandet
                lblError.Visible = true;
                //visar nollningsmeddelandet
                btnClear.Visible = true;
                //sätter markören på paid-textfältet eftersom det troligtvis är detta som behöver uppdateras
                tbxPaid.Focus();
                //användaren behöver ändra på inmatningen. Metoden avslutas därför
                inputOk = false;
                return;
            }
            //kollar så att inmatningen var ok för både pris och betalning och ändrar i så fall inputOk-variabeln till true
            else if(priceOk && paidOk)
            {
                inputOk = true;
                return;
            }
        }
    }
}
