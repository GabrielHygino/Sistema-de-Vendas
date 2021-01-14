using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SqlStringConnections;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SistemaVendasPrj
{
    public class CommonFuncs
    {
        public static bool IsValidDate(object sender)
        {

            MaskedTextBox txt = (MaskedTextBox)sender;
            String strDateNasc = txt.Text;
            DateTime rs;
            CultureInfo ci = new CultureInfo("pt-BR");
            bool isOk = false;

            String[] AllowedDateFormat = new String[]
            {
                "dd/MM/yyyy"
            };

            for (int i = 0; i < AllowedDateFormat.Length; i++)
            {
                if (DateTime.TryParseExact(strDateNasc, AllowedDateFormat[i], ci, DateTimeStyles.None, out rs))
                {
                    txt.Text = rs.Date.ToString("dd/MM/yyyy");
                    isOk = true;
                    break;
                }

                if (!isOk)
                {
                    MessageBox.Show("Data inválida, por favor insira uma data válida!");
                    txt.Clear();
                }
            }
            return isOk;
        }
    }
}
