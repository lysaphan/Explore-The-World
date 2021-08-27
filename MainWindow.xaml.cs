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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Zoom viewbox scale
            ZoomViewbox.Width = 1500;
            ZoomViewbox.Height = 1000;

        }

        //Set country's color for MouseLeave
        Color country_color = (Color)ColorConverter.ConvertFromString("#FFF2F2F2");
        Brush country_set_color;
        bool setColor = false;
        string inputCode = "";
        bool lgbtMode = false; 


        /*Zoom the map */
        private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            UpdateViewBox((e.Delta > 0) ? 300 : -300);
        }
        private void UpdateViewBox(int newValue)
        {
            if ((ZoomViewbox.Width >= 0) && ZoomViewbox.Height >= 0)
            {
                ZoomViewbox.Width += newValue;
                ZoomViewbox.Height += newValue;
            }
        }


        /*MouseEnter Event*/
        private void CountryMouseEnter(object sender, MouseEventArgs e)
        {
            var path = sender as Path;
            if (path != null)
            {
                //Display name and flag
                inputCode = path.Name;
                CountryInfo(inputCode);

                //Change color of country
                if (setColor == false)
                {
                    path.Fill = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    //Store existing color
                    country_set_color = path.Fill;
                    path.Fill = new SolidColorBrush(Colors.Black);
                    //Change color
                    /*if (lgbtMode == true)
                    {
                        //Change color of lgbt mode
                        path.Fill = new SolidColorBrush(Colors.MistyRose);
                    }
                    else
                    {
                        //Change color of most travelled mode
                        path.Fill = new SolidColorBrush(Colors.DarkSalmon);
                    } */
                }
            }
        }

        /*MouseLeave Event*/
        private void CountryMouseLeave(object sender, MouseEventArgs e)
        {
            //Clear country name & flag
            nameTextbox.Clear();
            flagPos.Visibility = Visibility.Collapsed;

            //Change color of country
            var path = sender as Path;
            if (path != null)
            {
                if (setColor == false)
                {
                    path.Fill = new SolidColorBrush(country_color);
                }
                else
                {
                    path.Fill = country_set_color;
                }
            }
        }

        /*Open France map*/
        private void FranceMap(object sender, RoutedEventArgs e)
        {
            France Fwin = new France();
            Fwin.Show();
            this.Hide();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            MainWindow mywin = new MainWindow();
            mywin.Show();
            this.Close();
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            //Librety.Visibility = Visibility.Visible;

            //Point mouseP = PointToScreen(Mouse.GetPosition(this));
            //MessageBox.Show(mouseP.ToString());

            //test
            //nameTextbox.Text = "See this?";

            Video vwin = new Video();
            vwin.Show();
            this.Close();
        }

        /*Display name and flag of selected country*/
        private void setInfo(string countryName)
        {
            try
            {
                //Change country name
                nameTextbox.Text = countryName;

                //Change the flag
                flagPos.Visibility = Visibility.Visible;
                var converter = new ImageSourceConverter();
                flagPos.Source = (ImageSource)converter.ConvertFromString("pack://application:,,,/WpfApp1;component/Flag/" + countryName + ".png");

            }
            catch //(Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Cannot load this country's flag.");
            }
            
        }

        /*Most travelled countries by ranking*/
        private void Lgbt_Click(object sender, RoutedEventArgs e)
        {
            keyLGBT.Visibility = Visibility.Visible;

            lgbtMode = true;
            setColor = true;
            Brush gradeA = (SolidColorBrush)new BrushConverter().ConvertFromString("#521452");
            Brush gradeB = (SolidColorBrush)new BrushConverter().ConvertFromString("#A329A3");
            Brush gradeC = (SolidColorBrush)new BrushConverter().ConvertFromString("#D65CD6");
            Brush gradeD = (SolidColorBrush)new BrushConverter().ConvertFromString("#EBADEB");

            //Grade A+, A, A-
            SE1.Fill = gradeA;
            CA1.Fill = gradeA;
            NO1.Fill = gradeA;
            PT1.Fill = gradeA;
            BE1.Fill = gradeA;
            GB1.Fill = gradeA;
            FI1.Fill = gradeA;
            FR1.Fill = gradeA;
            IS1.Fill = gradeA;
            ES1.Fill = gradeA;
            MT1.Fill = gradeA;
            NZ1.Fill = gradeA;
            GF1.Fill = gradeA;
            GL1.Fill = gradeA;

            //Grade B
            NL1.Fill = gradeB;
            DK1.Fill = gradeB;
            ZA1.Fill = gradeB;
            IE1.Fill = gradeB;
            AU1.Fill = gradeB;
            UY1.Fill = gradeB;
            CO1.Fill = gradeB;
            AT1.Fill = gradeB;
            DE1.Fill = gradeB;
            SI1.Fill = gradeB;
            LU1.Fill = gradeB;
            US1.Fill = gradeB;
            PR1.Fill = gradeB;
            TW1.Fill = gradeB;
            BR1.Fill = gradeB;
            EC1.Fill = gradeB;
            HU1.Fill = gradeB;
            MX1.Fill = gradeB;
            SR1.Fill = gradeB;

            //Grade C
            GA1.Fill = gradeC;
            SK1.Fill = gradeC;
            AR1.Fill = gradeC;
            CL1.Fill = gradeC;
            RS1.Fill = gradeC;
            HR1.Fill = gradeC;
            CZ1.Fill = gradeC;
            EE1.Fill = gradeC;
            AD1.Fill = gradeC;
            BO1.Fill = gradeC;
            AL1.Fill = gradeC;
            NP1.Fill = gradeC;
            CY1.Fill = gradeC;
            CH1.Fill = gradeC;
            GR1.Fill = gradeC;
            IL1.Fill = gradeC;
            HN1.Fill = gradeC;
            ME1.Fill = gradeC;
            RO1.Fill = gradeC;
            GE1.Fill = gradeC;
            PE1.Fill = gradeC;
            BA1.Fill = gradeC;
            BG1.Fill = gradeC;
            IT1.Fill = gradeC;
            NI1.Fill = gradeC;
            SV1.Fill = gradeC;
            CR1.Fill = gradeC;
            MN1.Fill = gradeC;
            VE1.Fill = gradeC;
            FJ1.Fill = gradeC;

            //Grade D
            PH1.Fill = gradeD;
            HK1.Fill = gradeD;
            KR1.Fill = gradeD;
            PL1.Fill = gradeD;
            LT1.Fill = gradeD;
            LA1.Fill = gradeD;
            IN1.Fill = gradeD;
            PA1.Fill = gradeD;
            TH1.Fill = gradeD;
            LV1.Fill = gradeD;
            DO1.Fill = gradeD;
            JP1.Fill = gradeD;
            MZ1.Fill = gradeD;
            MK1.Fill = gradeD;
            KH1.Fill = gradeD;
            GT1.Fill = gradeD;
            PY1.Fill = gradeD;
            VN1.Fill = gradeD;
            TT1.Fill = gradeD;
            CU1.Fill = gradeD;
            LS1.Fill = gradeD;
            TR1.Fill = gradeD;
            BW1.Fill = gradeD;
            HT1.Fill = gradeD;
            RW1.Fill = gradeD;
            UA1.Fill = gradeD;
            BY1.Fill = gradeD;
            KG1.Fill = gradeD;
            AM1.Fill = gradeD;
            AZ1.Fill = gradeD;
            AW1.Fill = gradeD;
            BZ1.Fill = gradeD;
            CV1.Fill = gradeD;
            KY1.Fill = gradeD;
            CW1.Fill = gradeD;
            SC1.Fill = gradeD;
            SX1.Fill = gradeD;
            TJ1.Fill = gradeD;
            BS1.Fill = gradeD;
            TC1.Fill = gradeD;
            ML1.Fill = gradeD;
            NE1.Fill = gradeD;
            BF1.Fill = gradeD;
            CI1.Fill = gradeD;
            BJ1.Fill = gradeD;
            CD1.Fill = gradeD;
            AO1.Fill = gradeD;
            BW1.Fill = gradeD;
            CF1.Fill = gradeD;
            SS1.Fill = gradeD;
            CG1.Fill = gradeD;

        }

        /*Convert country code to country name*/
        private void CountryInfo(string code)
        {
            //A
            if (code == AF1.Name)
                setInfo("afghanistan");
            if (code == AL1.Name)
                setInfo("albania");
            if (code == DZ1.Name)
                setInfo("algeria");
            if (code == AD1.Name)
                setInfo("andorra");
            if (code == AO1.Name)
                setInfo("angola");
            if (code == AI1.Name)
                setInfo("anguilla");
            if (code == AG1.Name)
                setInfo("antigua and barbuda");
            if (code == AR1.Name)
                setInfo("argentina");
            if (code == AM1.Name)
                setInfo("armenia");
            if (code == AW1.Name)
                setInfo("aruba");
            if (code.Equals(AU1.Name))
                setInfo("australia");
            if (code == AT1.Name)
                setInfo("austria");
            if (code == AZ1.Name)
                setInfo("azerbaijan");
            //B
            if (code == BS1.Name)
                setInfo("bahamas");
            if (code == BD1.Name)
                setInfo("bangladesh");
            if (code == BB1.Name)
                setInfo("barbados");
            if (code == BY1.Name)
                setInfo("belarus");
            if (code == BE1.Name)
                setInfo("belgium");
            if (code == BZ1.Name)
                setInfo("belize");
            if (code == BJ1.Name)
                setInfo("benin");
            if (code == BM1.Name)
                setInfo("bermuda");
            if (code == BT1.Name)
                setInfo("bhutan");
            if (code == BO1.Name)
                setInfo("bolivia");
            if (code == BA1.Name)
                setInfo("bosnia and herzegovina");
            if (code == BW1.Name)
                setInfo("botswana");
            if (code == BR1.Name)
                setInfo("brazil");
            if (code == VG1.Name)
                setInfo("british virgin islands");
            if (code == BN1.Name)
                setInfo("brunei");
            if (code == BG1.Name)
                setInfo("bulgaria");
            if (code == BF1.Name)
                setInfo("burkina faso");
            if (code == BI1.Name)
                setInfo("burundi");
            //C
            if (code == KH1.Name)
               setInfo("cambodia");
            if (code == CM1.Name)
               setInfo("cameroon");
            if (code == CA1.Name)
                setInfo("canada");
            if (code == CV1.Name)
                setInfo("cape Verde");
            if (code == KY1.Name)
                setInfo("cayman Islands");
            if (code == CF1.Name)
                setInfo("central african republic");
            if (code == TD1.Name)
                setInfo("chad");
            if (code == CL1.Name)
                setInfo("chile");
            if (code == CN1.Name)
                setInfo("china");
            if (code == CO1.Name)
                setInfo("colombia");
            if (code == KM1.Name)
                setInfo("comoros");
            if (code == CR1.Name)
                setInfo("costa Rica");
            if (code == HR1.Name)
                setInfo("croatia");
            if (code == CU1.Name)
                setInfo("cuba");
            if (code == CW1.Name)
                setInfo("curacao");
            if (code == CY1.Name)
                setInfo("cyprus");
            if (code == CZ1.Name)
                setInfo("czech Republic");
            if (code == CD1.Name)
                setInfo("democratic Republic of congo");
            //D
            if (code == DK1.Name)
                setInfo("denmark");
            if (code == DJ1.Name)
                setInfo("djibouti");
            if (code == DM1.Name)
                setInfo("dominica");
            if (code == DO1.Name)
                setInfo("dominican Republic");
            //E
            if (code == TL1.Name)
                setInfo("east timor");
            if (code == EC1.Name)
                setInfo("ecuador");
            if (code == EG1.Name)
                setInfo("egypt");
            if (code == SV1.Name)
                setInfo("el salvador");
            if (code == GQ1.Name)
                setInfo("equatorial guinea");
            if (code == ER1.Name)
                setInfo("eritrea");
            if (code == EE1.Name)
                setInfo("estonia");
            if (code == ET1.Name)
                setInfo("ethiopia");
            //F
            if (code == FK1.Name)
                setInfo("falkland islands");
            if (code == FO1.Name)
                setInfo("faroe islands");
            if (code == FJ1.Name)
                setInfo("fiji");
            if (code == FI1.Name)
                setInfo("finland");
            if (code == FR1.Name)
                setInfo("france");
            if (code == PF1.Name)
                setInfo("french polynesia");
            //G
            if (code == GA1.Name)
                setInfo("gabon");
            if (code == GM1.Name)
                setInfo("gambia");
            if (code == GE1.Name)
                setInfo("georgia");
            if (code == DE1.Name)
                setInfo("germany");
            if (code == GH1.Name)
                setInfo("ghana");
            if (code == GR1.Name)
                setInfo("greece");
            if (code == GL1.Name)
                setInfo("greenland");
            if (code == GD1.Name)
                setInfo("grenada");
            if (code == GP1.Name)
                setInfo("guadeloupe");
            if (code == GT1.Name)
                setInfo("guatemala");
            if (code == GN1.Name)
                setInfo("guinea");
            if (code == GW1.Name)
                setInfo("guinea bissau");
            if (code == GY1.Name)
                setInfo("guyana");
            if (code == GF1.Name)
                setInfo("french guiana");
            //H
            if (code == HT1.Name)
                setInfo("haiti");
            if (code == HN1.Name)
                setInfo("honduras");
            if (code == HK1.Name)
                setInfo("hong kong");
            if (code == HU1.Name)
                setInfo("hungary");
            //I
            if (code == IS1.Name)
                setInfo("iceland");
            if (code == IN1.Name)
                setInfo("india");
            if (code == ID1.Name)
                setInfo("indonesia");
            if (code == IR1.Name)
                setInfo("iran");
            if (code == IQ1.Name)
                setInfo("iraq");
            if (code == IE1.Name)
                setInfo("ireland");
            if (code == IL1.Name)
                setInfo("israel");
            if (code == IT1.Name)
                setInfo("italy");
            if (code == CI1.Name)
                setInfo("ivory coast");
            //J
            if (code == JM1.Name)
                setInfo("jamaica");
            if (code == JP1.Name)
                setInfo("japan");
            if (code == JO1.Name)
                setInfo("jordan");
            //K
            if (code == KZ1.Name)
                setInfo("kazakhstan");
            if (code == KE1.Name)
                setInfo("kenya");
            if (code == KW1.Name)
                setInfo("kuwait");
            if (code == KG1.Name)
                setInfo("kyrgyzstan");
            //L
            if (code == LA1.Name)
                setInfo("laos");
            if (code == LV1.Name)
                setInfo("latvia");
            if (code == LB1.Name)
                setInfo("lebanon");
            if (code == LS1.Name)
                setInfo("lesotho");
            if (code == LR1.Name)
                setInfo("liberia");
            if (code == LY1.Name)
                setInfo("libya");
            if (code == LI1.Name)
                setInfo("liechtenstein");
            if (code == LT1.Name)
                setInfo("lithuania");
            if (code == LU1.Name)
                setInfo("luxembourg");
            //M
            if (code == MK1.Name)
                setInfo("macedonia");
            if (code == MG1.Name)
                setInfo("madagascar");
            if (code == MW1.Name)
                setInfo("malawi");
            if (code == MY1.Name)
                setInfo("malaysia");
            if (code == MV1.Name)
                setInfo("maldives");
            if (code == ML1.Name)
                setInfo("mali");
            if (code == MT1.Name)
                setInfo("malta");
            if (code == MQ1.Name)
                setInfo("martinique");
            if (code == MR1.Name)
                setInfo("mauritania");
            if (code == MU1.Name)
                setInfo("mauritius");
            if (code == YT1.Name)
                setInfo("mayotte");
            if (code == MX1.Name)
                setInfo("mexico");
            if (code == MD1.Name)
                setInfo("moldova");
            if (code == MN1.Name)
                setInfo("mongolia");
            if (code == ME1.Name)
                setInfo("montenegro");
            if (code == MS1.Name)
                setInfo("montserrat");
            if (code == MA1.Name)
                setInfo("morocco");
            if (code == MZ1.Name)
                setInfo("mozambique");
            if (code == MM1.Name)
                setInfo("myanmar");
            //N, O
            if (code == NA1.Name)
                setInfo("namibia");
            if (code == NC1.Name)
                setInfo("new caledonia");
            if (code == NR1.Name)
                setInfo("nauru");
            if (code == NP1.Name)
                setInfo("nepal");
            if (code == NL1.Name)
                setInfo("netherlands");
            if (code == NZ1.Name)
                setInfo("new zealand");
            if (code == NI1.Name)
                setInfo("nicaragua");
            if (code == NE1.Name)
                setInfo("niger");
            if (code == NG1.Name)
                setInfo("nigeria");
            if (code == KP1.Name)
                setInfo("north korea");
            if (code == NO1.Name)
                setInfo("norway");
            if (code == OM1.Name)
                setInfo("oman");
            //P, Q
            if (code == PR1.Name)
                setInfo("puerto rico");
            if (code == PK1.Name)
                setInfo("pakistan");
            if (code == PS1.Name)
                setInfo("palestinian territory");
            if (code == PA1.Name)
                setInfo("panama");
            if (code == PG1.Name)
                setInfo("papua New Guinea");
            if (code == PY1.Name)
                setInfo("paraguay");
            if (code == PE1.Name)
                setInfo("peru");
            if (code == PH1.Name)
                setInfo("philippines");
            if (code == PN1.Name)
                setInfo("pitcairn");
            if (code == PL1.Name)
                setInfo("poland");
            if (code == PT1.Name)
                setInfo("portugal");
            if (code == QA1.Name)
                setInfo("qatar");
            //R
            if (code == CG1.Name)
                setInfo("republic of the congo");
            if (code == RE1.Name)
                setInfo("reunion");
            if (code == RO1.Name)
                setInfo("romania");
            if (code == RU1.Name)
                setInfo("russia");
            if (code == RW1.Name)
                setInfo("rwanda");
            //S
            if (code == KN1.Name)
                setInfo("saint kitts and nevis");
            if (code == LC1.Name)
                setInfo("saint lucia");
            if (code == VC1.Name)
                setInfo("saint vincent and the grenadines");
            if (code == SA1.Name)
                setInfo("saudi arabia");
            if (code == SN1.Name)
                setInfo("senegal");
            if (code == RS1.Name)
                setInfo("serbia");
            if (code == SC1.Name)
                setInfo("seychelles");
            if (code == SL1.Name)
                setInfo("sierra leone");
            if (code == SG1.Name)
                setInfo("singapore");
            if (code == SX1.Name)
                setInfo("sint maarten");
            if (code == SK1.Name)
                setInfo("slovenia");
            if (code == SI1.Name)
                setInfo("slovakia");
            if (code == SB1.Name)
                setInfo("solomon islands");
            if (code == SO1.Name)
                setInfo("somalia");
            if (code == ZA1.Name)
                setInfo("south africa");
            if (code == KR1.Name)
                setInfo("south korea");
            if (code == SS1.Name)
                setInfo("south sudan");
            if (code == ES1.Name)
                setInfo("spain");
            if (code == LK1.Name)
                setInfo("sri Lanka");
            if (code == SD1.Name)
                setInfo("sudan");
            if (code == SR1.Name)
                setInfo("suriname");
            if (code == SZ1.Name)
                setInfo("swaziland");
            if (code == CH1.Name)
                setInfo("switzerland");
            if (code == SE1.Name)
                setInfo("sweden");
            if (code == SY1.Name)
                setInfo("syria");
            //T
            if (code == TW1.Name)
                setInfo("taiwan");
            if (code == TJ1.Name)
                setInfo("tajikistan");
            if (code == TZ1.Name)
                setInfo("tanzania");
            if (code == TH1.Name)
                setInfo("thailand");
            if (code == TG1.Name)
                setInfo("togo");
            if (code == TO1.Name)
                setInfo("tonga");
            if (code == TT1.Name)
                setInfo("trinidad and tobago");
            if (code == TN1.Name)
                setInfo("tunisia");
            if (code == TR1.Name)
                setInfo("turkey");
            if (code == TM1.Name)
                setInfo("turkmenistan");
            if (code == TC1.Name)
                setInfo("turks and caicos");
            //U
            if (code == UY1.Name)
                setInfo("uruguay");
            if (code == UZ1.Name)
                setInfo("uzbekistn");
            if (code == UG1.Name)
                setInfo("uganda");
            if (code == UA1.Name)
                setInfo("ukraine");
            if (code == AE1.Name)
                setInfo("united arab emirates");
            if (code == GB1.Name)
                setInfo("united kingdom");
            if (code == US1.Name)
                setInfo("united states");
            //V, W
            if (code == VI1.Name)
                setInfo("virgin islands");
            if (code == VU1.Name)
                setInfo("vanuatu");
            if (code == VE1.Name)
                setInfo("venezuela");
            if (code == VN1.Name)
                setInfo("vietnam");
            if (code == EH1.Name)
                setInfo("western sahara");

            //Y, Z
            if (code == YT1.Name)
                setInfo("mayotte");
            if (code == YE1.Name)
                setInfo("yemen");
            if (code == ZM1.Name)
                setInfo("zambia");
            if (code == ZW1.Name)
                setInfo("zimbabwe");
        }


        /*Most travelled countries by ranking*/
        private void Country_Click(object sender, RoutedEventArgs e)
        {
            keyNum.Visibility = Visibility.Visible;

            lgbtMode = false;
            setColor = true;
            Brush top1 = (SolidColorBrush)new BrushConverter().ConvertFromString("#521414");
            Brush top2 = (SolidColorBrush)new BrushConverter().ConvertFromString("#7A1F1F");
            Brush top3 = (SolidColorBrush)new BrushConverter().ConvertFromString("#A32929");
            Brush top4 = (SolidColorBrush)new BrushConverter().ConvertFromString("#CC3333");
            Brush top5 = (SolidColorBrush)new BrushConverter().ConvertFromString("#D65C5C");

            //Over 50mil
            FR1.Fill = top1;
            ES1.Fill = top1;
            US1.Fill = top1;
            CN1.Fill = top1;
            IT1.Fill = top1;

            //From 20-50mil
            MX1.Fill = top2;
            GB1.Fill = top2;
            TR1.Fill = top2;
            DE1.Fill = top2;
            TH1.Fill = top2;
            AT1.Fill = top2;
            JP1.Fill = top2;
            HK1.Fill = top2;
            GR1.Fill = top2;
            MY1.Fill = top2;
            RU1.Fill = top2;
            CA1.Fill = top2;

            //From 10-20mil
            PL1.Fill = top3;
            NL1.Fill = top3;
            SA1.Fill = top3;
            HR1.Fill = top3;
            IN1.Fill = top3;
            PT1.Fill = top3;
            UA1.Fill = top3;
            ID1.Fill = top3;
            SG1.Fill = top3;
            KR1.Fill = top3;
            VN1.Fill = top3;
            DK1.Fill = top3;
            MA1.Fill = top3;
            BY1.Fill = top3;
            RO1.Fill = top3;
            IE1.Fill = top3;
            ZA1.Fill = top3;
            CZ1.Fill = top3;

            //From 5-10mil
            CH1.Fill = top4;
            BG1.Fill = top4;
            AU1.Fill = top4;
            BE1.Fill = top4;
            EG1.Fill = top4;
            KZ1.Fill = top4;
            AE1.Fill = top4;
            SE1.Fill = top4;
            TN1.Fill = top4;
            AR1.Fill = top4;
            PH1.Fill = top4;
            BR1.Fill = top4;
            GE1.Fill = top4;
            CL1.Fill = top4;
            NO1.Fill = top4;
            DO1.Fill = top4;
            HU1.Fill = top4;
            KH1.Fill = top4;
            SY1.Fill = top4;

            //From 1-5mil
            //Start from Iran stt 57
            IR1.Fill = top5;
            AL1.Fill = top5;
            CU1.Fill = top5;
            KG1.Fill = top5;
            CO1.Fill = top5;
            PE1.Fill = top5;
            JO1.Fill = top5;
            PR1.Fill = top5;
            UY1.Fill = top5;
            CY1.Fill = top5;
            IL1.Fill = top5;
            SY1.Fill = top5;
            NZ1.Fill = top5;
            MM1.Fill = top5;
            LA1.Fill = top5;
            EE1.Fill = top5;
            FI1.Fill = top5;
            CR1.Fill = top5;
            AD1.Fill = top5;
            UZ1.Fill = top5;
            LT1.Fill = top5;
            AZ1.Fill = top5;
            DZ1.Fill = top5;
            ZW1.Fill = top5;
            OM1.Fill = top5;
            JM1.Fill = top5;
            MT1.Fill = top5;
            QA1.Fill = top5;
            IS1.Fill = top5;
            SK1.Fill = top5;
            LK1.Fill = top5;
            GT1.Fill = top5;
            LV1.Fill = top5;
            NG1.Fill = top5;
            ME1.Fill = top5;
            LB1.Fill = top5;
            PA1.Fill = top5;
            CI1.Fill = top5;
            NI1.Fill = top5;
            EC1.Fill = top5;
            PY1.Fill = top5;
            BW1.Fill = top5;
            SV1.Fill = top5;
            NA1.Fill = top5;
            RS1.Fill = top5;
            AM1.Fill = top5;
            MZ1.Fill = top5;
            BS1.Fill = top5;
            UG1.Fill = top5;
            SN1.Fill = top5;
            KE1.Fill = top5;
            MU1.Fill = top5;
            TZ1.Fill = top5;
            LS1.Fill = top5;
            BO1.Fill = top5;
            ZM1.Fill = top5;
            LU1.Fill = top5;
        }

        /*Display festival information*/
        private void Festival_Click(object sender, RoutedEventArgs e)
        {
            /*setColor = true;
            
            Brush b1 = (SolidColorBrush)new BrushConverter().ConvertFromString("#337FCC");
            Brush b2 = (SolidColorBrush)new BrushConverter().ConvertFromString("#5C99D6");
            Brush b3 = (SolidColorBrush)new BrushConverter().ConvertFromString("#85B2E0");
            Brush b4 = (SolidColorBrush)new BrushConverter().ConvertFromString("#ADCCEB");

            US1.Fill = b1;
            GB1.Fill = b2;
            CN1.Fill = b2;
            AT1.Fill = b3;
            IN1.Fill = b3;
            TH1.Fill = b3;
            ES1.Fill = b3;
            IE1.Fill = b4;
            MX1.Fill = b4;
            JP1.Fill = b4;
            NL1.Fill = b4;
            RU1.Fill = b4;
            TR1.Fill = b4;
            IT1.Fill = b4;
            TW1.Fill = b4;
            BR1.Fill = b4;
            SA1.Fill = b4;
            BE1.Fill = b4;
            DE1.Fill = b4;
            CA1.Fill = b4;
            */

            p.Visibility = Visibility.Visible;
            p1.Visibility = Visibility.Visible;
            p2.Visibility = Visibility.Visible;
            p3.Visibility = Visibility.Visible;
            p4.Visibility = Visibility.Visible;
            p5.Visibility = Visibility.Visible;
            p6.Visibility = Visibility.Visible;
            p7.Visibility = Visibility.Visible;
            p8.Visibility = Visibility.Visible;
            p9.Visibility = Visibility.Visible;
            p10.Visibility = Visibility.Visible;
            p11.Visibility = Visibility.Visible;
            p12.Visibility = Visibility.Visible;
            p13.Visibility = Visibility.Visible;
            p14.Visibility = Visibility.Visible;
            p15.Visibility = Visibility.Visible;
            p16.Visibility = Visibility.Visible;
            p17.Visibility = Visibility.Visible;
            p18.Visibility = Visibility.Visible;
            p19.Visibility = Visibility.Visible;
            p20.Visibility = Visibility.Visible;
            p21.Visibility = Visibility.Visible;
            p22.Visibility = Visibility.Visible;
            p23.Visibility = Visibility.Visible;
            p24.Visibility = Visibility.Visible;
            p25.Visibility = Visibility.Visible;
            p26.Visibility = Visibility.Visible;
            p27.Visibility = Visibility.Visible;
            p28.Visibility = Visibility.Visible;
            p29.Visibility = Visibility.Visible;
            p30.Visibility = Visibility.Visible;

        }

        /*Show landmarks*/
        private void showLandmark()
        {
            lm1.Visibility = Visibility.Visible;
            lm2.Visibility = Visibility.Visible;
            lm3.Visibility = Visibility.Visible;
            lm4.Visibility = Visibility.Visible;
            lm5.Visibility = Visibility.Visible;
            lm6.Visibility = Visibility.Visible;
            lm7.Visibility = Visibility.Visible;
            lm8.Visibility = Visibility.Visible;
            lm9.Visibility = Visibility.Visible;
            lm10.Visibility = Visibility.Visible;
            lm11.Visibility = Visibility.Visible;
            lm12.Visibility = Visibility.Visible;
            lm13.Visibility = Visibility.Visible;
            lm14.Visibility = Visibility.Visible;
            lm15.Visibility = Visibility.Visible;
            lm16.Visibility = Visibility.Visible;
            lm17.Visibility = Visibility.Visible;
            lm18.Visibility = Visibility.Visible;
            lm19.Visibility = Visibility.Visible;
            lm20.Visibility = Visibility.Visible;
            lm21.Visibility = Visibility.Visible;
            lm22.Visibility = Visibility.Visible;
            lm23.Visibility = Visibility.Visible;
            lm24.Visibility = Visibility.Visible;
            lm25.Visibility = Visibility.Visible;
            lm26.Visibility = Visibility.Visible;
            lm27.Visibility = Visibility.Visible;
            lm28.Visibility = Visibility.Visible;
            lm29.Visibility = Visibility.Visible;
            lm30.Visibility = Visibility.Visible;
            lm31.Visibility = Visibility.Visible;
            lm32.Visibility = Visibility.Visible;
            lm33.Visibility = Visibility.Visible;
            lm34.Visibility = Visibility.Visible;
            lm35.Visibility = Visibility.Visible;
            lm36.Visibility = Visibility.Visible;
            lm37.Visibility = Visibility.Visible;
            lm38.Visibility = Visibility.Visible;
            lm39.Visibility = Visibility.Visible;
            lm40.Visibility = Visibility.Visible;
            lm41.Visibility = Visibility.Visible;
            lm42.Visibility = Visibility.Visible;
            lm43.Visibility = Visibility.Visible;
            lm44.Visibility = Visibility.Visible;
            lm45.Visibility = Visibility.Visible;
            lm46.Visibility = Visibility.Visible;
            lm47.Visibility = Visibility.Visible;
            lm48.Visibility = Visibility.Visible;
            lm49.Visibility = Visibility.Visible;
            lm50.Visibility = Visibility.Visible;
            lm51.Visibility = Visibility.Visible;
            lm52.Visibility = Visibility.Visible;
            lm53.Visibility = Visibility.Visible;
            lm54.Visibility = Visibility.Visible;
            lm55.Visibility = Visibility.Visible;
            lm56.Visibility = Visibility.Visible;
            lm57.Visibility = Visibility.Visible;
            lm58.Visibility = Visibility.Visible;
            lm59.Visibility = Visibility.Visible;
            lm60.Visibility = Visibility.Visible;
            lm61.Visibility = Visibility.Visible;
        }

        private void Landmark_Click(object sender, RoutedEventArgs e)
        {
            showLandmark();
        }
    }
}
