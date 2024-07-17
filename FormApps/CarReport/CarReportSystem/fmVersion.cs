using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            version.Text = "Ver " + ver.ToString();

            // AssemblyCompanyAttribute 属性を取得して会社名を表示
            object[] companyAttributes = asm.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (companyAttributes.Length > 0) {
                AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute)companyAttributes[0];
                string company = companyAttribute.Company;
                compan.Text = "会社名: " + company;
            } else {
                compan.Text = "会社名: 不明";
            }

            // AssemblyCopyrightAttribute 属性を取得して著作権情報を表示
            object[] copyrightAttributes = asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (copyrightAttributes.Length > 0) {
                AssemblyCopyrightAttribute copyrightAttribute = (AssemblyCopyrightAttribute)copyrightAttributes[0];
                string copyright = copyrightAttribute.Copyright;
                create.Text = "作者: " + copyright;
            } else {
                create.Text = "作者情報が見つかりませんでした。";
            }
        }

        private void btVersionOK_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
